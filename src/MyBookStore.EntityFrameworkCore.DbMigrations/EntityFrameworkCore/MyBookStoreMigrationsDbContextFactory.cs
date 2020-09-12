using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MyBookStore.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class MyBookStoreMigrationsDbContextFactory : IDesignTimeDbContextFactory<MyBookStoreMigrationsDbContext>
    {
        public MyBookStoreMigrationsDbContext CreateDbContext(string[] args)
        {
            MyBookStoreEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            // var builder = new DbContextOptionsBuilder<MyBookStoreMigrationsDbContext>()
            //     .UseSqlServer(configuration.GetConnectionString("Default"));

            var builder = new DbContextOptionsBuilder<MyBookStoreMigrationsDbContext>()
                .UseMySql(configuration.GetConnectionString("Default"));
            return new MyBookStoreMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../MyBookStore.DbMigrator/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}