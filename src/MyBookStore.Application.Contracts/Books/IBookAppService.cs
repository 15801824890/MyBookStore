using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace MyBookStore.Books
{
    /// <summary>
    /// ICrudAppService定义了常见的CRUD方法:GetAsync,GetListAsync,CreateAsync,UpdateAsync和DeleteAsync.
    /// 你可以从空的IApplicationService接口继承并手动定义自己的方法
    /// </summary>
    public interface IBookAppService :
        ICrudAppService< //Defines CRUD methods
            BookDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateBookDto> //Used to create/update a book
    {
    }
}