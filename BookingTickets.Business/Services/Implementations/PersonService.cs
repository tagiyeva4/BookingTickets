using AutoMapper;
using BookingTickets.Business.Dtos.PersonDtos;
using BookingTickets.Business.Exceptions;
using BookingTickets.Business.Helpers;
using BookingTickets.Business.Services.Abstractions;
using BookingTickets.Core.Entities;
using BookingTickets.DataAccess.Data.Contexts;
using BookingTickets.DataAccess.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BookingTickets.Business.Services.Implementations;

public class PersonService : IPersonService
{
    private readonly IPersonRepository _repository;
    private readonly IMapper _mapper;
    private readonly ICloudinaryService _cloudinaryService;
    private readonly BookingTicketsDbContext _dbContext;
    public PersonService(IPersonRepository repository, IMapper mapper, ICloudinaryService cloudinaryService, BookingTicketsDbContext dbContext)
    {
        _repository = repository;
        _mapper = mapper;
        _cloudinaryService = cloudinaryService;
        _dbContext = dbContext;
    }

    public async Task<bool> CreateAsync(PersonCreateDto dto, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
        {
            return false;
        }

        if (!_dbContext.Professions.Any(x => x.Id == dto.ProfessionId))
        {
            ModelState.AddModelError("ProfessionId", "There is no profession in this id..."); 
            return false;
        }

        if (dto.Photo.CheckSize(5 * 1024 * 1024))
        {
            ModelState.AddModelError("Photo", "The size of the image should not exceed 2 MB.");
            return false;
        }

        if (dto.Photo.CheckType(["image/"]))
        {
            ModelState.AddModelError("Photo", "Enter only the image format.");
            return false;
        }

        var isExist = await _repository.IsExistAsync(x => x.FullName == dto.FullName);
       
        if (isExist)
        {
            throw new CustomException("400", "Already exist in this name");
        }

        var person = _mapper.Map<Person>(dto);

        var filePath = await _cloudinaryService.FileCreateAsync(dto.Photo);

        person.ImageUrl = filePath;

        await _repository.AddAsync(person);

        return true;
    }

    public async Task DeleteAsync(int id)
    {
       var person = await _repository.FindOneAsync(x => x.Id == id, "ProfessioN");
       
        if (person == null)
        {
            throw new CustomException(404, "Person not found");
        }
        
        await _repository.DeleteAsync(person);
        
        await _cloudinaryService.FileDeleteAsync(person.ImageUrl);
    }

    public async Task<List<PersonReturnDto>> GetAllAsync()
    {
       var people = await _repository.GetAllAsync("Profession");

        return _mapper.Map<List<PersonReturnDto>>(people);
    }

    public async Task<PersonReturnDto> GetAsync(int id)
    {
        var person = await _repository.FindOneAsync(x => x.Id == id, "Profession");
       
        if (person == null)
        {
            throw new CustomException(404, "Person not found");
        }
        
        return _mapper.Map<PersonReturnDto>(person);
    }

    public async Task<PersonUpdateDto> GetUpdatedDtoAsync(int id)
    {
       var person = await _repository.FindOneAsync(x => x.Id == id, "Profession");
       
        if (person == null)
        {
            throw new CustomException(404, "Person not found");
        }
      
        var dto = _mapper.Map<PersonUpdateDto>(person);
        
        return dto;
    }

    public async Task<bool> IsExistAsync(int id)
    {
        var isExist = await _repository.IsExistAsync(x => x.Id == id);

        return isExist;
    }

    public async Task<bool> UpdateAsync(PersonUpdateDto dto, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
            return false;
        
        var existPerson = await _repository.FindOneAsync(x => x.Id == dto.Id, "Profession");
        
        if (existPerson == null)
        {
            throw new CustomException(404, "Person not found");
        }

        var isExist = await _repository.IsExistAsync(x => x.Id != dto.Id && x.FullName == dto.FullName);

        if (isExist)
        {
            throw new CustomException("400", "Event already exist");
        }

        if (dto.Photo is { })
        {
            if (dto.Photo.CheckSize(5 * 1024 * 1024))
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

        existPerson = _mapper.Map(dto, existPerson);
        
        if (dto.Photo is { })
        {
            await _cloudinaryService.FileDeleteAsync(existPerson.ImageUrl);
            string newFilePath = await _cloudinaryService.FileCreateAsync(dto.Photo);
            existPerson.ImageUrl = newFilePath;
        }

        await _repository.UpdateAsync(existPerson);

        return true;
    }
}
