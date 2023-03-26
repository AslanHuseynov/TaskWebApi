using AutoMapper;
using System.Diagnostics.Metrics;
using WebApiProject.Dtos.BookDto;
using WebApiProject.Models;

namespace WebApiProject.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Book, CreateBookDto>().ReverseMap();
            CreateMap<Book, UpdateBookDto>().ReverseMap();
        }
    }
}
