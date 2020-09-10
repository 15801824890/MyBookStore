using MyBookStore.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace MyBookStore.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(MyBookStoreEntityFrameworkCoreDbMigrationsModule),
        typeof(MyBookStoreApplicationContractsModule)
        )]
    public class MyBookStoreDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
