﻿using AutoMapper;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Filters;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models;
using Cyberpalata.Logic.Filters;
using Cyberpalata.Logic.Interfaces.Services;
using Cyberpalata.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Services
{
    internal class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepository;
        private readonly IMapper _mapper;

        public ChatService(IChatRepository chatRepository, IMapper mapper)
        {
            _chatRepository = chatRepository;
            _mapper = mapper;
        }

        public async Task CreateChat(ChatDto chat)
        {
            await _chatRepository.CreateAsync(_mapper.Map<Chat>(chat));
        }

        public async Task<PagedList<ChatDto>> GetPagedList(ChatFilterBL filter)
        {
            var list = await _chatRepository.GetPageListAsync(_mapper.Map<ChatFilter>(filter));
            return _mapper.Map<PagedList<ChatDto>>(list);
        }
    }
}
