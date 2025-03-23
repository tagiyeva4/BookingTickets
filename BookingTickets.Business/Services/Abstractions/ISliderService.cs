using BookingTickets.Business.Dtos.SliderDtos;
using BookingTickets.Business.Services.Abstractions.Generic;

namespace BookingTickets.Business.Services.Abstractions;

public interface ISliderService: IService<SliderCreateDto, SliderUpdateDto,SliderReturnDto>
{
}
