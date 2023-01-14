using Cyberpalata.Common.Enums;
using Cyberpalata.Common.Intefaces;
using Cyberpalata.Logic.Interfaces;
using Cyberpalata.ViewModel.Rooms;
using Cyberpalata.ViewModel.Rooms.GamingRoom;
using Microsoft.AspNetCore.Mvc;

namespace Cyberpalata.WebApi.Controllers
{
    [ApiController]
    [Route("/gamingRooms")]
    public class GamingRoomController : BaseController
    {
        private readonly IPcService _pcService;
        private readonly IPeripheryService _peripheryService;
        private readonly IPriceService _priceService;
        private readonly IRoomService _roomService;
        public GamingRoomController(IPcService pcService, IPeripheryService peripheryService, IPriceService priceService,IRoomService roomService, IUnitOfWork uinOfWork) : base(uinOfWork)
        {
            _pcService = pcService;
            _peripheryService = peripheryService;
            _priceService = priceService;
            _roomService = roomService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var infos = (await _roomService.GetPagedListAsync(1, RoomType.GamingRoom)).Items;

            var viewModel = new RoomViewModel
            {
                Infos = infos.Select(x => new RoomListItemInfo { Id = x.Id.ToString(), Name = x.Name }).ToList()
            };
            return await ReturnSuccess(viewModel);
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(Guid id)
        {
            var prices = await _priceService.GetByRoomIdAsync(id);
            var pc = await _pcService.GetByGamingRoomId(id);
            var peripheries = await _peripheryService.GetByGamingRoomId(id);

            var viewModel = new GamingRoomViewModel
            {
                PcInfo = new PcInfo(pc.Gpu, pc.Cpu, pc.Ram, pc.Hdd, pc.Ssd),
                Peripheries = peripheries.Select(p => new Periphery(p.Name, p.Type.Name)).ToList(),
                Prices = prices.Select(p => new Price(p.Hours, p.Cost)).ToList()
            };
            return await ReturnSuccess(viewModel);
        }
    }
}
