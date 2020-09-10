using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace MyBookStore.Data
{
    /* This is used if database provider does't define
     * IMyBookStoreDbSchemaMigrator implementation.
     */
    public class NullMyBookStoreDbSchemaMigrator : IMyBookStoreDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}