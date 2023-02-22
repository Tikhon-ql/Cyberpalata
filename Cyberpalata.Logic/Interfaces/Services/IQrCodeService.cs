using Cyberpalata.Logic.Models.QrCode;

namespace Cyberpalata.Logic.Interfaces.Services
{
    public interface IQrCodeService
    {
        byte[] TeamRegistrationQrCodeGeneration(TeamRegistrationQrCodeModel model);
    }
}
