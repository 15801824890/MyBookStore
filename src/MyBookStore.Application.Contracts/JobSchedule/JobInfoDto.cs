using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace MyBookStore.JobSchedule
{
    public class JobInfoDto : AuditedEntityDto<int>
    {
        public string JobGroup { get; set; }

        public string JobDescription { get; set; }

        public string JobName { get; set; }

        public string JobAssemblyName { get; set; }

        public string JobNamespace { get; set; }

        public string JobClassName { get; set; }

        public JobStatus JobStatus { get; set; }

        public string CronExpress { get; set; }

        public DateTime StarTime { get; set; }

        public DateTime EndTime { get; set; }

        public DateTime NextTime { get; set; }
    }
}