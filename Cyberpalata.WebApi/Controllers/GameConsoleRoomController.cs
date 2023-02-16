using Cyberpalata.Common.Enums;
using Cyberpalata.Common.Intefaces;
using Cyberpalata.Logic.Interfaces.Services;
using Cyberpalata.ViewModel.Response.Rooms;
using Cyberpalata.ViewModel.Response.Rooms.GameConsoleRoom;
using Microsoft.AspNetCore.Mvc;

namespace Cyberpalata.WebApi.Controllers
{
    [ApiController]
    [Route("/gameConsoleRoom")]
    public class GameConsoleRoomController : BaseController
    {
        private readonly IRoomService _gameConsoleRoomService;

        private readonly IGameConsoleService _gameConsoleService;
        private readonly ILogger<GameConsoleRoomController> _logger;

        public GameConsoleRoomController(IRoomService gameConsoleRoomService, IGameConsoleService gameConsoleService, IUnitOfWork uinOfWork, ILogger<GameConsoleRoomController> logger) : base(uinOfWork)
        {
            _gameConsoleRoomService = gameConsoleRoomService;
            _gameConsoleService = gameConsoleService;
            _logger = logger;
        }

        //[HttpGet]
        //public async Task<IActionResult> Get()
        //{
        //    var filter = new Roo
        //    var infos = (await _gameConsoleRoomService.GetPagedListAsync(1,RoomType.GameConsoleRoom)).Items;

        //    var viewModel = new RoomCollectionViewModel
        //    {
        //        Infos = infos.Select(x => new RoomItemViewModel { Id = x.Id.ToString(), Name = x.Name }).ToList()
        //    };
        //    return await ReturnSuccess(viewModel);
        //}

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
