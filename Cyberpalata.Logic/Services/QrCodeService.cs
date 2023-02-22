using Cyberpalata.Logic.Interfaces.Services;
using Cyberpalata.Logic.Models.QrCode;
using QRCoder;
using static QRCoder.PayloadGenerator;

namespace Cyberpalata.Logic.Services
{
    public class QrCodeService : IQrCodeService
    {
        public byte[] TeamRegistrationQrCodeGeneration(TeamRegistrationQrCodeModel model)
        {
            var webUrl = new Url($"{model.Url}");
            string urlPayload = webUrl.ToString();
            var qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(urlPayload, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new BitmapByteQRCode(qrCodeData);
            var bytes = qrCode.GetGraphic(40);
            return bytes;
        }
    }
}
