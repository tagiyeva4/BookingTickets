using BookingTickets.Business.Services.Abstractions;
using QRCoder;


public class QRCodeService : IQRCodeService
{
    public byte[] GenerateQRCode(string content)
    {
        var qrGenerator = new QRCodeGenerator();
        var qrData = qrGenerator.CreateQrCode(content, QRCodeGenerator.ECCLevel.Q);
        var pngQrCode = new PngByteQRCode(qrData);
        return pngQrCode.GetGraphic(20); 
    }
}
