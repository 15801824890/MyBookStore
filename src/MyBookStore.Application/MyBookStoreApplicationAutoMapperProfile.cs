using AutoMapper;
using MyBookStore.Authors;
using MyBookStore.Books;
using MyBookStore.JobSchedule;

namespace MyBookStore
{
    public class MyBookStoreApplicationAutoMapperProfile : Profile
    {
        public MyBookStoreApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<Book, BookDto>();
            CreateMap<CreateUpdateBookDto, Book>();

            CreateMap<Author, AuthorDto>();

            CreateMap<JobInfo, JobInfoDto>();
            CreateMap<CreateUpdateJobInfoDto, JobInfo>();
        }
    }
}