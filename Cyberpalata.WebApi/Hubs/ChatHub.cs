using Cyberpalata.Common.Intefaces;
using Cyberpalata.DataProvider.Models;
using Cyberpalata.DataProvider.Models.Identity;
using Cyberpalata.Logic.Interfaces.Services;
using Cyberpalata.ViewModel.Request;
using Cyberpalata.WebApi.Connections;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Cyberpalata.WebApi.Hubs
{
    public class ChatHub : Hub
    {
        private readonly string _botUser;
        private readonly IDictionary<string, ChatConnection> _connections;
        private readonly IMessageService _messageService;
        private readonly ILogger<ChatHub> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public ChatHub(IDictionary<string, ChatConnection> connections, IMessageService messageService, ILogger<ChatHub> logger, IUnitOfWork unitOfWork)
        {
            _botUser = "Chat bot";
            _connections = connections;
            _messageService = messageService;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        //[Authorize]
        public override Task OnDisconnectedAsync(Exception? exception)
        {
            if (_connections.TryGetValue(Context.ConnectionId, out ChatConnection connection))
            {               
                _connections.Remove(Context.ConnectionId);
            }
            return base.OnDisconnectedAsync(exception);
        }
        //[Authorize]
        public async Task SendMessage(MessageViewModel viewModel)
        {
            if(_connections.TryGetValue(Context.ConnectionId, out ChatConnection connection))
            {
                _logger.LogCritical(viewModel.ChatId.ToString());
                _logger.LogCritical(viewModel.Sender);
                _logger.LogCritical(connection.User.Email);
                _logger.LogCritical(viewModel.Message);
               
                await _messageService.CreateAsync(viewModel);
                await Clients.Group(connection.ChatId.ToString()).SendAsync("ReceiveMessage", $"{connection.User.Email}", viewModel.Message);
                await _unitOfWork.CommitAsync();
            }
        }
        //[Authorize]
        public async Task JoinRoom(ChatConnection connection)
        {       
            await Groups.AddToGroupAsync(Context.ConnectionId, connection.ChatId.ToString());
            _connections[Context.ConnectionId] = connection;
        }
    }
}