using AutoMapper;
using BookingTickets.Business.Dtos.PersonDtos;
using BookingTickets.Core.Entities;

namespace BookingTickets.Business.AutoMappers;

public class PersonAutoMapper : Profile
{
    public PersonAutoMapper()
    {
        CreateMap<Person, PersonCreateDto>().ReverseMap();
        CreateMap<Person, PersonUpdateDto>().ReverseMap().ForMember(x => x.ImageUrl, x => x.Ignore());
        CreateMap<Person, PersonReturnDto>();
    }
}
