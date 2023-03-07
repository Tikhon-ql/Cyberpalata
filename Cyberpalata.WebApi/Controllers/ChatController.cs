using Cyberpalata.Common.Intefaces;
using Cyberpalata.Logic.Filters;
using Cyberpalata.Logic.Interfaces.Services;
using Cyberpalata.ViewModel.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;

namespace Cyberpalata.WebApi.Controllers
{
    [ApiController]
    [Route("/chats")]
    public class ChatController : BaseController
    {
        private readonly IChatService _chatService;
        private readonly IMessageService _messageService;

        public ChatController(IUnitOfWork uinOfWork,IChatService chatService, IMessageService messageService) : base(uinOfWork)
        {
            _chatService = chatService;
            _messageService = messageService;
        }

        [Authorize]
        [HttpGet("getChatList")]
        public async Task<IActionResult> GetChatList(int page)
        {
            var userId = Guid.Parse(User.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.Sid).Value);

            var filter = new ChatFilterBL
            {
                CurrentPage = page,
                PageSize = 5,
                UserId = userId,
            };
            var chatsResult = await _chatService.GetPagedList(filter);
            var viewModel = new List<ChatViewModel>();
            foreach(var chat in chatsResult.Items)
            {
                viewModel.Add(new ChatViewModel
                {
                    ChatId = chat.Id,
                    OtherUserName = chat.Captain.Id == userId ? chat.UserToJoin.Username : chat.Captain.Username,
                    OtherUserSurname = chat.Captain.Id == userId ? chat.UserToJoin.Surname : chat.Captain.Surname,
                });
            }
            return Ok(new { PageSize = chatsResult.PageSize, TotalItemsCount = chatsResult.TotalItemsCount, Items = viewModel });
        }

        [Authorize]
        [HttpGet("getMessages")]
        public async Task<IActionResult> GetMessages()
        {
            var userId = Guid.Parse(User.Claims.First(claim=>claim.Type == JwtRegisteredClaimNames.Sid).Value);

            return null;
            //var filter = new MessageFilterBL
            //{
            //    CurrentPage = 1,
            //    PageSize = int.MaxValue,
            //    UserId = userId
            //};
            //var result = await _messageService.GetPagedList(filter);
            //return Ok(result);
        }
    }
}
