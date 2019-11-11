using GS.Core.Database.Entities;
using GS.Core.Database.Repository.Implementation;
using GS.Core.Database.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GS.Core.Api.Services.AppConfigurations
{
    public class GsDatabaseServiceConfiguration : IGsConfigureService
    {
        public void GsConfigureService(IServiceCollection services, IConfiguration configuration)
        {
           ////services.AddDbContext<GsDbContext> means GsDbContext is register with Scoped life time.
            services.AddDbContext<GsDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DatabaseConnection")));

            //// Here all the repository services uses the GsDbContext and GsDBContext is DbContext.
            //// that means we must register these services with scope that is equal to or shorter than DbContext (Scoped life time)
            //// we can not register with Singleton life time which is larger than DbContext life time.
            services.AddScoped<IGenresRepository, GenresRepository>();
            services.AddScoped<IArtistRepository, ArtistsRepository>();
            services.AddScoped<IAlbumRepository, AlbumRepository>();
        }
    }
}
