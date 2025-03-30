using AutoMapper;
using BookingTickets.Business.Dtos.EventDtos;
using BookingTickets.Core.Entities;

namespace BookingTickets.Business.AutoMappers;

public class EventAutoMapper:Profile
{
    public EventAutoMapper()
    {

        CreateMap<Event,EventCreateDto>()
            .ForMember(x=>x.EventLanguageIds,x=>x.MapFrom(x=>x.EventLanguages.Select(x=>x.LanguageId)))
            .ForMember(x => x.EventPersonIds, x => x.MapFrom(x => x.EventPersons.Select(x => x.PersonId)))
            .ReverseMap();

        CreateMap<Event, EventUpdateDto>()
             .ForMember(x => x.EventLanguageIds, x => x.MapFrom(x => x.EventLanguages.Select(x => x.LanguageId)))
              .ForMember(x => x.EventPersonIds, x => x.MapFrom(x => x.EventPersons.Select(x => x.PersonId)))
                .ForMember(x => x.EventScheduleIds, x => x.MapFrom(x => x.EventsSchedules.Select(x => x.ScheduleId)))
          .ForMember(dest => dest.EventImages, opt => opt.MapFrom(src => src.EventImages.Select(img => img.ImagePath)))
          .ReverseMap() // EventUpdateDto -> Event mapping
          .ForMember(dest => dest.EventLanguages, opt => opt.MapFrom(src =>
              src.EventLanguageIds.Select(id => new EventLanguage { LanguageId = id }).ToList()))
           .ForMember(dest => dest.EventsSchedules, opt => opt.MapFrom(src =>
              src.EventScheduleIds.Select(id => new EventsSchedule { ScheduleId = id }).ToList()))
          .ForMember(dest => dest.EventPersons, opt => opt.MapFrom(src =>
              src.EventPersonIds.Select(id => new EventPeron { PersonId = id }).ToList())) // Manuel doldurulacaq
          .ForMember(dest => dest.EventImages, opt => opt.MapFrom(src => src.EventImages != null
              ? src.EventImages.Select(img => new EventImage { ImagePath = img }).ToList()
              : new List<EventImage>()))
          .ForMember(dest => dest.Venue, opt => opt.Ignore()); // Venue-lar ayrıca map ediləcək
       

        CreateMap<Event, EventReturnDto>()
            .ForMember(x=>x.EventLanguages,x=>x.MapFrom(x=>x.EventLanguages.Select(x=>x.Language)))
            .ForMember(x => x.EventPersons, x => x.MapFrom(x => x.EventPersons.Select(x => x.Person)));
       
 // CreateMap<Venue, VenueDtoInEvent>().ReverseMap();

        CreateMap<Person, PersonDtoInEvent>().ReverseMap();
        CreateMap<Language, LanguageDtoInEvent>().ReverseMap();
        CreateMap<Schedule, ScheduleDtoInEvent>().ReverseMap();
        CreateMap<Schedule,ScheduleDto>().ReverseMap();
    }
}
