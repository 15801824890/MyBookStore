using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MyBookStore.JobSchedule
{
    public enum JobStatus : byte
    {
        [Description("执行中")] Running,
        [Description("已完成")] Completed,
        [Description("已停止")] Stopped,
        [Description("系统停止")] SystemStopped,
        [Description("已删除")] Deleted,
    }
}