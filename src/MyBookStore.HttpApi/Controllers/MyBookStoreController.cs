using MyBookStore.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace MyBookStore.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class MyBookStoreController : AbpController
    {
        protected MyBookStoreController()
        {
            LocalizationResource = typeof(MyBookStoreResource);
        }
    }
}