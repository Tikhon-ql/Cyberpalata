﻿using Cyberpalata.Common;
using Cyberpalata.Logic.Filters;
using Cyberpalata.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Interfaces.Services
{
    public interface IChatService
    {
        Task CreateChat(ChatDto chat);
        Task<Maybe<ChatDto>> ReadAsync(Guid chatId);
        Task<PagedList<ChatDto>> GetPagedList(ChatFilterBL filter);
    }
}
