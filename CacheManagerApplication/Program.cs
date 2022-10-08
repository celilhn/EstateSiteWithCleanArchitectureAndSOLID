using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CacheManagerApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).ConfigureAppConfiguration((hostingContext, config) =>
                    {
                        var env = hostingContext.HostingEnvironment;
                        var sharedFolder = Path.Combine(env.ContentRootPath, "..", "ConfigFiles");
                        config.AddJsonFile(Path.Combine(sharedFolder, "sharedsettings.json"), optional: true)
                            .AddJsonFile("sharedsettings.json", optional: true)
                            .AddJsonFile("appsettings.json", optional: true);
                    }
                );
    }
}
