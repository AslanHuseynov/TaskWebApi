using AutoMapper;
using WebApiProject.Dtos.AuthorDto;
using WebApiProject.Dtos.BookDto;

namespace WebApiProject.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Book, CreateBookDto>().ReverseMap();
            CreateMap<Book, UpdateBookDto>().ReverseMap();
            CreateMap<Author, CreateAuthorDto>().ReverseMap();
            CreateMap<Author, UpdateAuthorDto>().ReverseMap();
        }
    }
}
