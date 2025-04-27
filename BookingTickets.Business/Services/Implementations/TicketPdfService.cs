using BookingTickets.Business.Services.Abstractions;
using BookingTickets.Core.Entities;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.AspNetCore.Hosting;
using System.IO.Compression;

public class TicketPdfService:ITicketPdfService
{
    private readonly IWebHostEnvironment _env;
    private readonly IQRCodeService _qrCodeService;

    public TicketPdfService(IWebHostEnvironment env, IQRCodeService qrCodeService)
    {
        _env = env;
        _qrCodeService = qrCodeService;
    }

    public string GenerateTicketPdf(Ticket ticket)
    {
        var ticketsDir = Path.Combine(_env.WebRootPath, "tickets");
        if (!Directory.Exists(ticketsDir))
            Directory.CreateDirectory(ticketsDir);

        var fileName = $"ticket_{ticket.VenueSeat?.SeatLabel ?? "Unknown"}_{ticket.Id}.pdf";
        var fullPath = Path.Combine(ticketsDir, fileName);

        using var writer = new PdfWriter(fullPath);
        using var pdf = new PdfDocument(writer);
        var page = pdf.AddNewPage();
        var pageSize = page.GetPageSize();
        var doc = new Document(pdf);
        var canvas = new Canvas(page, pageSize);

        var backgroundPath = Path.Combine(_env.WebRootPath, "imagesticket", "ticket-background.png");

        if (!File.Exists(backgroundPath))
            throw new FileNotFoundException("Background image not found at: " + backgroundPath);

        var bgImage = new Image(ImageDataFactory.Create(backgroundPath))
    .ScaleToFit(pageSize.GetWidth(), pageSize.GetHeight() * 0.8f) 
    .SetFixedPosition(0, pageSize.GetHeight() * 0.15f); 
        canvas.Add(bgImage);

        canvas.SetFontSize(14);
        canvas.SetFontColor(ColorConstants.WHITE);

        float centerX = pageSize.GetWidth() / 2;
        float startY = pageSize.GetHeight() / 2 + 50f; ;
        float spacing = 25f;

        canvas.ShowTextAligned(
            $"Event: {ticket.Event?.Name ?? "N/A"}",
            centerX,
            startY + spacing * 2,
            TextAlignment.CENTER);

        canvas.ShowTextAligned(
            $"Venue: {ticket.Event?.Venue?.Name ?? "N/A"}",
            centerX,
            startY + spacing,
            TextAlignment.CENTER);

        canvas.ShowTextAligned(
            $"Seat: {ticket.VenueSeat?.RowName ?? "?"} - {ticket.VenueSeat?.SeatLabel ?? "?"}",
            centerX,
            startY,
            TextAlignment.CENTER);

        canvas.ShowTextAligned(
            $"Price: {ticket.Price} AZN",
            centerX,
            startY - spacing,
            TextAlignment.CENTER);

        canvas.ShowTextAligned(
            $"Date: {(ticket.Schedule?.Date.ToString("dd MMM yyyy") ?? "N/A")}",
            centerX,
            startY - spacing * 2,
            TextAlignment.CENTER);

        canvas.ShowTextAligned(
            $"Time: {(ticket.Schedule != null ? $"{ticket.Schedule.StartTime:hh\\:mm} - {ticket.Schedule.EndTime:hh\\:mm}" : "N/A")}",
            centerX,
            startY - spacing * 3,
            TextAlignment.CENTER);

        canvas.ShowTextAligned(
            $"Ticket No: #{ticket.Id}",
            centerX,
            startY - spacing * 4,
            TextAlignment.CENTER);

        canvas.Close();

        var qrContent = ticket.ValidationToken;
        var qrBytes = _qrCodeService.GenerateQRCode(qrContent);

        var qrImage = new Image(ImageDataFactory.Create(qrBytes))
            .ScaleToFit(100, 100)
            .SetFixedPosition(pageSize.GetWidth() - 120f, 150f);

        doc.Add(qrImage);

        doc.Close();

        return $"/tickets/{fileName}";
    }

    public List<string> GenerateMultipleTicketPdfs(List<Ticket> tickets)
    {
        var paths = new List<string>();

        foreach (var ticket in tickets)
        {
            var path = GenerateTicketPdf(ticket);
            paths.Add(path);
        }

        return paths;
    }

    public string GenerateTicketsZip(List<Ticket> tickets)
    {
        var paths = GenerateMultipleTicketPdfs(tickets);

        var zipFileName = $"tickets_{Guid.NewGuid()}.zip";
        var zipPath = Path.Combine(_env.WebRootPath, "tickets", zipFileName);

        using (var zipArchive = ZipFile.Open(zipPath, ZipArchiveMode.Create))
        {
            foreach (var relativePath in paths)
            {
                var fullPath = Path.Combine(_env.WebRootPath, relativePath.TrimStart('/'));
                zipArchive.CreateEntryFromFile(fullPath, Path.GetFileName(fullPath));
            }
        }

        return $"/tickets/{zipFileName}";
    }
}

