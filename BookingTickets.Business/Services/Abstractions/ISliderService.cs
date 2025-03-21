using BookingTickets.Business.Dtos.SliderDtos;
using BookingTickets.Business.Services.Abstractions.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingTickets.Business.Services.Abstractions
{
   public interface ISliderService: IService<SliderCreateDto, SliderUpdateDto,SliderReturnDto>
    {
    }
}
