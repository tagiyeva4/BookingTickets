using BookingTickets.DataAccess.Data.Contexts;
using BookingTickets.DataAccess.Repositories.Abstractions;
using BookingTickets.DataAccess.Repositories.Abstractions.Generic;
using BookingTickets.DataAccess.Repositories.Implementations.Generic;

namespace BookingTickets.DataAccess.Repositories.Implementations;

public class PaymentRepository : Repository<Payment>, IPaymentRepository
{
    public PaymentRepository(BookingTicketsDbContext dbContext) : base(dbContext)
    {
    }
}
