using AutoMapper;
using BookingTickets.Business.Dtos.EventDtos;
using BookingTickets.Business.Dtos.VenueSeatDto;
using BookingTickets.Core.Entities;

namespace BookingTickets.Business.AutoMappers;

internal class EventAutoMapper:Profile
{
    public EventAutoMapper()
    {

        CreateMap<Event,EventCreateDto>()
            .ForMember(x=>x.EventLanguageIds,x=>x.MapFrom(x=>x.EventLanguages.Select(x=>x.LanguageId)))
            .ForMember(x => x.EventPersonIds, x => x.MapFrom(x => x.EventPersons.Select(x => x.PersonId)))
            .ReverseMap();

        CreateMap<Event, EventUpdateDto>()
         .ForMember(dest => dest.NewImage, opt => opt.Ignore());

        CreateMap<EventUpdateDto, Event>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.EventImages, opt => opt.Ignore());
        

        CreateMap<Event, EventReturnDto>()
          .ForMember(dest => dest.EventLanguages, opt => opt.MapFrom(src => src.EventLanguages.Select(el => new LanguageDtoInEvent
          {
              Id = el.LanguageId,
              Name = el.Language.Name
          }).ToList()))
          .ForMember(dest => dest.EventPersons, opt => opt.MapFrom(src => src.EventPersons.Select(ep => new PersonDtoInEvent
          {
              Id = ep.PersonId,
              FullName = ep.Person.FullName
          }).ToList()))
          .ForMember(dest => dest.Schedules, opt => opt.MapFrom(src => src.EventsSchedules.Select(es => new ScheduleDtoInEvent
          {
              Date = es.Schedule.Date,
              StartTime = es.Schedule.StartTime,
              EndTime = es.Schedule.EndTime
          }).ToList()))
          .ForMember(dest => dest.EventImages, opt => opt.MapFrom(src => src.EventImages.Select(ei => ei.ImagePath).ToList()))
          .ForMember(dest => dest.Venue, opt => opt.MapFrom(src => new VenueDtoInEvent
          {
              Id = src.Venue.Id,
              Name = src.Venue.Name
          }));


        CreateMap<Person, PersonDtoInEvent>().ReverseMap();
        CreateMap<Language, LanguageDtoInEvent>().ReverseMap();
        CreateMap<Schedule, ScheduleDtoInEvent>().ReverseMap();
        CreateMap<Schedule,ScheduleDto>().ReverseMap();
        CreateMap<VenueSeat, VenueSeatUpdateDto>().ReverseMap();
    }
}
