using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Components;
using Volo.Abp.DependencyInjection;

namespace MyBookStore.Web
{
    [Dependency(ReplaceServices = true)]
    public class MyBookStoreBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "MyBookStore";
    }
}
