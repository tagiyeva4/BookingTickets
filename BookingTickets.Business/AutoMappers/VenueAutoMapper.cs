using AutoMapper;
using BookingTickets.Business.Dtos.TagDtos;
using BookingTickets.Business.Dtos.VenueDtos;
using BookingTickets.Core.Entities;
using BookingTickets.Core.Enums;

namespace BookingTickets.Business.AutoMappers;

public class VenueAutoMapper : Profile
{
    public VenueAutoMapper()
    {
        CreateMap<VenueCreateDto, Venue>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()) 
            .ForMember(dest => dest.Seats, opt => opt.Ignore()); 

        CreateMap<VenueUpdateDto, Venue>()
            .ForMember(dest => dest.Seats, opt => opt.Ignore()); // Sıra və oturacaqlara müdaxilə olmur

        CreateMap<Venue, VenueUpdateDto>()
     .ForMember(dest => dest.NumberOfRows, opt => opt.MapFrom(src =>
        src.Seats != null && src.Seats.Any()
            ? src.Seats.Max(s => s.RowNumber)
            : 0))
     .ForMember(dest => dest.SeatsPerRow, opt => opt.MapFrom(src =>
        src.Seats != null && src.Seats.Any()
            ? src.Seats.GroupBy(s => s.RowNumber).Max(g => g.Count())
            : 0))
     .ForMember(dest => dest.RowNamingStyle, opt => opt.MapFrom(src =>
        src.Seats != null && src.Seats.Any()
            ? (src.Seats.First().RowName != null && src.Seats.First().RowName.All(char.IsDigit)
                ? RowNamingStyle.Numeric
                : RowNamingStyle.Alphabetic)
            : RowNamingStyle.Numeric));

        CreateMap<Venue, VenueReturnDto>();
        CreateMap<VenueSeat, VenueSeatDto>().ReverseMap();
    }
}
