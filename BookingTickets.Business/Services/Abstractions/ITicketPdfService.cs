using BookingTickets.Core.Entities;

namespace BookingTickets.Business.Services.Abstractions;

public interface ITicketPdfService
{
    string GenerateTicketPdf(Ticket ticket);
    List<string> GenerateMultipleTicketPdfs(List<Ticket> tickets);
    string GenerateTicketsZip(List<Ticket> tickets);
}
