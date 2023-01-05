using Cyberpalata.Common.Intefaces;
using Cyberpalata.Logic.Interfaces;
using Cyberpalata.ViewModel.Rooms;
using Cyberpalata.ViewModel.Rooms.GameConsoleRoom;
using Cyberpalata.ViewModel.Rooms.GamingRoom;
using Microsoft.AspNetCore.Mvc;

namespace Cyberpalata.WebApi.Controllers
{
    //[ApiController]
    //[Route("/gameConsoleRoom")]
    //public class GameConsoleRoomController : BaseController
    //{
    //    private readonly IRoomService _gameConsoleRoomService;

    //    private readonly IGameConsoleService _gameConsoleService;
    //    private readonly IPriceService _priceService;

    //    public GameConsoleRoomController(IRoomService gameConsoleRoomService, IGameConsoleService gameConsoleService,IPriceService priceService,IUnitOfWork uinOfWork) : base(uinOfWork)
    //    {
    //        _gameConsoleRoomService = gameConsoleRoomService;
    //        _gameConsoleService = gameConsoleService;
    //        _priceService = priceService;
    //    }

    //    //[HttpGet]
    //    //public async Task<IActionResult> Get()
    //    //{
    //    //    var viewModel = new GameConsoleViewModel
    //    //    {
    //    //        GameConsoles = _gameConsoleService.GetPagedListAsync(1).Result.Items.Select(i => i.ConsoleName).ToList(),
    //    //        Prices = _priceService.GetPagedListAsync(1).Result.Items.Select(p => new Price(p.Hours, p.Cost)).ToList()
    //    //    };
    //    //    return ReturnSuccess(viewModel);
    //    //}

    //    [HttpGet]
    //    public async Task<IActionResult> Get()
    //    {
    //        //read all 
    //        var infos = (await _gameConsoleRoomService.GetPagedListAsync(1)).Items;

    //        var viewModel = new GameConsoleRoomsViewModel
    //        {
    //            Infos = infos.Select(x => new GameConsoleRoomInfo {Id = x.Id.ToString(),Name = x.Name}).ToList()
    //        };
    //        return ReturnSuccess(viewModel);
    //    }


    //    [HttpGet("id")]
    //    public async Task<IActionResult> Get(Guid id)
    //    {
    //        var prices = await _priceService.GetByRoomIdAsync(id);
    //        var consoles = await _gameConsoleService.GetByGameConsoleRoomId(id);
    //        var viewModel = new GameConsoleRoomViewModel
    //        {
    //            GameConsoles = consoles.Select(c => c.ConsoleName).ToList(),
    //            Prices = prices.Select(p => new Price(p.Hours, p.Cost)).ToList(),
    //        };
    //        return ReturnSuccess(viewModel);
    //    }
    //}
}
