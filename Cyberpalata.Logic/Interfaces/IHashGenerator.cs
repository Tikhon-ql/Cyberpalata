namespace Cyberpalata.Logic.Interfaces
{
    public interface IHashGenerator
    {
        string HashPassword(string password);
        string GenerateSalt();
    }
}
