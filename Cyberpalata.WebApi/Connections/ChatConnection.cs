using Cyberpalata.Logic.Models;
using Cyberpalata.Logic.Models.Identity;
using Cyberpalata.ViewModel.Request.Identities;

namespace Cyberpalata.WebApi.Connections
{
    public class ChatConnection
    {
        public UserChatViewModel User { get; set; }
        public Guid ChatId { get; set; }
    }
}
