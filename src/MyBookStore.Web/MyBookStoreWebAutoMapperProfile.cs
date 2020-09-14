using AutoMapper;
using MyBookStore.Books;

namespace MyBookStore.Web
{
    public class MyBookStoreWebAutoMapperProfile : Profile
    {
        public MyBookStoreWebAutoMapperProfile()
        {
            //Define your AutoMapper configuration here for the Web project.
            CreateMap<BookDto, CreateUpdateBookDto>();
        }
    }
}
