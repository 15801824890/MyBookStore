using System.Collections.Generic;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace MyBookStore.JobSchedule
{
    public interface IJobInfoAppService :
        ICrudAppService< //定义了CRUD方法
            JobInfoDto, //用来展示任务
            int, //JobInfo实体的主键
            PagedAndSortedResultRequestDto, //获取任务的时候用于分页和排序
            CreateUpdateJobInfoDto> //用户更新任务
    {
        //     /// <summary>
        //     /// 应用程序停止时暂停所有任务
        //     /// </summary>
        //     /// <returns></returns>
        //     bool SystemStopped();
        //
        //     /// <summary>
        //     /// 应用程序启动时启动所有任务
        //     /// </summary>
        //     /// <returns></returns>
        //     bool ResumeSystemStopped();
        //
        //     /// <summary>
        //     /// 根据状态获取所有的任务列表
        //     /// </summary>
        //     /// <param name="jobStatu"></param>
        //     /// <returns></returns>
        //     List<JobInfoDto> GetListByJobStatus(JobStatus jobStatus);
    }
}