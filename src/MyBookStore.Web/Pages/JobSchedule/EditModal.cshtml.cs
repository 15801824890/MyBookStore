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
        /// [HiddenInput] �� [BindProperty] �Ǳ�׼�� ASP.NET Core MVC ����.�������� SupportsGet ��Http����Ĳ�ѯ�ַ����л�ȡId��ֵ
        /// </summary>
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public void OnGet()
        {
        }
    }
}
