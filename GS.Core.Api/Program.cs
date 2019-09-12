using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GS.Core.Database.Entities;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace GS.Core.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            /* API Load testing:
            * Throttle the thread pool (set available threats to amount of processors)
            */
            ThreadPool.SetMaxThreads(Environment.ProcessorCount, Environment.ProcessorCount);
            
            
            //#### If we are NOT seeding data             
             
            CreateWebHostBuilder(args).Build().Run();

            //#### If we are trying to seed data             

            //var host = CreateWebHostBuilder(args).Build();
            //using (var scope = host.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;
            //    try
            //    {
            //        var context = services.GetRequiredService<SGDbContext>();
            //        DataSedder.Initialize(context);
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine("An error occured while seeping the database with data");

            //    }
            //}
            //host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
