using BookingTickets.Business.Services.Abstractions;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

public class EmailService : IEmailService
{
    public void SendEmail(string to, string subject, string body)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse("tagizadeaysu002@gmail.com"));
        email.To.Add(MailboxAddress.Parse(to));
        email.Subject = subject;
        email.Body = new TextPart(TextFormat.Html) { Text = body };

        using var smtp = new SmtpClient();
        smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
        smtp.Authenticate("aysuht@code.edu.az", "wtyp bnlh undx jstn");
        smtp.Send(email);
        smtp.Disconnect(true);
    }

    public async Task SendEmailWithAttachmentAsync(string to, string subject, string htmlBody, string attachmentPath)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse("tagizadeaysu002@gmail.com"));
        email.To.Add(MailboxAddress.Parse(to));
        email.Subject = subject;

        var builder = new BodyBuilder
        {
            HtmlBody = htmlBody
        };

        if (File.Exists(attachmentPath))
        {
            builder.Attachments.Add(attachmentPath);
        }

        email.Body = builder.ToMessageBody();

        using var smtp = new SmtpClient();
        await smtp.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
        await smtp.AuthenticateAsync("aysuht@code.edu.az", "wtyp bnlh undx jstn");
        await smtp.SendAsync(email);
        await smtp.DisconnectAsync(true);
    }
}
