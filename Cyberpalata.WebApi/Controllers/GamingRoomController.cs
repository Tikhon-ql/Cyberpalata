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
            var rooms = await _roomService.GetPagedListAsync(1, RoomType.GamingRoom);

            var viewModel = new RoomViewModel
            {
                Infos = rooms.Items.Select(x => new RoomListItemInfo { Id = x.Id.ToString(), Name = x.Name }).ToList()
            };
            return await ReturnSuccess(viewModel);
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(Guid id)
        {
            var prices = await _priceService.GetByRoomIdAsync(id);
            var roomsPc = await _pcService.GetByGamingRoomId(id);
            var peripheries = await _peripheryService.GetByGamingRoomId(id);

            var pcInfo = roomsPc.Value;

            var pcInfoList = new List<PcInfo>();
            foreach(var item in pcInfo.GetType().GetProperties())
            {
                if(item.Name != "Id")
                {
                    string type = item.Name;
                    string name = item.GetValue(pcInfo).ToString();
                    pcInfoList.Add(new PcInfo(type, name));
                }             
            }

            var viewModel = new GamingRoomViewModel
            {
                PcInfos = pcInfoList,
                Peripheries = peripheries.Value.Select(p => new Periphery(p.Name, p.Type.Name)).ToList(),
                Prices = prices.Value.Select(p => new Price(p.Hours, p.Cost)).ToList()
            };
            return await ReturnSuccess(viewModel);
        }
    }
}
