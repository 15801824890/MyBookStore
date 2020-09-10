using MyBookStore.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace MyBookStore.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class MyBookStorePageModel : AbpPageModel
    {
        protected MyBookStorePageModel()
        {
            LocalizationResourceType = typeof(MyBookStoreResource);
        }
    }
}