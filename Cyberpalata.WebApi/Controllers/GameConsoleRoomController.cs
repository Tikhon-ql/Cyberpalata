using Cyberpalata.Common.Intefaces;
using Cyberpalata.Logic.Interfaces;
using Cyberpalata.Logic.Interfaces.Room;
using Cyberpalata.ViewModel.Rooms;
using Cyberpalata.ViewModel.Rooms.GameConsoleRoom;
using Cyberpalata.ViewModel.Rooms.GamingRoom;
using Microsoft.AspNetCore.Mvc;

namespace Cyberpalata.WebApi.Controllers
{
    [ApiController]
    [Route("/gameConsoleRoom")]
    public class GameConsoleRoomController : BaseController
    {
        private readonly IGameConsoleRoomService _gameConsoleRoomService;

        private readonly IGameConsoleService _gameConsoleService;
        private readonly IPriceService _priceService;

        public GameConsoleRoomController(IGameConsoleRoomService gameConsoleRoomService, IGameConsoleService gameConsoleService,IPriceService priceService,IUnitOfWork uinOfWork) : base(uinOfWork)
        {
            _gameConsoleRoomService = gameConsoleRoomService;
            _gameConsoleService = gameConsoleService;
            _priceService = priceService;
        }

        //[HttpGet]
        //public async Task<IActionResult> Get()
        //{
        //    var viewModel = new GameConsoleViewModel
        //    {
        //        GameConsoles = _gameConsoleService.GetPagedListAsync(1).Result.Items.Select(i => i.ConsoleName).ToList(),
        //        Prices = _priceService.GetPagedListAsync(1).Result.Items.Select(p => new Price(p.Hours, p.Cost)).ToList()
        //    };
        //    return ReturnSuccess(viewModel);
        //}

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //read all 
            var infos = await _gameConsoleRoomService.GetRoomNameWithIdAsync();

            var viewModel = new GameConsoleRoomsViewModel
            {
                Infos = infos.Select(x => new GameConsoleRoomInfo {Id = x.Item1,Name = x.Item2}).ToList()
            };
            return ReturnSuccess(viewModel);
        }


        [HttpGet("id")]
        public async Task<IActionResult> Get(Guid id)
        {
            var roomDto = await _gameConsoleRoomService.ReadAsync(id);
            var viewModel = new GameConsoleRoomViewModel
            {
                GameConsoles = roomDto.Consoles.Select(c => c.ConsoleName).ToList(),
                Prices = roomDto.Prices.Select(p => new Price(p.Hours, p.Cost)).ToList(),
            };
            return ReturnSuccess(viewModel);
        }
    }
}
