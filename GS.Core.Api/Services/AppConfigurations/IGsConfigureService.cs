using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GS.Core.Api.Services.AppConfigurations
{
    public interface IGsConfigureService
    {
        void GsConfigureService(IServiceCollection services, IConfiguration configuration);
    }
}
