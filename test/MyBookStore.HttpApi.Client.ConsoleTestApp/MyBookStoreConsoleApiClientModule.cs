using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace MyBookStore.HttpApi.Client.ConsoleTestApp
{
    [DependsOn(
        typeof(MyBookStoreHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class MyBookStoreConsoleApiClientModule : AbpModule
    {
        
    }
}
