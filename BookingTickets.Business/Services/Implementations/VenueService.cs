using AutoMapper;
using BookingTickets.Business.Dtos.VenueDtos;
using BookingTickets.Business.Exceptions;
using BookingTickets.Business.Services.Abstractions;
using BookingTickets.Core.Entities;
using BookingTickets.Core.Enums;
using BookingTickets.DataAccess.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BookingTickets.Business.Services.Implementations;

public class VenueService : IVenueService
{
    private readonly IVenueRepository _repository;
    private readonly IMapper _mapper;
    private readonly IVenueSeatRepository _seatRepository;

    public VenueService(IVenueRepository repository, IVenueSeatRepository seatRepository, IMapper mapper)
    {
        _repository = repository;
        _seatRepository = seatRepository;
        _mapper = mapper;
    }

    public async Task<bool> CreateAsync(VenueCreateDto dto, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
            return false;

        var isExist = await _repository.IsExistAsync(x => x.Name == dto.Name);
        if (isExist)
            throw new CustomException("400", "Venue already exists");

        var venue = _mapper.Map<Venue>(dto);
        venue.Capacity = dto.NumberOfRows * dto.SeatsPerRow;

        await _repository.AddAsync(venue);

        await CreateVenueSeatsAsync(venue.Id, dto.NumberOfRows, dto.SeatsPerRow, dto.RowNamingStyle);

        return true;
    }

    public async Task DeleteAsync(int id)
    {
        var venue = await _repository.FindOneAsync(x => x.Id == id);
        if (venue == null)
            throw new CustomException(404, "Venue not found");

        await _seatRepository.DeleteManyAsync(x => x.VenueId == id);
        await _repository.DeleteAsync(venue);
    }

    public async Task<List<VenueReturnDto>> GetAllAsync()
    {
        var venues = await _repository.GetAllAsync();
        return _mapper.Map<List<VenueReturnDto>>(venues);
    }

    public async Task<VenueReturnDto> GetAsync(int id)
    {
        var venue = await _repository.FindOneAsync(x => x.Id == id, "Seats");
        if (venue == null)
            throw new CustomException(404, "Venue not found");

        return _mapper.Map<VenueReturnDto>(venue);
    }

    public async Task<bool> UpdateAsync(VenueUpdateDto dto, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
            return false;

        var venue = await _repository.FindOneAsync(x => x.Id == dto.Id);
        if (venue == null)
            throw new CustomException(404, "Venue not found");

        var isExist = await _repository.IsExistAsync(x => x.Id != dto.Id && x.Name == dto.Name);
        if (isExist)
            throw new CustomException("400", "Another venue with the same name already exists");

        
        _mapper.Map(dto, venue);

       
        venue.Capacity = dto.NumberOfRows * dto.SeatsPerRow;

       
        await _repository.UpdateAsync(venue);

        
        await _repository.DeleteAllAsync<VenueSeat>(s => s.VenueId == venue.Id);

        
        var seats = new List<VenueSeat>();
        for (int i = 1; i <= dto.NumberOfRows; i++)
        {
            string rowName = dto.RowNamingStyle == RowNamingStyle.Alphabetic ?
                ((char)(64 + i)).ToString() : i.ToString();

            for (int j = 1; j <= dto.SeatsPerRow; j++)
            {
                seats.Add(new VenueSeat
                {
                    RowNumber = i,
                    RowName = rowName,
                    SeatNumber = j,
                    SeatLabel = dto.RowNamingStyle == RowNamingStyle.Alphabetic ?
                        $"{rowName}{j}" : $"{i}-{j}",
                    VenueId = venue.Id
                });
            }
        }

        await _seatRepository.AddManyAsync(seats);

        return true;
    }

    public async Task<VenueUpdateDto> GetUpdatedDtoAsync(int id)
    {
        
        var venue = await _repository.FindOneAsync(x => x.Id == id, "Seats");

        if (venue == null)
            throw new CustomException(404, "Venue not found");

       
        var dto = _mapper.Map<VenueUpdateDto>(venue);

        
        if (venue.Seats != null && venue.Seats.Any())
        {
            dto.NumberOfRows = venue.Seats.Max(s => s.RowNumber);
            dto.SeatsPerRow = venue.Seats.Count / dto.NumberOfRows;

            var firstRowSeat = venue.Seats.FirstOrDefault(s => s.RowNumber == 1);
            if (firstRowSeat != null && !string.IsNullOrEmpty(firstRowSeat.RowName))
            {
                dto.RowNamingStyle = char.IsLetter(firstRowSeat.RowName[0]) ?
                    RowNamingStyle.Alphabetic : RowNamingStyle.Numeric;
            }
        }
        else
        {
           
            dto.NumberOfRows = 10;
            dto.SeatsPerRow = 15;
            dto.RowNamingStyle = RowNamingStyle.Numeric;
        }

        return dto;
    }

    public async Task<bool> IsExistAsync(int id)
    {
        return await _repository.IsExistAsync(x => x.Id == id);
    }

    private async Task CreateVenueSeatsAsync(int venueId, int numberOfRows, int seatsPerRow, RowNamingStyle style)
    {
        var seats = new List<VenueSeat>();

        for (int row = 1; row <= numberOfRows; row++)
        {
            string rowName = GetRowName(row, style);

            for (int seat = 1; seat <= seatsPerRow; seat++)
            {
                seats.Add(new VenueSeat
                {
                    VenueId = venueId,
                    RowNumber = row,
                    RowName = rowName,
                    SeatNumber = seat,
                    SeatLabel = $"{rowName}{seat}"
                });
            }
        }

        if (seats.Any())
            await _seatRepository.AddManyAsync(seats);
    }

    private string GetRowName(int rowNumber, RowNamingStyle style)
    {
        if (style == RowNamingStyle.Numeric)
        {
            return rowNumber.ToString();
        }

        rowNumber--;
        var name = "";
        while (rowNumber >= 0)
        {
            name = (char)('A' + rowNumber % 26) + name;
            rowNumber = rowNumber / 26 - 1;
        }
        return name;
    }
}

