using AutoMapper;
using BookingTickets.Business.Dtos.SubscriberEmailDtos;
using BookingTickets.Core.Entities;

namespace BookingTickets.Business.AutoMappers;

internal class SubscriberAutoMapper: Profile
{
    public SubscriberAutoMapper()
    {
        CreateMap<SubscriberCreateDto, SubscribeEmail>().ReverseMap();
        CreateMap<SubscribeEmail, SubscriberReturnDto>().ReverseMap();
        CreateMap<SubscriberUpdateDto, SubscribeEmail>().ReverseMap();
    }
}
