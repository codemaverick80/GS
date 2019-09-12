using GS.Core.Api.Services.LoggerService;
using Microsoft.AspNetCore.Mvc;
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


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                 .AddJsonOptions(options => {
                     options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                 });


            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Info { Title = "SG API", Version = "v1" });
            });

        }
    }
}
