using Cyberpalata.DataProvider.Models;
using Microsoft.AspNetCore.SignalR;

namespace Cyberpalata.WebApi.Hubs
{
    public class ChatHub : Hub
    {
        private readonly string _botUser;
        private readonly IDictionary<string, UserConnection> _connections;

        public ChatHub(IDictionary<string, UserConnection> connections)
        {
            _botUser = "Chat bot";
            _connections = connections;
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            if (_connections.TryGetValue(Context.ConnectionId, out UserConnection connection))
            {
                _connections.Remove(Context.ConnectionId);

                Clients.Group(connection.ChatId.ToString()).SendAsync("ReceiveMessage", _botUser, $"{connection.User.Name} ${connection.User.Surname} has left chat");
            }
            return base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(string message)
        {
            if(_connections.TryGetValue(Context.ConnectionId, out UserConnection connection))
            {
                await Clients.Group(connection.ChatId.ToString()).SendAsync("ReceiveMessage",$"{connection.User.Name} ${connection.User.Surname}",message);
            }
        }
        
        public async Task JoinRoom(UserConnection connection)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, connection.ChatId.ToString());

            _connections[Context.ConnectionId] = connection;

            await Clients.Group(connection.ChatId.ToString()).SendAsync("ReceiveMessage",_botUser,$"{connection.User.Name} {connection.User.Surname} has joined chat");
        }
    }
}
