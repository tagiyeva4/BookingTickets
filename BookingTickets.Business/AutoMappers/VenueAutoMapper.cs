using AutoMapper;
using BookingTickets.Business.Dtos.TagDtos;
using BookingTickets.Business.Dtos.VenueDtos;
using BookingTickets.Core.Entities;

namespace BookingTickets.Business.AutoMappers;

public class VenueAutoMapper : Profile
{
    public VenueAutoMapper()
    {
        CreateMap<Venue, VenueCreateDto>().ReverseMap();
        CreateMap<Venue, VenueUpdateDto>().ReverseMap();
        CreateMap<Venue, VenueReturnDto>();
    }
}
