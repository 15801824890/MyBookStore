using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace MyBookStore.EntityFrameworkCore
{
    [DependsOn(
        typeof(MyBookStoreEntityFrameworkCoreModule)
        )]
    public class MyBookStoreEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<MyBookStoreMigrationsDbContext>();
        }
    }
}
