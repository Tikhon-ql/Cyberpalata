using Cyberpalata.DataProvider.Models;

namespace Cyberpalata.Logic.Configuration.MapperConfiguration
{
    internal static class MessageMapConfig
    {
        public static void CreateMap(AppMappingProfile profile)
        {
            profile.CreateMap<Message, MessageDto>();
            profile.CreateMap<MessageDto, Message>();
        }
    }
}
