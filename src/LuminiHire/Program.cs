using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CollegeScorecard.Infra.ES;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CollegeScorecard
{
    public class Program
    {

        public static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }

        public static async Task MainAsync(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();



            using (var scope = host.Services.CreateScope())
            {
                var loader = scope.ServiceProvider.GetRequiredService<ElasticData>();
                await loader.LoadData();
            }


            await host.RunAsync();

        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureKestrel(options => { options.AddServerHeader = false; })
                .UseStartup<Startup>();



    }
}
