using GS.Core.Api.Services.LoggerService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;

namespace GS.Core.Api.Services.AppConfigurations
{
    public class GsMvcServiceConfiguration : IGsConfigureService
    {
        public void GsConfigureService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(options => {
                     options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                 });

//            services.AddMvc(options => options.EnableEndpointRouting = false  )
//                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            
            
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
              // options.ApiVersionReader = new HeaderApiVersionReader("x-version");
               options.ApiVersionReader = ApiVersionReader.Combine(
                   new HeaderApiVersionReader("x-version"),
                   new QueryStringApiVersionReader("ver")
                   );
               options.DefaultApiVersion=new ApiVersion(1,0);
                
            } );
            
            
            
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Info { Title = "SG API", Version = "v1" });
            });

        }
    }
}
