using AutoMapper;
using BookingTickets.Business.Dtos.EventScheduleDtos;
using BookingTickets.Core.Entities;

namespace BookingTickets.Business.AutoMappers;

public class EventScheduleAutoMapper:Profile
{
    public EventScheduleAutoMapper()
    {
        CreateMap<EventsSchedule, EventScheduleCreateDto>().ReverseMap();
        CreateMap<EventsSchedule, EventScheduleUpdateDto>().ReverseMap();
        CreateMap<EventsSchedule, EventScheduleReturnDto>().ReverseMap();
    }
}
