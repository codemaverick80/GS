using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GS.Core.Api.Extension;
using GS.Core.Api.MapperProfiles;
using GS.Core.Api.Options;
using GS.Core.Api.Services.AppConfigurations;
using GS.Core.Api.Services.LoggerService;
using GS.Core.Database.Entities;
using GS.Core.Database.Repository.Implementation;
using GS.Core.Database.Repository.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;

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


            #region "Clean ConfigureService Method"
            /* this section is moved to ServiceConfiguration folder for code clean up purpose only */
            //services.AddTransient<IGenresRepository, GenresRepository>();

            //services.AddDbContext<SGDbContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("DatabaseConnection")));



            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
            //     .AddJsonOptions(options => {
            //         options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            //     });


            //services.AddSwaggerGen(x =>
            //{
            //    x.SwaggerDoc("v1", new Info { Title = "SG API", Version = "v1" });
            //});

            #endregion


           // services.AddAutoMapper(); //Automapper version 4.0.1
            services.AddAutoMapper(typeof(Startup)); //Automapper version 7.0
            
            services.ConfigureGsServicesInAssembly(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerManager logger)
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


            /* Swagger Configuration - START*/
            var swaggerOptions = new Options.SwaggerOptions();
            Configuration.GetSection(nameof(Options.SwaggerOptions)).Bind(swaggerOptions);
            app.UseSwagger(option =>
            {
                option.RouteTemplate = swaggerOptions.JsonRoute;
            });
            app.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint(swaggerOptions.UiEndpoint, swaggerOptions.Description);
            });
            /* Swagger Configuration - END*/

            //app.ConfigureExceptionHandler(logger);
            app.ConfigureCustomExceptionMiddleware();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
