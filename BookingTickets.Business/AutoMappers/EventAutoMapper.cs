using AutoMapper;
using BookingTickets.Business.Dtos.EventDtos;
using BookingTickets.Core.Entities;

namespace BookingTickets.Business.AutoMappers;

public class EventAutoMapper:Profile
{
    public EventAutoMapper()
    {

        CreateMap<EventCreateDto, Event>()
            .ForMember(dest => dest.EventLanguages, opt => opt.MapFrom(src => src.EventLanguageIds.Select(id => new Language { Id = id })));

        CreateMap<EventUpdateDto, Event>()
            .ForMember(dest => dest.EventLanguages, opt => opt.MapFrom(src => src.EventLanguageIds.Select(id => new Language { Id = id })));

        CreateMap<Event, EventReturnDto>()
            .ForMember(dest => dest.EventLanguages, opt => opt.MapFrom(src => src.EventLanguages.Select(x => new LanguageDtoInEvent { Id = x.Id, Name = x.Name, Code = x.Code })))
            .ForMember(dest => dest.Venue, opt => opt.MapFrom(src => new VenueDtoInEvent { Id = src.Venue.Id, Name = src.Venue.Name, Address = src.Venue.Address, Capacity = src.Venue.Capacity }));

        CreateMap<Venue, VenueDtoInEvent>();

        CreateMap<Language, LanguageDtoInEvent>();
    }
}
