using BookingTickets.Business.Dtos;
using BookingTickets.Business.Dtos.SliderDtos;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BookingTickets.Business.Services.Abstractions.Generic
{
    public interface IService<TCreateDto, TUpdateDto,TReturnDto>
    where TCreateDto : IDto
    where TUpdateDto : IDto
    where TReturnDto : IDto
    {
        /// <summary>
        /// TCreateDto və TUpdateDto yalnız IDto interfeysindən törəmiş (implement edən) obyektlər ola bilər
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="ModelState"></param>
        /// <returns></returns>
        Task<bool> CreateAsync(TCreateDto dto, ModelStateDictionary ModelState);
        Task<bool> UpdateAsync(TUpdateDto dto, ModelStateDictionary ModelState);
        Task<TUpdateDto> GetUpdatedDtoAsync(int id);
        Task<List<SliderReturnDto>> GetAllAsync();
        Task<SliderReturnDto> GetAsync(int id);
        Task DeleteAsync(int id);
    }
}
