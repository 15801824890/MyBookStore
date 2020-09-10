using MyBookStore.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace MyBookStore
{
    [DependsOn(
        typeof(MyBookStoreEntityFrameworkCoreTestModule)
        )]
    public class MyBookStoreDomainTestModule : AbpModule
    {

    }
}