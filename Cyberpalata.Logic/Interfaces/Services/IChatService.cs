using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.Logic.Filters;
using Cyberpalata.Logic.Models;

namespace Cyberpalata.Logic.Interfaces.Services
{
    public interface IChatService
    {
        Task CreateChat(ChatDto chat);
        Task<Maybe<ChatDto>> ReadAsync(Guid chatId);
        Task<PagedList<ChatDto>> GetPagedList(ChatFilterBL filter);
        Task<Result> SetIsDeletedState(Guid chatId, bool isDeletedState);
    }
}
