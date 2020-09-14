using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace MyBookStore.Books
{
    /// <summary>
    /// Book实体继承了AuditedAggregateRoot,AuditedAggregateRoot类
    /// 在AggregateRoot类的基础上添加了一些审计属性(CreationTime, CreatorId, LastModificationTime 等)ABP框架自动为你管理这些属性.
    /// Guid是Book实体的主键类型
    /// </summary>
    public class Book : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }

        public BookType Type { get; set; }

        public DateTime PublishDate { get; set; }

        public float Price { get; set; }
    }
}