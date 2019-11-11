using AutoMapper;
using GS.Core.Api.Extension;
using GS.Core.Api.Services.AppConfigurations;
using GS.Core.Api.Services.LoggerService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GS.Core.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddAutoMapper(typeof(Startup)); 
            services.ConfigureGsServicesInAssembly(Configuration);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerManager logger, 
            IApiVersionDescriptionProvider apiVersionDescriptionProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.ConfigureExceptionHandler(logger);
            app.ConfigureCustomExceptionMiddleware();

            app.UseHttpsRedirection();

            #region "Swagger Middleware"

            app.UseSwagger();
            app.UseSwaggerUI(option =>
            {
                //// http://localhost:6600/swagger/index.html
                foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
                {
                    option.SwaggerEndpoint($"/swagger/" +
                                           $"GsApiSpecification{description.GroupName}/swagger.json",
                        description.GroupName.ToUpperInvariant());
                }
                option.RoutePrefix = "";
            });
            
            #endregion


            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
