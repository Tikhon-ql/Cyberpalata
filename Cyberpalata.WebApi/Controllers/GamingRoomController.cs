using CSharpFunctionalExtensions;
using Cyberpalata.Common.Enums;
using Cyberpalata.Common.Intefaces;
using Cyberpalata.Logic.Interfaces.Services;
using Cyberpalata.Logic.Models.Devices;
using Cyberpalata.Logic.Models.Room;
using Cyberpalata.ViewModel.Rooms;
using Cyberpalata.ViewModel.Rooms.GamingRoom;
using Cyberpalata.WebApi.ActionFilters;
using Microsoft.AspNetCore.Mvc;

namespace Cyberpalata.WebApi.Controllers
{
    [ApiController]
    [Route("/gamingRooms")]
    public class GamingRoomController : BaseController
    {
        private readonly IPcService _pcService;
        private readonly IPeripheryService _peripheryService;
        private readonly IRoomService _roomService;
        private readonly ILogger<GamingRoomController> _logger;
        public GamingRoomController(IPcService pcService, IPeripheryService peripheryService, IRoomService roomService, IUnitOfWork uinOfWork,ILogger<GamingRoomController> logger) : base(uinOfWork)
        {
            _pcService = pcService;
            _peripheryService = peripheryService;
            _roomService = roomService;
            _logger = logger;
        }

        [HttpGet("getRoomByType")]
        public async Task<IActionResult> GetRoomByType(string type)
        {
            if (type != "vip" && type != "common")
                return BadRequest("Bad type query parametr");

            var rooms = type == "vip"
                ? await _roomService.GetVipRoomsAsync(1, RoomType.GamingRoom)
                : await _roomService.GetCommonRoomsAsync(1, RoomType.GamingRoom);

            var viewModel = new RoomViewModel
            {
                Infos = rooms.Items.Select(x => new RoomListItemInfo { Id = x.Id.ToString(), Name = x.Name }).ToList()
            };
            return await ReturnSuccess(viewModel);
        }
        [HttpGet("getRoomInfo")]
        public async Task<IActionResult> GetRoomInfo(Guid id)
        {
            var peripheries = await _peripheryService.GetByGamingRoomId(id);
            var roomsPc = await _pcService.GetByGamingRoomId(id);

            var pcInfo = default(PcDto);

            if (roomsPc.HasValue)
                pcInfo = roomsPc.Value;        

            var pcInfoList = new List<PcInfo>();
            //foreach (var item in pcInfo.GetType().GetProperties())
            //{
            //    if (item.Name != "Id")
            //    {
            //        string type = item.Name;
            //        string name = item.GetValue(pcInfo).ToString();
            //        pcInfoList.Add(new PcInfo(type, name));
            //    }
            //}
            var viewModel = new GamingRoomViewModel
            {
                PcInfos= pcInfoList,
                Peripheries = peripheries.Value.Select(p => new Periphery(p.Name, p.Type.Name)).ToList(),
            };
            return await ReturnSuccess(viewModel);
        }

        [HttpPost("searchRooms")]
        [ServiceFilter(typeof(ModelStateValidationFilter))]
        public async Task<IActionResult> SearchRooms([FromBody]SearchRoomRequest request)
        {
            var rooms = await _roomService.SearchRooms(request);
            if (rooms.HasNoValue)
                return await ReturnSuccess();
            return await ReturnSuccess(rooms.Value);
        }
    }
}
