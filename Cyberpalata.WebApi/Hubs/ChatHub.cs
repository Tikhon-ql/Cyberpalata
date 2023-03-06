using Microsoft.AspNetCore.SignalR;

namespace Cyberpalata.WebApi.Hubs
{
    public class ChatHub : Hub
    {
        private readonly string _botUser;

        public ChatHub()
        {
            _botUser = "Chat bot";
        }

        public async Task JoinRoom(UserConnection connection)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, connection.ChatId.ToString());
            await Clients.Group(connection.ChatId.ToString()).SendAsync("ReceiveMessage",_botUser,$"{connection.User.Name} {connection.User.Surname} has joined chat");
        }
    }
}
