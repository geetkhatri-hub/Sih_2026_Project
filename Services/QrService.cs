using QRCoder;
namespace SIH_2026.Services;

public interface IQrService 
{
    byte[] GenerateQrCode(string payload);
}
public class QrService : IQrService
    {
    public byte[] GenerateQrCode(string payload)
    {
        using var qrGenerator = new QRCodeGenerator();
        using var qrData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
        using var qrCode = new PngByteQRCode(qrData);
        return qrCode.GetGraphic(20);

    }
    }

