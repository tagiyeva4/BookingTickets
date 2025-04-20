using AutoMapper;
using BookingTickets.Business.Dtos.SubscriberEmailDtos;
using BookingTickets.Business.Exceptions;
using BookingTickets.Business.Services.Abstractions;
using BookingTickets.Core.Entities;
using BookingTickets.DataAccess.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BookingTickets.Business.Services.Implementations;

public class SubscriberService:ISubscriberService
{
    private readonly ISubscriberRepository _repository;
    private readonly IMapper _mapper;
     public SubscriberService(ISubscriberRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<bool> CreateAsync(SubscriberCreateDto dto, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
        {
            return false;
        }
        var isExist = await _repository.IsExistAsync(x=>x.Email.ToUpper()==dto.Email.ToUpper());
        if (isExist)
        {
            ModelState.AddModelError("Email", "This email already exists");
            return false;
        }

        var subscriber = _mapper.Map<SubscribeEmail>(dto);
        await _repository.AddAsync(subscriber);

        return true;
    }

    public async Task DeleteAsync(int id)
    {
        var subscriber = await _repository.FindOneAsync(x=>x.Id==id);
        if (subscriber is null)
        {
            throw new CustomException(404,"Subscriber not found");
        }
        await _repository.DeleteAsync(subscriber);

    }

    public async Task<List<SubscriberReturnDto>> GetAllAsync()
    {
        var subscribers = await _repository.GetAllAsync();
        var subscriberDtos = _mapper.Map<List<SubscriberReturnDto>>(subscribers);
        return subscriberDtos;
    }

    public async Task<SubscriberReturnDto> GetAsync(int id)
    {
        var subscriber = await _repository.FindOneAsync(x => x.Id == id);
        if (subscriber is null)
        {
            throw new CustomException(404, "Subscriber not found");
        }
        var subscriberDto = _mapper.Map<SubscriberReturnDto>(subscriber);
        return subscriberDto;
    }

    public async Task<SubscriberUpdateDto> GetUpdatedDtoAsync(int id)
    {
        var subscriber = await _repository.FindOneAsync(x => x.Id == id);

        if (subscriber is null)
        {
            throw new CustomException(404, "Subscriber not found");
        }
        var subscriberDto = _mapper.Map<SubscriberUpdateDto>(subscriber);
        return subscriberDto;
    }

    public async Task<bool> UpdateAsync(SubscriberUpdateDto dto, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
        {
            return false;
        }

        var existSubscriber = await _repository.FindOneAsync(x => x.Id == dto.Id);

        if (existSubscriber is null)
        {
            throw new CustomException(404, "Subscriber not found");
        }

        var isExist = await _repository.IsExistAsync(x => x.Email.ToUpper() == dto.Email.ToUpper() && x.Id != dto.Id);

        if (isExist)
        {
            ModelState.AddModelError("Email", "This email already exists");
            return false;
        }

        existSubscriber=_mapper.Map(dto,existSubscriber);

       await _repository.UpdateAsync(existSubscriber);

        return true;

    }
}
