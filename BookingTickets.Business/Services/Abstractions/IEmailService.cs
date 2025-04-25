namespace BookingTickets.Business.Services.Abstractions;

public interface IEmailService
{
    void SendEmail(string to, string subject, string body);
    Task SendEmailWithAttachmentAsync(string to, string subject, string htmlBody, string attachmentPath);
}
