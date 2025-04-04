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

        await _repository.UpdateAsync(venue);

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

    public async Task<VenueUpdateDto> GetUpdatedDtoAsync(int id)
    {
        var venue = await _repository.FindOneAsync(x => x.Id == id);
        if (venue == null)
            throw new CustomException(404, "Venue not found");

        return _mapper.Map<VenueUpdateDto>(venue);
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

        // Alphabetic: A, B, ..., Z, AA, AB, etc.
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






//public class VenueService : IVenueService
//{ 
//    private readonly IVenueRepository _repository;
//    private readonly IMapper _mapper;
//    private readonly IVenueSeatRepository _seatRepository;

//    public VenueService(IVenueRepository repository, IMapper mapper)
//    {
//        _repository = repository;
//        _mapper = mapper;
//    }

//    public async Task<bool> CreateAsync(VenueCreateDto dto, ModelStateDictionary ModelState)
//    {
//        if (!ModelState.IsValid)
//        {
//            return false;
//        }

//        var isExist = await _repository.IsExistAsync(x => x.Name == dto.Name);

//        if (isExist)
//        {
//            throw new CustomException("400", "Venue already exist");
//        }

//        var venue=_mapper.Map<Venue>(dto);
//        venue.Capacity = dto.NumberOfRows * dto.SeatsPerRow;

//        await _repository.AddAsync(venue);
//        // Now create seats based on rows and seats per row
//        await CreateVenueSeatsAsync(venue.Id, dto.NumberOfRows, dto.SeatsPerRow, dto.RowNamingStyle);

//        return true;

//    }

//    private async Task CreateVenueSeatsAsync(int venueId, int numberOfRows, int seatsPerRow, RowNamingStyle rowNamingStyle)
//    {
//        List<VenueSeat> seats = new List<VenueSeat>();

//        for (int row = 1; row <= numberOfRows; row++)
//        {
//            string rowName = GetRowName(row, rowNamingStyle);

//            for (int seat = 1; seat <= seatsPerRow; seat++)
//            {
//                var venueSeat = new VenueSeat
//                {
//                    VenueId = venueId,
//                    RowNumber = row,
//                    RowName = rowName,
//                    SeatNumber = seat,
//                    SeatLabel = $"{rowName}{seat}" // Məsələn: A1, B2, C3 və ya 1-1, 2-5
//                };

//                seats.Add(venueSeat);
//            }
//        }

//        // Bulk insert all seats at once for better performance
//        await _seatRepository.AddManyAsync(seats);
//    }

//    private string GetRowName(int rowNumber, RowNamingStyle style)
//    {
//        if (style == RowNamingStyle.Numeric)
//        {
//            return rowNumber.ToString();
//        }
//        else // Alphabetic
//        {
//            // Convert row number to letter (1=A, 2=B, etc.)
//            // For rows beyond 26, use AA, AB, etc.
//            if (rowNumber <= 26)
//            {
//                return ((char)(64 + rowNumber)).ToString(); // ASCII: A=65, so 1+64=65='A'
//            }
//            else
//            {
//                int firstChar = (rowNumber - 1) / 26;
//                int secondChar = (rowNumber - 1) % 26 + 1;
//                return ((char)(64 + firstChar)).ToString() + ((char)(64 + secondChar)).ToString();
//            }
//        }
//    }

//    public async Task DeleteAsync(int id)
//    {
//        var venue=await _repository.FindOneAsync(x=> x.Id == id);

//        if (venue == null)
//        {
//            throw new CustomException(404, "Venue not found");
//        }

//        await _seatRepository.DeleteManyAsync(s => s.VenueId == id);

//        await _repository.DeleteAsync(venue);
//    }

//    public async Task<List<VenueReturnDto>> GetAllAsync()
//    { 
//        var venues=await _repository.GetAllAsync();

//        var dtos=_mapper.Map<List<VenueReturnDto>>(venues);

//        return dtos;
//    }

//    public async Task<VenueReturnDto> GetAsync(int id)
//    {
//        var venue=await _repository.FindOneAsync(x => x.Id == id,"VenueSeat");

//        if (venue == null)
//        {
//            throw new CustomException(404, "Venue not found");
//        }

//        var dto=_mapper.Map<VenueReturnDto>(venue);

//        return dto;
//    }

//    public async Task<VenueUpdateDto> GetUpdatedDtoAsync(int id)
//    {
//        var venue = await _repository.FindOneAsync(x => x.Id == id);

//        if (venue == null)
//        {
//            throw new CustomException(404, "Venue not found");
//        }

//        var dto = _mapper.Map<VenueUpdateDto>(venue);

//        return dto;
//    }

//    public async Task<bool> IsExistAsync(int id)
//    {
//        var isExist = await _repository.IsExistAsync(x => x.Id == id);

//        return isExist;
//    }

//    public async Task<bool> UpdateAsync(VenueUpdateDto dto, ModelStateDictionary ModelState)
//    {
//        if (!ModelState.IsValid)
//        {
//            return false;
//        }

//        var existVenue=await _repository.FindOneAsync(x=>x.Id == dto.Id);

//        if (existVenue == null)
//        {
//            throw new CustomException(404, "Venue not found");
//        }

//        var isExist = await _repository.IsExistAsync(x => x.Id != dto.Id && x.Name == dto.Name);

//        if (isExist)
//        {
//            throw new CustomException("400", "Venue already exist");
//        }

//        existVenue=_mapper.Map(dto,existVenue);

//        await _repository.UpdateAsync(existVenue);

//        return true;
//    }
//}
