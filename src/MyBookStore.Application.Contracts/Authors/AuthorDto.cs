using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace MyBookStore.Authors
{
    /// <summary>
    /// EntityDto<T> simply has an Id property with the given generic argument
    /// </summary>
    public class AuthorDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public string ShortBio { get; set; }
    }
}