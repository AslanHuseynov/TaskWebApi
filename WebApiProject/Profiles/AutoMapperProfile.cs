using AutoMapper;
using System.Diagnostics.Metrics;
using WebApiProject.Dtos;
using WebApiProject.Models;

namespace WebApiProject.Profiles
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {
            CreateMap<Book, CreateBookDto>().ReverseMap();
        }
    }
}
