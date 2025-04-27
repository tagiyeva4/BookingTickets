namespace BookingTickets.Business.Services.Abstractions;

public interface IQRCodeService
{
    byte[] GenerateQRCode(string content);
}
