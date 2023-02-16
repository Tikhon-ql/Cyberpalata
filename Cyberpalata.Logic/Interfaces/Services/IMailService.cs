namespace Cyberpalata.Logic.Interfaces.Services
{
    public interface IMailService
    {
        Task SendPasswordResetEmail(string emailTo);
        Task SendVerificationCodeToMail(string emailTo,int code);
    }
}
