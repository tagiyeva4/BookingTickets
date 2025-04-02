using BookingTickets.Core.Entities;
using iText.Bouncycastleconnector;
using iText.IO.Image;
using iText.Kernel.Pdf;
using Microsoft.AspNetCore.Hosting;
using QRCoder;
using Document = iText.Layout.Document;
using Paragraph = iText.Layout.Element.Paragraph;



namespace BookingTickets.Business.Services
{
    public class QrCodeService
    {
        private readonly IWebHostEnvironment _env;

        public QrCodeService(IWebHostEnvironment env)
        {
            _env = env;
        }

        //public string GenerateTicketPDF(int ticketId)
        //{
        //    // Unikal token yarat
        //    string token = Guid.NewGuid().ToString();
        //    string validationUrl = $"https://mysite.com/validate/{token}";

        //    // QR kod generatoru
        //    var qrGenerator = new QRCodeGenerator();
        //    var qrCodeData = qrGenerator.CreateQrCode(validationUrl, QRCodeGenerator.ECCLevel.Q);
        //    var qrCode = new PngByteQRCode(qrCodeData);
        //    byte[] qrCodeBytes = qrCode.GetGraphic(20);

        //    // wwwroot içində qovluqların yeri
        //    string qrFolderPath = Path.Combine(_env.WebRootPath, "qrcodes");
        //    string pdfFolderPath = Path.Combine(_env.WebRootPath, "tickets");

        //    Directory.CreateDirectory(qrFolderPath);
        //    Directory.CreateDirectory(pdfFolderPath);

        //    // QR kod faylının tam yolu
        //    string qrPath = Path.Combine(qrFolderPath, $"ticket_{ticketId}.png");
        //    File.WriteAllBytes(qrPath, qrCodeBytes);

        //    // PDF faylının tam yolu
        //    string pdfPath = Path.Combine(pdfFolderPath, $"ticket_{ticketId}.pdf");

        //    // PDF yarat və QR kodu əlavə et
        //    using (var pdfWriter = new PdfWriter(pdfPath))
        //    using (var pdfDocument = new PdfDocument(pdfWriter))
        //    {
        //        var document = new Document(pdfDocument);
        //        document.Add(new Paragraph($"Ticket ID: {ticketId}"));
        //        document.Add(new Paragraph("Scan the QR code to validate your ticket:"));

        //        // QR kod şəklini PDF-ə əlavə et
        //        iText.Layout.Element.Image qrImage = new iText.Layout.Element.Image(ImageDataFactory.Create(qrCodeBytes));
        //        document.Add(qrImage);
        //    }

        //    return $"/tickets/ticket_{ticketId}.pdf";
        //}
        public string GenerateTicketPDF(Ticket ticket)
        {

            // Unikal token yarat
            ticket.ValidationToken = Guid.NewGuid().ToString();
            string validationUrl = $"https://mysite.com/validate/{ticket.ValidationToken}";

            // QR kod generatoru
            var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(validationUrl, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new PngByteQRCode(qrCodeData);
            byte[] qrCodeBytes = qrCode.GetGraphic(20);

            // Fayl yolları
            string qrFolderPath = Path.Combine(_env.WebRootPath, "qrcodes");
            string pdfFolderPath = Path.Combine(_env.WebRootPath, "tickets");

            // Əgər qovluq yoxdursa, yarat
            if (!Directory.Exists(qrFolderPath))
            {
                Directory.CreateDirectory(qrFolderPath);
            }
            if (!Directory.Exists(pdfFolderPath))
            {
                Directory.CreateDirectory(pdfFolderPath);
            }

            // QR kod faylını yadda saxla
            ticket.QRCodePath = Path.Combine("qrcodes", $"ticket_{ticket.Id}.png");
            var qrPath = Path.Combine(_env.WebRootPath, ticket.QRCodePath);
            File.WriteAllBytes(qrPath, qrCodeBytes);

            // PDF faylını yadda saxla
            string pdfPath = Path.Combine(pdfFolderPath, $"ticket_{ticket.Id}.pdf");

            using (var pdfWriter = new PdfWriter(pdfPath))
            using (var pdfDocument = new PdfDocument(pdfWriter))
            {
                var document = new Document(pdfDocument);
                document.Add(new Paragraph($"Ticket ID: {ticket.Id}"));
                document.Add(new Paragraph("Scan the QR code to validate your ticket:"));

                // QR kod şəkilini PDF-ə əlavə et
                iText.Layout.Element.Image qrImage = new iText.Layout.Element.Image(ImageDataFactory.Create(qrCodeBytes));
                document.Add(qrImage);
            }

            return $"/tickets/ticket_{ticket.Id}.pdf";
        }
    }
}
