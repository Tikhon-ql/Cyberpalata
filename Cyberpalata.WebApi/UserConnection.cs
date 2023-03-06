using Cyberpalata.Logic.Models;
using Cyberpalata.Logic.Models.Identity;
using Cyberpalata.ViewModel.Request.Identities;

namespace Cyberpalata.WebApi
{
    public class UserConnection
    {
        public UserChatViewModel User { get; set; }
        public Guid ChatId { get; set; }
    }
}
