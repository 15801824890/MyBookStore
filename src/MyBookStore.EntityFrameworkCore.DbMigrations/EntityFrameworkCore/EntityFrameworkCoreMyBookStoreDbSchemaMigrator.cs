using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyBookStore.Data;
using Volo.Abp.DependencyInjection;

namespace MyBookStore.EntityFrameworkCore
{
    public class EntityFrameworkCoreMyBookStoreDbSchemaMigrator
        : IMyBookStoreDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreMyBookStoreDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the MyBookStoreMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<MyBookStoreMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}