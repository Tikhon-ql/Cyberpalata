using Cyberpalata.DataProvider.Models;
using Cyberpalata.DataProvider.Models.Identity;
using Cyberpalata.Logic.Interfaces.Services;
using Cyberpalata.ViewModel.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Cyberpalata.WebApi.Hubs
{
    public class ChatHub : Hub
    {
        private readonly string _botUser;
        private readonly IDictionary<string, UserConnection> _connections;
        private readonly IMessageService _messageService;

        public ChatHub(IDictionary<string, UserConnection> connections, IMessageService messageService)
        {
            _botUser = "Chat bot";
            _connections = connections;
            _messageService = messageService;
        }
        //[Authorize]
        public override Task OnDisconnectedAsync(Exception? exception)
        {
            if (_connections.TryGetValue(Context.ConnectionId, out UserConnection connection))
            {
                _connections.Remove(Context.ConnectionId);

                Clients.Group(connection.ChatId.ToString()).SendAsync("ReceiveMessage", _botUser, $"{connection.User.Email} has left chat");
            }
            return base.OnDisconnectedAsync(exception);
        }
        //[Authorize]
        public async Task SendMessage(string message)
        {
            if(_connections.TryGetValue(Context.ConnectionId, out UserConnection connection))
            {
                var viewModel = new MessageViewModel
                {
                    ChatId = connection.ChatId,
                    Sender = connection.User.Email,
                    MessageText = message
                };
                await _messageService.CreateAsync(viewModel);
                await Clients.Group(connection.ChatId.ToString()).SendAsync("ReceiveMessage",$"{connection.User.Email}",message);
            }
        }
        //[Authorize]
        public async Task JoinRoom(UserConnection connection)
        {
            
            await Groups.AddToGroupAsync(Context.ConnectionId, connection.ChatId.ToString());

            _connections[Context.ConnectionId] = connection;

            await Clients.Group(connection.ChatId.ToString()).SendAsync("ReceiveMessage",_botUser,$"{connection.User.Email} has joined chat");
        }
    }
}