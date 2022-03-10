
using AutoMapper;
using Domain.DTO;
using Domain.Models;

namespace API.CQRS.Sample.Controllers

{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Person, PersonDto>();
        }

    }

}