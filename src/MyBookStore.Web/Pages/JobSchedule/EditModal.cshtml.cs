using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyBookStore.Web.Pages.JobSchedule
{
    public class EditModalModel : MyBookStorePageModel
    {
        /// <summary>
        /// [HiddenInput] 和 [BindProperty] 是标准的 ASP.NET Core MVC 特性.这里启用 SupportsGet 从Http请求的查询字符串中获取Id的值
        /// </summary>
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public void OnGet()
        {
        }
    }
}
