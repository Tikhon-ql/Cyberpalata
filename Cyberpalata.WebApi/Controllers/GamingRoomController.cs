using CSharpFunctionalExtensions;
using Cyberpalata.Common.Enums;
using Cyberpalata.Common.Intefaces;
using Cyberpalata.Logic.Interfaces;
using Cyberpalata.Logic.Models;
using Cyberpalata.Logic.Models.Devices;
using Cyberpalata.ViewModel.Rooms;
using Cyberpalata.ViewModel.Rooms.GamingRoom;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

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
        private readonly ILogger<GamingRoomController> _logger;
        public GamingRoomController(IPcService pcService, IPeripheryService peripheryService, IPriceService priceService, IRoomService roomService, IUnitOfWork uinOfWork,ILogger<GamingRoomController> logger) : base(uinOfWork)
        {
            _pcService = pcService;
            _peripheryService = peripheryService;
            _priceService = priceService;
            _roomService = roomService;
            _logger = logger;
        }

        [HttpGet("type")]
        public async Task<IActionResult> Get(string type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest($"Bad request: {ModelState.ToString()}");
            }

            if (type != "vip" && type != "common")
                return BadRequest("Bad type query parametr");

            var rooms = type == "vip"
                ? await _roomService.GetVipRoomsAsync(1, RoomType.GamingRoom)
                : await _roomService.GetCommonRoomsAsync(1, RoomType.GamingRoom);
            //var rooms = await _roomService.GetPagedListAsync(1, RoomType.GamingRoom);

            // should i pretend to get vip rologoms with type lounge?
            var viewModel = new RoomViewModel
            {
                Infos = rooms.Items.Select(x => new RoomListItemInfo { Id = x.Id.ToString(), Name = x.Name }).ToList()
            };
            return await ReturnSuccess(viewModel);
        }
        [HttpGet("getRoomInfo")]
        public async Task<IActionResult> GetRoomInfo(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest($"Bad request: {ModelState.ToString()}");
            }
            var prices = await _priceService.GetByRoomIdAsync(id);   
            var peripheries = await _peripheryService.GetByGamingRoomId(id);
            var roomsPc = await _pcService.GetByGamingRoomId(id);
            //var seats = await _roomService.GetRoomFreeSeats(id);

            var pcInfo = default(PcDto);

            if (roomsPc.HasValue)
                pcInfo = roomsPc.Value;        

            var pcInfoList = new List<PcInfo>();
            foreach (var item in pcInfo.GetType().GetProperties())
            {
                if (item.Name != "Id")
                {
                    string type = item.Name;
                    string name = item.GetValue(pcInfo).ToString();
                    pcInfoList.Add(new PcInfo(type, name));
                }
            }
            var viewModel = new GamingRoomViewModel
            {
                PcInfos= pcInfoList,
                Peripheries = peripheries.Value.Select(p => new Periphery(p.Name, p.Type.Name)).ToList(),
                Prices = prices.Value.Select(p => new PriceViewModel(p.Hours, p.Cost)).ToList(),
            };
            return await ReturnSuccess(viewModel);
        }
    }
}
