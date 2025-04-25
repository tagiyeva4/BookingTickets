using BookingTickets.Core.Entities;

namespace BookingTickets.Business.Services.Abstractions
{
    public interface ITicketPdfService
    {
        string GenerateTicketPdf(Ticket ticket);
    }
}
