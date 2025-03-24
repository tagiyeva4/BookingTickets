using AutoMapper;
using BookingTickets.Business.Dtos.VenueDtos;
using BookingTickets.Business.Exceptions;
using BookingTickets.Business.Services.Abstractions;
using BookingTickets.Core.Entities;
using BookingTickets.DataAccess.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BookingTickets.Business.Services.Implementations;

public class VenueService : IVenueService
{ 
    private IVenueRepository _repository;
    private readonly IMapper _mapper;

    public VenueService(IVenueRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<bool> CreateAsync(VenueCreateDto dto, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
        {
            return false;
        }

        var isExist = await _repository.IsExistAsync(x => x.Name == dto.Name);

        if (isExist)
        {
            throw new CustomException("400", "Venue already exist");
        }
         
        var venue=_mapper.Map<Venue>(dto);

        await _repository.AddAsync(venue);

        return true;
       
    }

    public async Task DeleteAsync(int id)
    {
        var venue=await _repository.FindOneAsync(x=> x.Id == id);

        if (venue == null)
        {
            throw new CustomException(404, "Venue not found");
        }

        await _repository.DeleteAsync(venue);
    }

    public async Task<List<VenueReturnDto>> GetAllAsync()
    { 
        var venues=await _repository.GetAllAsync();

        var dtos=_mapper.Map<List<VenueReturnDto>>(venues);

        return dtos;
    }

    public async Task<VenueReturnDto> GetAsync(int id)
    {
        var venue=await _repository.FindOneAsync(x => x.Id == id);

        if (venue == null)
        {
            throw new CustomException(404, "Venue not found");
        }

        var dto=_mapper.Map<VenueReturnDto>(venue);

        return dto;
    }

    public async Task<VenueUpdateDto> GetUpdatedDtoAsync(int id)
    {
        var venue = await _repository.FindOneAsync(x => x.Id == id);

        if (venue == null)
        {
            throw new CustomException(404, "Venue not found");
        }

        var dto = _mapper.Map<VenueUpdateDto>(venue);

        return dto;
    }

    public async Task<bool> IsExistAsync(int id)
    {
        var isExist = await _repository.IsExistAsync(x => x.Id == id);

        return isExist;
    }

    public async Task<bool> UpdateAsync(VenueUpdateDto dto, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
        {
            return false;
        }

        var existVenue=await _repository.FindOneAsync(x=>x.Id == dto.Id);

        if (existVenue == null)
        {
            throw new CustomException(404, "Venue not found");
        }

        var isExist = await _repository.IsExistAsync(x => x.Id != dto.Id && x.Name == dto.Name);

        if (isExist)
        {
            throw new CustomException("400", "Venue already exist");
        }

        existVenue=_mapper.Map(dto,existVenue);

        await _repository.UpdateAsync(existVenue);

        return true;
    }
}
