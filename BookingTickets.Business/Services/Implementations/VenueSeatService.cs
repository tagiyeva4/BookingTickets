﻿using BookingTickets.Business.Dtos.VenueSeatDto;
using BookingTickets.Business.Services.Abstractions;
using BookingTickets.Core.Entities;
using BookingTickets.DataAccess.Data.Contexts;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BookingTickets.Business.Services.Implementations
{
    public class VenueSeatService(BookingTicketsDbContext _context) : IVenueSeatService
    {
        public async Task AddManyAsync(IEnumerable<VenueSeat> entities)
        {
            await _context.Set<VenueSeat>().AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public Task<bool> CreateAsync(VenueSeatCreateDto dto, ModelStateDictionary ModelState)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<VenueSeatReturnDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<VenueSeatReturnDto> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<VenueSeatUpdateDto> GetUpdatedDtoAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(VenueSeatUpdateDto dto, ModelStateDictionary ModelState)
        {
            throw new NotImplementedException();
        }
    }
}
