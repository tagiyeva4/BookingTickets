using AutoMapper;
using BookingTickets.Business.Dtos.SliderDtos;
using BookingTickets.Business.Exceptions;
using BookingTickets.Business.Helpers;
using BookingTickets.Business.Services.Abstractions;
using BookingTickets.Core.Entities;
using BookingTickets.DataAccess.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
namespace BookingTickets.Business.Services.Implementations;

public class SliderService : ISliderService
{
    private readonly ISliderRepository _repository;
    private readonly IMapper _mapper;
    private readonly ICloudinaryService _cloudinaryService;
    public SliderService(ISliderRepository repository, IMapper mapper, ICloudinaryService cloudinaryService)
    {
        _repository = repository;
        _mapper = mapper;
        _cloudinaryService = cloudinaryService;
    }

    public async Task<bool> CreateAsync(SliderCreateDto dto, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
        {
            return false;
        }

        if (dto.Photo.CheckSize(5*1024*1024))
        {
            ModelState.AddModelError("Photo", "The size of the image should not exceed 2 MB.");
            return false;
        }

        if (dto.Photo.CheckType(["image/"]))
        {
            ModelState.AddModelError("Photo", "Enter only the image format.");
            return false;
        }

        var slider=_mapper.Map<Slider>(dto);

        var filePath = await _cloudinaryService.FileCreateAsync(dto.Photo);

        slider.Image = filePath;

        await _repository.AddAsync(slider);

        return true;
    }

    public async Task DeleteAsync(int id)
    {
        var slider = await _repository.FindOneAsync(x=>x.Id==id);

        if(slider == null)
        {
            throw new CustomException(404,"Slider not found");
        }

       await _repository.DeleteAsync(slider);

       await _cloudinaryService.FileDeleteAsync(slider.Image);
    }

   public async Task<List<SliderReturnDto>> GetAllAsync()
    {
        var sliders = await _repository.GetAllAsync();

        var dtos=_mapper.Map<List<SliderReturnDto>>(sliders);

        return dtos;
    }

    public async Task<SliderReturnDto> GetAsync(int id)
    {
        var slider=await _repository.FindOneAsync(x=> x.Id==id);

        if (slider == null)
        {
            throw new CustomException(404, "Slider not found");
        }

        var dto=_mapper.Map<SliderReturnDto>(slider);

        return dto;
    }

    public async Task<SliderUpdateDto> GetUpdatedDtoAsync(int id)
    {
        var slider = await _repository.FindOneAsync(x => x.Id == id);

        if (slider == null)
        {
            throw new CustomException(404, "Slider not found");
        }

        var dto=_mapper.Map<SliderUpdateDto>(slider);

        return dto;
    }
    /// <summary>
    /// { } null deyilse demekdir
    /// </summary>
    /// <param name="dto"></param>
    /// <param name="ModelState"></param>
    /// <returns></returns>
    /// <exception cref="CustomException"></exception>
    public async Task<bool> UpdateAsync(SliderUpdateDto dto, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
            return false;

        var existSlider = await _repository.FindOneAsync(x => x.Id ==dto.Id);

        if (existSlider == null)
        {
            throw new CustomException(404, "Slider not found");
        }
        
        if(dto.Photo is { })
        {
            if (dto.Photo.CheckSize(5*1024*1024))
            {
                ModelState.AddModelError("Photo", "The size of the image should not exceed 2 MB.");
                return false;
            }
            if (dto.Photo.CheckType(["image/"]))
            {
                ModelState.AddModelError("Photo", "Enter only the image format.");
                return false;
            }
        }

        existSlider=_mapper.Map(dto,existSlider);

        if(dto.Photo is { })
        {
            await _cloudinaryService.FileDeleteAsync(existSlider.Image);
            string newFilePath = await _cloudinaryService.FileCreateAsync(dto.Photo);
            existSlider.Image = newFilePath;
        }

        await _repository.UpdateAsync(existSlider);

        return true;
    }

}
