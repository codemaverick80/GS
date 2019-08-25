using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GS.Core.Api.ServiceConfiguration
{
    public interface IGSConfigureService
    {
        void GSConfigureService(IServiceCollection services, IConfiguration configuration);
    }
}
