namespace Cyberpalata.Common.Intefaces
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}
