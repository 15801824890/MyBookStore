using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace MyBookStore.JobSchedule
{
    public class JobInfoAppService :
        CrudAppService< //实现了CRUD方法
            JobInfo, //JobInfo实体
            JobInfoDto, //用来展示书籍
            int, //JobInfo实体的主键
            PagedAndSortedResultRequestDto, //获取书籍的时候用于分页和排序
            CreateUpdateJobInfoDto>, //用户更新书籍
        IJobInfoAppService
    {
        public JobInfoAppService(IRepository<JobInfo, int> repository) : base(repository)
        {
        }
    }
}