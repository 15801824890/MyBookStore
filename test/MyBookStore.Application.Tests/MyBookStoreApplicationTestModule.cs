using Volo.Abp.Modularity;

namespace MyBookStore
{
    [DependsOn(
        typeof(MyBookStoreApplicationModule),
        typeof(MyBookStoreDomainTestModule)
        )]
    public class MyBookStoreApplicationTestModule : AbpModule
    {

    }
}