using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Models;
using Cyberpalata.Logic.Models;

namespace Cyberpalata.Logic.Configuration.MapperConfiguration
{
    internal static class ChatMapConfig
    {
        public static void CreateMap(AppMappingProfile profile)
        {
            profile.CreateMap<Chat, ChatDto>();
            profile.CreateMap<ChatDto, Chat>();
            profile.CreateMap<Maybe<ChatDto>, Maybe<Chat>>();
            profile.CreateMap<Maybe<Chat>, Maybe<ChatDto>>();
            profile.CreateMap<PagedList<ChatDto>, PagedList<Chat>>();
            profile.CreateMap<PagedList<Chat>, PagedList<ChatDto>>();
        }
    }
}
