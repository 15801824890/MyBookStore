using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyBookStore.JobSchedule;

namespace MyBookStore.Web.Pages.JobSchedule
{
    public class CreateModalModel : MyBookStorePageModel
    {
        [BindProperty] public CreateUpdateJobInfoDto JobInfo { get; set; }

        private readonly IJobInfoAppService _jobInfoAppService;

        public CreateModalModel(IJobInfoAppService jobInfoAppService)
        {
            _jobInfoAppService = jobInfoAppService;
        }

        public void OnGet()
        {
            JobInfo = new CreateUpdateJobInfoDto();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _jobInfoAppService.CreateAsync(JobInfo);
            return NoContent();
        }
    }
}