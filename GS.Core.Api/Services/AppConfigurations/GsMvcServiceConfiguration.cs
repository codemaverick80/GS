using System;
using System.Linq;
using GS.Core.Api.Services.LoggerService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace GS.Core.Api.Services.AppConfigurations
{
    public class GsMvcServiceConfiguration : IGsConfigureService
    {
        public void GsConfigureService(IServiceCollection services, IConfiguration configuration)
        {

            services.AddSingleton<ILoggerManager, LoggerManager>();


            #region "Add MVC Service"

            services.AddMvc(setupAction => 
                {
                    setupAction.ReturnHttpNotAcceptable = true;
                    setupAction.OutputFormatters.Add(new XmlSerializerOutputFormatter());
                    var jsonOutputFormatter = setupAction.OutputFormatters.OfType<JsonOutputFormatter>().FirstOrDefault();
                    if (jsonOutputFormatter != null)
                    {
                        // remove text/json as it isn't the approved media type
                        // for working with JSON at API level
                        if (jsonOutputFormatter.SupportedMediaTypes.Contains("text/json"))
                        {
                            jsonOutputFormatter.SupportedMediaTypes.Remove("text/json");
                        }
                    }
                })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
            .AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            #endregion


            #region "Add Api Versioning Service"
            
            services.AddVersionedApiExplorer(setupAction =>
            {
                setupAction.GroupNameFormat = "'v'VV";
            });

            /* Add api Versioning
              *
              *     1. The ReportApiVersions flag is used to add the API versions in the response header
              *     2. The AssumeDefaultVersionWhenUnspecified flag is used to set the default version
              *         when the client has not specified any versions. With this flag, the UnsupportedApiVersion
              *         exception will occur when the version is not specified by the client.
              *     3. The DefaultApiVersion flag is used to set the default version count.
              */

            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                ////// options.ApiVersionReader = new HeaderApiVersionReader("x-version");
                ////options.ApiVersionReader = ApiVersionReader.Combine(
                ////    new HeaderApiVersionReader("x-version"),
                ////    new QueryStringApiVersionReader("v")
                ////    );
                options.DefaultApiVersion = new ApiVersion(1, 0);
            });
            

            var apiVersionDescriptionProvider =
                services.BuildServiceProvider().GetService<IApiVersionDescriptionProvider>();

            #endregion


            #region "Add Swagger Service"

            services.AddSwaggerGen(setupAction =>
            {

                foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
                {
                    //http://localhost:6600/swagger/GsApiSpecification/swagger.json
                    setupAction.SwaggerDoc(
                        $"GsApiSpecification{description.GroupName}",
                        new OpenApiInfo()
                        {
                            Title = "Gs Api",
                            Version = description.ApiVersion.ToString(),
                            Description = "Thru this Api you can access GS open api",
                            Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                            {
                                Email = "gsapi@support.com",
                                Name = "Harish Chand",
                                Url = new Uri("https://www.gsapi.com/harish")
                            },
                            License = new Microsoft.OpenApi.Models.OpenApiLicense()
                            {
                                Name = "MIT License",
                                Url = new Uri("https://opensource.org/licenses/MIT")
                            }
                        });
                }
                setupAction.DocInclusionPredicate((documentName, apiDescription) =>
                {
                    var actionApiVersionModel = apiDescription.ActionDescriptor
                        .GetApiVersionModel(ApiVersionMapping.Explicit | ApiVersionMapping.Implicit);

                    if (actionApiVersionModel == null)
                    {
                        return true;
                    }

                    if (actionApiVersionModel.DeclaredApiVersions.Any())
                    {
                        return actionApiVersionModel.DeclaredApiVersions.Any(v =>
                            $"GsApiSpecificationv{v.ToString()}" == documentName);
                    }
                    return actionApiVersionModel.ImplementedApiVersions.Any(v =>
                        $"GsApiSpecificationv{v.ToString()}" == documentName);
                });
            });

            #endregion

            
        }
    }
}
