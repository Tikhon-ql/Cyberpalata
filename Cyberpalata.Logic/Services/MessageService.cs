﻿using AutoMapper;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models;
using Cyberpalata.Logic.Filters;
using Cyberpalata.Logic.Interfaces.Services;
using Cyberpalata.ViewModel.Request;

namespace Cyberpalata.Logic.Services
{
    internal class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IChatRepository _chatRepository;
        private readonly IUserRepository _userRepository;

        public MessageService(IMessageRepository messageRepository,IChatRepository chatRepository,IUserRepository userRepository)
        {
            _messageRepository = messageRepository;
            _chatRepository = chatRepository;
            _userRepository = userRepository;
        }

        public async Task CreateAsync(MessageViewModel message)
        {
            var chat = await _chatRepository.ReadAsync(message.ChatId);
            var user = await _userRepository.ReadAsync(message.Sender);
            var newMessage = new Message
            {
                Chat = chat.Value,
                MessageText = message.Message,
                SentDate = DateTime.UtcNow,
                Sender = user.Value
            };

            await _messageRepository.CreateAsync(newMessage);
        }
    }
}
