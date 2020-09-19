using System;
using System.Collections.Generic;
using System.Text;
using MyBookStore.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace MyBookStore.Books
{
    /// <summary>
    /// BookAppService使用IObjectMapper将Book对象转换为BookDto对象, 将CreateUpdateBookDto对象转换为Book对象
    /// </summary>
    public class BookAppService :
        CrudAppService<
            Book, //The Book entity
            BookDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateBookDto>, //Used to create/update a book
        IBookAppService //implement the IBookAppService
    {
        public BookAppService(IRepository<Book, Guid> repository)
            : base(repository)
        {
            //use the permissions to authorize the book management
            GetPolicyName = MyBookStorePermissions.Books.Default;
            GetListPolicyName = MyBookStorePermissions.Books.Default;
            CreatePolicyName = MyBookStorePermissions.Books.Create;
            UpdatePolicyName = MyBookStorePermissions.Books.Edit;
            DeletePolicyName = MyBookStorePermissions.Books.Delete;
        }
    }
}