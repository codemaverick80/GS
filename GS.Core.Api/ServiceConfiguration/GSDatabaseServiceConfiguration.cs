using System;
using GS.Core.Database.Entities;
using GS.Core.Database.Repository.Implementation;
using GS.Core.Database.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GS.Core.Api.ServiceConfiguration
{
    public class GSDatabaseServiceConfiguration : IGSConfigureService
    {
        
        public void GSConfigureService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IGenresRepository, GenresRepository>();
            services.AddTransient<IArtistRepository, ArtistsRepository>();
            services.AddTransient<IAlbumRepository, AlbumRepository>();
           
            services.AddDbContext<SGDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DatabaseConnection")));


        }
    }
}
