using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace MyBookStore.JobSchedule
{
    public interface IJobInfoRepository : IRepository<JobInfo, int>
    {
        /// <summary>
        /// 应用程序停止时暂停所有任务
        /// </summary>
        /// <returns></returns>
        bool SystemStopped();

        /// <summary>
        /// 应用程序启动时启动所有任务
        /// </summary>
        /// <returns></returns>
        bool ResumeSystemStopped();

        /// <summary>
        /// 根据状态获取所有的任务列表
        /// </summary>
        /// <param name="jobStatu"></param>
        /// <returns></returns>
        List<JobInfo> GetListByJobStatus(JobStatus jobStatus);
    }
}