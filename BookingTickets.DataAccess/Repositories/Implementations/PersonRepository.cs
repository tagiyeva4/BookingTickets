using BookingTickets.DataAccess.Data.Contexts;
using BookingTickets.DataAccess.Repositories.Abstractions;
using BookingTickets.DataAccess.Repositories.Implementations.Generic;

namespace BookingTickets.DataAccess.Repositories.Implementations;

public class PersonRepository: Repository<Person>, IPersonRepository
{
    public PersonRepository(BookingTicketsDbContext dbContext) : base(dbContext)
    {
    }
}
