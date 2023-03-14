using Cyberpalata.Common.Intefaces;
using Cyberpalata.Logic.Interfaces.Services;
using Cyberpalata.ViewModel.Request.Identities;
using Cyberpalata.WebApi.Hubs;

namespace Cyberpalata.WebApi.Connections
{
    public class NotificationViewModel
    {
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }
        public string User { get; set; }
        public Guid Connection { get; set; }
    }
}
