using System;
using System.Collections.Generic;
using System.Text;
using MyBookStore.Localization;
using Volo.Abp.Application.Services;

namespace MyBookStore
{
    /* Inherit your application services from this class.
     */
    public abstract class MyBookStoreAppService : ApplicationService
    {
        protected MyBookStoreAppService()
        {
            LocalizationResource = typeof(MyBookStoreResource);
        }
    }
}
