using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.IO.Image;
using BookingTickets.Core.Entities;
using Microsoft.AspNetCore.Hosting;
using BookingTickets.Business.Services.Abstractions;
using iText.Kernel.Colors;
using iText.Layout.Properties;

public class TicketPdfService : ITicketPdfService
{
    private readonly IWebHostEnvironment _env;
    private readonly IQRCodeService _qrCodeService;

    public TicketPdfService(IWebHostEnvironment env, IQRCodeService qrCodeService)
    {
        _env = env;
        _qrCodeService = qrCodeService;
    }

    public string GenerateTicketPdfAAA(Ticket ticket)
    {
        var ticketsDir = Path.Combine(_env.WebRootPath, "tickets");
        if (!Directory.Exists(ticketsDir))
            Directory.CreateDirectory(ticketsDir);

        var fileName = $"ticket_{ticket.Id}.pdf";
        var fullPath = Path.Combine(ticketsDir, fileName);

        using var writer = new PdfWriter(fullPath);
        using var pdf = new PdfDocument(writer);
        var doc = new Document(pdf); // warning-free

        var page = pdf.AddNewPage(); // səhifə əlavə olunur
        var canvas = new Canvas(page, pdf.GetDefaultPageSize());

        // 🌈 Background image
        var backgroundPath = Path.Combine(_env.WebRootPath, "imagesticket", "ticket_event_custom_shorter.png");
        if (!File.Exists(backgroundPath))
            throw new FileNotFoundException("Background image not found at: " + backgroundPath);

        var bgImage = new Image(ImageDataFactory.Create(backgroundPath))
            .ScaleToFit(page.GetPageSize().GetWidth(), page.GetPageSize().GetHeight())
            .SetFixedPosition(0, 0);

        canvas.Add(bgImage); // fon şəkli yerləşdirilir

        // ✏️ Text Information
        canvas.SetFontSize(14);
        canvas.SetFontColor(ColorConstants.WHITE);

        float x = 260f;
        float y = 720f;
        float spacing = 25f;

        canvas.ShowTextAligned($"Event: {ticket.Event?.Name ?? "N/A"}", x, y, TextAlignment.LEFT);
        canvas.ShowTextAligned($"Venue: {ticket.Event?.Venue?.Name ?? "N/A"}", x, y - spacing, TextAlignment.LEFT);
        canvas.ShowTextAligned($"Seat: {ticket.VenueSeat?.RowName} - {ticket.VenueSeat?.SeatLabel}", x, y - spacing * 2, TextAlignment.LEFT);
        canvas.ShowTextAligned($"Price: {ticket.Price} AZN", x, y - spacing * 3, TextAlignment.LEFT);
        canvas.ShowTextAligned($"Date: {(ticket.PurchaseDate ?? DateTime.Now):dd MMM yyyy}", x, y - spacing * 4, TextAlignment.LEFT);
        canvas.ShowTextAligned($"Time: {(ticket.PurchaseDate ?? DateTime.Now):HH:mm} - {(ticket.PurchaseDate ?? DateTime.Now).AddHours(2):HH:mm}", x, y - spacing * 5, TextAlignment.LEFT);
        canvas.ShowTextAligned($"Ticket No: #{ticket.Id}", x, y - spacing * 6, TextAlignment.LEFT);

        // 📦 QR Code
        var qrBytes = _qrCodeService.GenerateQRCode(ticket.Id.ToString());
        var qrImage = new Image(ImageDataFactory.Create(qrBytes))
            .ScaleToFit(100, 100)
            .SetFixedPosition(630f, 600f);
        doc.Add(qrImage);

        doc.Close(); // PDF-i tamamla

        return $"/tickets/{fileName}"; // müştəriyə göstərmək üçün public yol
    }

    public string GenerateTicketPdf(Ticket ticket)
    {
        var ticketsDir = Path.Combine(_env.WebRootPath, "tickets");
        if (!Directory.Exists(ticketsDir))
            Directory.CreateDirectory(ticketsDir);

        var fileName = $"ticket_{ticket.Id}.pdf";
        var fullPath = Path.Combine(ticketsDir, fileName);

        using var writer = new PdfWriter(fullPath);
        using var pdf = new PdfDocument(writer);
        var doc = new Document(pdf);

        var page = pdf.AddNewPage();
        var canvas = new Canvas(page, pdf.GetDefaultPageSize());

        // 🌈 1. Background image
        var backgroundPath = Path.Combine(_env.WebRootPath, "imagesticket", "ticket_background_clean_gradient.png");
        if (!File.Exists(backgroundPath))
            throw new FileNotFoundException("Background image not found at: " + backgroundPath);

        var bgImage = new Image(ImageDataFactory.Create(backgroundPath))
            .ScaleToFit(page.GetPageSize().GetWidth(), page.GetPageSize().GetHeight())
            .SetFixedPosition(0, 0);

        canvas.Add(bgImage);

        // ✏️ 2. Text Information
        canvas.SetFontSize(16);
        canvas.SetFontColor(ColorConstants.BLACK); // Ağ fon varsa qara rəng

        float startX = 50f;
        float startY = 620f;
        float lineSpacing = 30f;

        canvas.ShowTextAligned($"Event: {ticket.Event?.Name ?? "N/A"}", startX, startY, TextAlignment.LEFT);
        canvas.ShowTextAligned($"Venue: {ticket.Event?.Venue?.Name ?? "N/A"}", startX, startY - lineSpacing, TextAlignment.LEFT);
        canvas.ShowTextAligned($"Seat: {ticket.VenueSeat?.RowName ?? "N/A"} - {ticket.VenueSeat?.SeatLabel ?? "N/A"}", startX, startY - 2 * lineSpacing, TextAlignment.LEFT);
        canvas.ShowTextAligned($"Price: {ticket.Price} AZN", startX, startY - 3 * lineSpacing, TextAlignment.LEFT);
        canvas.ShowTextAligned($"Date: {(ticket.PurchaseDate ?? DateTime.Now):dd MMM yyyy}", startX, startY - 4 * lineSpacing, TextAlignment.LEFT);
        canvas.ShowTextAligned($"Time: {(ticket.PurchaseDate ?? DateTime.Now):HH:mm} - {(ticket.PurchaseDate ?? DateTime.Now).AddHours(2):HH:mm}", startX, startY - 5 * lineSpacing, TextAlignment.LEFT);
        canvas.ShowTextAligned($"Ticket No: #{ticket.Id}", startX, startY - 6 * lineSpacing, TextAlignment.LEFT);

        // 📦 3. QR Code
        var qrBytes = _qrCodeService.GenerateQRCode(ticket.Id.ToString());
        var qrImage = new Image(ImageDataFactory.Create(qrBytes))
            .ScaleToFit(100, 100)
            .SetFixedPosition(600f, 450f); // Sağ aşağıya qoyduq
        doc.Add(qrImage);

        doc.Close();

        return $"/tickets/{fileName}"; // PDF faylın web yolu
    }



    //public async Task<string> GenerateTicketPdfAsync(Ticket ticket)
    //{
    //    var ticketsDir = Path.Combine(_env.WebRootPath, "tickets");
    //    if (!Directory.Exists(ticketsDir))
    //        Directory.CreateDirectory(ticketsDir);

    //    var fileName = $"ticket_{ticket.Id}.pdf";
    //    var fullPath = Path.Combine(ticketsDir, fileName);

    //    using var writer = new PdfWriter(fullPath);
    //    using var pdf = new PdfDocument(writer);
    //    var doc = new Document(pdf);

    //    doc.Add(new Paragraph("🎟 Ticket Confirmation").SetFontSize(20));
    //    doc.Add(new Paragraph($"Event: {ticket.Event.Name}"));
    //    doc.Add(new Paragraph($"Venue: {ticket.Event.Venue.Name}"));

    //    var seat = ticket.VenueSeat?.RowName + " - " + ticket.VenueSeat?.SeatLabel;
    //    doc.Add(new Paragraph($"Seat: {seat}"));
    //    doc.Add(new Paragraph($"Price: {ticket.Price} AZN"));
    //    doc.Add(new Paragraph("\n"));

    //    // QR Code
    //    var qrBytes = _qrCodeService.GenerateQRCode(ticket.Id.ToString());
    //    var imageData = ImageDataFactory.Create(qrBytes);
    //    var qrImage = new iText.Layout.Element.Image(imageData).ScaleToFit(100, 100);
    //    doc.Add(qrImage);

    //    doc.Close();

    //    return $"/tickets/{fileName}"; // public link to access the file
    //}
}
