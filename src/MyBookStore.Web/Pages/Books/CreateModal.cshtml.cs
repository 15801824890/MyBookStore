using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyBookStore.Books;

namespace MyBookStore.Web.Pages.Books
{
    /// <summary>
    /// BookStorePageModel �̳��� PageModel ���������һЩ���Ա����page model��ʹ�õ�ͨ�����Ժͷ���
    /// Book �����ϵ� [BindProperty] ���Խ�post�����ύ���������ݰ󶨵���������.
    /// </summary>
    public class CreateModalModel : MyBookStorePageModel
    {
        [BindProperty]
        public CreateUpdateBookDto Book { get; set; }

        private readonly IBookAppService _bookAppService;

        public CreateModalModel(IBookAppService bookAppService)
        {
            _bookAppService = bookAppService;
        }

        public void OnGet()
        {
            Book = new CreateUpdateBookDto();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _bookAppService.CreateAsync(Book);
            return NoContent();
        }
    }
}
