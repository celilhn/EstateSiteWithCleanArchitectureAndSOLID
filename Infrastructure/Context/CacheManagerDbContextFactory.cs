using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Reflection;
using Application.Utilities;

namespace Infrastructure.Context
{

    public class CacheManagerDbContextFactory : IDesignTimeDbContextFactory<CacheManagerDbContext>
    {
        private IConfiguration configuration;
        public CacheManagerDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CacheManagerDbContext>();

            var folderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(Path.Combine(folderPath, "sharedsettings.json"), false, true)
                //.AddJsonFile(Path.Combine(folderPath, "appsettings.json"), false, true)
                .AddEnvironmentVariables()
                .Build();
            AppUtilities.AppUtilitiesConfigure(configuration);

            optionsBuilder.UseSqlServer(GetDbConnectionText());
            return new CacheManagerDbContext(optionsBuilder.Options);
        }

        private static string GetDbConnectionText()
        {
            string connectionString = AppUtilities.GetConfigurationValue("DBConnectionText");
            connectionString = string.Format(connectionString, Environment.GetEnvironmentVariable("ECommerceDbUser"), Environment.GetEnvironmentVariable("ECommerceDbPassword"));
            return connectionString;
        }
    }
}