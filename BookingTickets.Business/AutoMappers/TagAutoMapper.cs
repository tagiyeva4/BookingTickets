using AutoMapper;
using BookingTickets.Business.Dtos.TagDtos;
using BookingTickets.Core.Entities;

namespace BookingTickets.Business.AutoMappers;

internal class TagAutoMapper : Profile
{
    public TagAutoMapper()
    {
        CreateMap<Tag, TagCreateDto>().ReverseMap();
        CreateMap<Tag, TagUpdateDto>().ReverseMap();
        CreateMap<Tag, TagReturnDto>();
    }
}
