using QRCoder;

namespace BookingTickets.Business.Services
{
    public class QrCodeService
    {
        //public string GenerateQRCode(int ticketId)
        //{
        //    // Unikal token yarat
        //    string token = Guid.NewGuid().ToString();

        //    // Bilet üçün təsdiqləmə URL-i yaradaraq tokeni istifadə edirik
        //    string validationUrl = $"https://mysite.com/validate/{token}";

        //    using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
        //    using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(validationUrl, QRCodeGenerator.ECCLevel.Q))
        //    using (QRCode qrCode = new QRCode(qrCodeData))
        //    {
        //        Bitmap qrBitmap = qrCode.GetGraphic(20);
        //        string filePath = $"wwwroot/qrcodes/ticket_{ticketId}.png";
        //        qrBitmap.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);

        //        return $"/qrcodes/ticket_{ticketId}.png";
        //    }
        //}

        //public string GenerateQRCode(string validationUrl, int ticketId)
        //{
        //    using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
        //    {
        //        QRCodeData qrCodeData = qrGenerator.CreateQrCode(validationUrl, QRCodeGenerator.ECCLevel.Q);
        //        using (QRCode qrCode = new QRCode(qrCodeData))
        //        {
        //            Bitmap qrBitmap = qrCode.GetGraphic(20);
        //            string filePath = $"wwwroot/qrcodes/ticket_{ticketId}.png";
        //            qrBitmap.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
        //            return $"/qrcodes/ticket_{ticketId}.png";
        //        }
        //    }
        //}

    }
}
