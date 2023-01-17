﻿using Cyberpalata.Common.Enums;
using Cyberpalata.Common.Intefaces;
using Cyberpalata.Logic.Interfaces;
using Cyberpalata.ViewModel.Rooms;
using Cyberpalata.ViewModel.Rooms.GameConsoleRoom;
using Cyberpalata.ViewModel.Rooms.GamingRoom;
using Cyberpalata.ViewModel.Rooms;
using Microsoft.AspNetCore.Mvc;

namespace Cyberpalata.WebApi.Controllers
{
    [ApiController]
    [Route("/gameConsoleRoom")]
    public class GameConsoleRoomController : BaseController
    {
        private readonly IRoomService _gameConsoleRoomService;

        private readonly IGameConsoleService _gameConsoleService;
        private readonly IPriceService _priceService;

        public GameConsoleRoomController(IRoomService gameConsoleRoomService, IGameConsoleService gameConsoleService, IPriceService priceService, IUnitOfWork uinOfWork) : base(uinOfWork)
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
            var infos = (await _gameConsoleRoomService.GetPagedListAsync(1,RoomType.GameConsoleRoom)).Items;

            var viewModel = new RoomViewModel
            {
                Infos = infos.Select(x => new RoomListItemInfo { Id = x.Value.Id.ToString(), Name = x.Value.Name }).ToList()
            };
            return await ReturnSuccess(viewModel);
        }


        [HttpGet("id")]
        public async Task<IActionResult> Get(Guid id)
        {
            var prices = await _priceService.GetByRoomIdAsync(id);
            var consoles = await _gameConsoleService.GetByGameConsoleRoomId(id);
            var viewModel = new GameConsoleRoomViewModel
            {
                GameConsoles = consoles.Select(c => c.Value.ConsoleName).ToList(),
                Prices = prices.Select(p => new Price(p.Value.Hours, p.Value.Cost)).ToList(),
            };
            return await ReturnSuccess(viewModel);
        }
    }
}