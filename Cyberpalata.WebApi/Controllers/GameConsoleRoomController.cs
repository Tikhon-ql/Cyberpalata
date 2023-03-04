using Cyberpalata.Common.Intefaces;
using Cyberpalata.Logic.Interfaces.Services;
using Cyberpalata.ViewModel.Response.Rooms.GameConsoleRoom;
using Microsoft.AspNetCore.Mvc;

namespace Cyberpalata.WebApi.Controllers
{
    [ApiController]
    [Route("/gameConsoleRoom")]
    public class GameConsoleRoomController : BaseController
    {

        private readonly IGameConsoleService _gameConsoleService;
        public GameConsoleRoomController(IGameConsoleService gameConsoleService, IUnitOfWork uinOfWork) : base(uinOfWork)
        {
            _gameConsoleService = gameConsoleService;
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(Guid id)
        {
            var consoles = await _gameConsoleService.GetByGameConsoleRoomId(id);
            var viewModel = new GameConsoleRoomViewModel
            {
                GameConsoles = consoles.Value.Select(c => c.ConsoleName).ToList(),
            };
            return await ReturnSuccess(viewModel);
        }
    }
}
