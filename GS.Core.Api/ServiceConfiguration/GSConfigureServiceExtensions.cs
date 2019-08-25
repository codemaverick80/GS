using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GS.Core.Api.ServiceConfiguration
{
    public static class GSConfigureServiceExtensions
    {

        public static void ConfigureGSServicesInAssembly(this IServiceCollection services, IConfiguration configuration)
        {

            var configureGSServices = typeof(Startup).Assembly.ExportedTypes.Where(x =>
              typeof(IGSConfigureService).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).Select(Activator.CreateInstance).Cast<IGSConfigureService>().ToList();

            configureGSServices.ForEach(gsConfigureServices => gsConfigureServices.GSConfigureService(services, configuration));
        }


    }
}
