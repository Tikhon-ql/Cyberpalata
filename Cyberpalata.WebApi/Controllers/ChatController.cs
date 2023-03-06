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

        public ChatController(IUnitOfWork uinOfWork,IChatService chatService) : base(uinOfWork)
        {
            _chatService = chatService;
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
    }
}
