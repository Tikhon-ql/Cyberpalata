using Cyberpalata.WebApi.Connections;
using Microsoft.AspNetCore.SignalR;

namespace Cyberpalata.WebApi.Hubs
{

    public class NotificationHub : Hub
    {
        private readonly IDictionary<string, NotificationViewModel> _connections;
        public NotificationHub(IDictionary<string, NotificationViewModel> connections)
        {
            _connections = connections;
        }

        public NotificationHub() { }
        public async Task SendNotification(NotificationViewModel notification)
        {
            if(_connections.TryGetValue(Context.ConnectionId, out var connection))
            {
                await Clients.Group(connection.Connection.ToString()).SendAsync("ReceiveMessage", $"", notification.User);
            }
        }
    }
}
