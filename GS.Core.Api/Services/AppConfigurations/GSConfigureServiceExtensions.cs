using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GS.Core.Api.Services.AppConfigurations
{
    public static class GsConfigureServiceExtensions
    {

        public static void ConfigureGsServicesInAssembly(this IServiceCollection services, IConfiguration configuration)
        {

            var configureGsServices = typeof(Startup).Assembly.ExportedTypes.Where(x =>
              typeof(IGsConfigureService).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).Select(Activator.CreateInstance).Cast<IGsConfigureService>().ToList();

            configureGsServices.ForEach(gsConfigureServices => gsConfigureServices.GsConfigureService(services, configuration));
        }


    }
}
