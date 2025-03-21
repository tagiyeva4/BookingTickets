using AutoMapper;
using BookingTickets.Business.Dtos.SliderDtos;
using BookingTickets.Core.Entities;

namespace BookingTickets.Business.AutoMappers
{
   public class SliderAutoMapper:Profile
    {
        public SliderAutoMapper()
        {
            CreateMap<Slider, SliderCreateDto>().ReverseMap();
            CreateMap<Slider, SliderUpdateDto>().ReverseMap().ForMember(x => x.Image, x => x.Ignore());
            CreateMap< Slider, SliderReturnDto>();
        }
    }
}
