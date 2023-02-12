namespace Cyberpalata.Logic.Interfaces.Services
{
    public interface IMailService
    {
        void SendPasswordResetEmail(string emailTo);
        void SendVerificationCodeToMail(string emailTo,int code);
    }
}
