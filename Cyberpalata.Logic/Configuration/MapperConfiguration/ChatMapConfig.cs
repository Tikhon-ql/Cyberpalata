using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Models;
using Cyberpalata.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
