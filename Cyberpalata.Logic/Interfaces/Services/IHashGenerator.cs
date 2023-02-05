namespace Cyberpalata.Logic.Interfaces.Services
{
    public interface IHashGenerator
    {
        string HashPassword(string password);
        string GenerateSalt();
    }
}
