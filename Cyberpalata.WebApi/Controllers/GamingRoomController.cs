using CSharpFunctionalExtensions;
using Cyberpalata.Common.Enums;
using Cyberpalata.Common.Intefaces;
using Cyberpalata.Logic.Filters;
using Cyberpalata.Logic.Interfaces.Services;
using Cyberpalata.Logic.Models.Devices;
using Cyberpalata.ViewModel.Request.Room;
using Cyberpalata.ViewModel.Response.Rooms;
using Cyberpalata.ViewModel.Response.Rooms.GamingRoom;
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
        public GamingRoomController(IPcService pcService, IPeripheryService peripheryService, IRoomService roomService, IUnitOfWork uinOfWork) : base(uinOfWork)
        {
            _pcService = pcService;
            _peripheryService = peripheryService;
            _roomService = roomService;
        }

        [HttpGet("getRoomByType")]
        public async Task<IActionResult> GetRoomByType(int page)
        {
            var filter = new RoomFilterBL
            {
                Type = RoomType.GamingRoom,
                IsVip = true,
                PageSize = 5,
                CurrentPage = page
            };

            var rooms = await _roomService.GetPagedListAsync(filter);


            var viewModel = new RoomCollectionViewModel
            {
                Items = rooms.Items.Select(x => new RoomItemViewModel { Id = x.Id.ToString(), Name = x.Name }).ToList(),
                TotalItemsCount = rooms.TotalItemsCount,
                PageSize = rooms.PageSize
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

            var pcInfoList = new List<PcViewModel>();
            var viewModel = new GamingRoomViewModel
            {
                PcInfos= pcInfoList,
                Peripheries = peripheries.Value.Select(p => new PeripheryViewModel(p.Name, p.Type.Name)).ToList(),
            };
            return await ReturnSuccess(viewModel);
        }

        [HttpPost("searchRooms")]
        public async Task<IActionResult> SearchRooms([FromBody]SearchRoomViewModel viewModel)
        {
            var rooms = await _roomService.SearchRooms(viewModel);
            if (rooms.HasNoValue)
                return await ReturnSuccess();
            return await ReturnSuccess(rooms.Value);
        }
    }
}
