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
            .ForMember(dest => dest.SelectedLanguageIds, opt => opt.MapFrom(src => src.EventLanguages.Select(e => e.LanguageId)))
            .ForMember(dest => dest.SelectedPersonIds, opt => opt.MapFrom(src => src.EventPersons.Select(e => e.PersonId)))
            .ForMember(dest => dest.EventSchedules, opt => opt.MapFrom(src => src.EventsSchedules.Select(es => new ScheduleUpdateDto
            {
                Id = es.ScheduleId,
                Date = es.Schedule.Date,
                StartTime = es.Schedule.StartTime,
                EndTime = es.Schedule.EndTime
            }).ToList()))
            .ForMember(dest => dest.ExistingImages, opt => opt.MapFrom(src => src.EventImages.Select(ei => new EventImageDto
            {
                Id = ei.Id,
                ImagePath = ei.ImagePath
            }).ToList()));

        CreateMap<EventUpdateDto, Event>()
            .ForMember(dest => dest.EventLanguages, opt => opt.MapFrom(src => src.SelectedLanguageIds.Select(id => new EventLanguage { LanguageId = id }).ToList()))
            .ForMember(dest => dest.EventPersons, opt => opt.MapFrom(src => src.SelectedPersonIds.Select(id => new EventPeron { PersonId = id }).ToList()))
            .ForMember(dest => dest.EventsSchedules, opt => opt.MapFrom(src => src.EventSchedules.Select(schedule => new EventsSchedule
            {
                ScheduleId = schedule.Id,
                EventId=src.Id
            }).ToList()));




        CreateMap<Event, EventReturnDto>()
            .ForMember(x=>x.EventLanguages,x=>x.MapFrom(x=>x.EventLanguages.Select(x=>x.Language)))
            .ForMember(x => x.EventPersons, x => x.MapFrom(x => x.EventPersons.Select(x => x.Person)));
       
 // CreateMap<Venue, VenueDtoInEvent>().ReverseMap();

        CreateMap<Person, PersonDtoInEvent>().ReverseMap();
        CreateMap<Language, LanguageDtoInEvent>().ReverseMap();
        CreateMap<Schedule, ScheduleDtoInEvent>().ReverseMap();
        CreateMap<Schedule,ScheduleDto>().ReverseMap();
        CreateMap<Schedule, ScheduleUpdateDto>().ReverseMap();
        CreateMap<EventImage, EventImageDto>();
    }
}
