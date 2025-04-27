using AutoMapper;
using BookingTickets.Business.Dtos.VenueDtos;
using BookingTickets.Core.Entities;

namespace BookingTickets.Business.AutoMappers;

internal class VenueAutoMapper : Profile
{
    public VenueAutoMapper()
    {
        CreateMap<VenueCreateDto, Venue>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()) 
            .ForMember(dest => dest.Seats, opt => opt.Ignore()); 


        CreateMap<Venue, VenueUpdateDto>()
              .ForMember(dest => dest.NumberOfRows, opt => opt.Ignore())
              .ForMember(dest => dest.SeatsPerRow, opt => opt.Ignore())
              .ForMember(dest => dest.RowNamingStyle, opt => opt.Ignore());

        CreateMap<VenueUpdateDto, Venue>()
            .ForMember(dest => dest.Seats, opt => opt.Ignore())
            .ForMember(dest => dest.Capacity, opt => opt.MapFrom(src => src.NumberOfRows * src.SeatsPerRow))
            .ForMember(dest => dest.Events, opt => opt.Ignore());

        CreateMap<Venue, VenueReturnDto>();

        CreateMap<VenueSeat, VenueSeatDto>().ReverseMap();
    }
}
