using CSharpFunctionalExtensions;

namespace Cyberpalata.Logic.Interfaces.Services
{
    public interface ITeamMemberService
    {
        Task<Result> AddJoinRequest(Guid teamId, Guid userId);
    }
}
