using CSharpFunctionalExtensions;
using Cyberpalata.Common.Enums;
using Cyberpalata.Common.Intefaces;
using Cyberpalata.DataProvider.Models;
using Cyberpalata.Logic.Filters;
using Cyberpalata.Logic.Interfaces.Services;
using Cyberpalata.Logic.Models.Devices;
using Cyberpalata.ViewModel.Request.Filters;
using Cyberpalata.ViewModel.Request.Room;
using Cyberpalata.ViewModel.Response.Rooms;
using Cyberpalata.ViewModel.Response.Rooms.GamingRoom;
using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;

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
                PageSize = 10,
                CurrentPage = page
            };

            var rooms = await _roomService.GetPagedListAsync(filter);


            var viewModel = new RoomCollectionViewModel
            {
                Items = rooms.Items.Select(x => new RoomItemViewModel { Id = x.Id.ToString(), Name = x.Name }).ToList(),
                TotalItemsCount = rooms.TotalItemsCount,
                PageSize = rooms.PageSize
            };
            return Ok(new { Items = viewModel.Items, TotalItemsCount = rooms.TotalItemsCount, PageSize = filter.PageSize });
        }

        [HttpPost("getRooms")]
        public async Task<IActionResult> GetRooms([FromBody]RoomFilterViewModel filterViewModel)
        {
            var filter = new RoomFilterBL
            {
                PageSize = 5,
                SearchName = string.IsNullOrWhiteSpace(filterViewModel.SearchName) ? Maybe.None: filterViewModel.SearchName,
                HoursCount = filterViewModel.HoursCount == 0 ? Maybe.None : filterViewModel.HoursCount,
                Begining = !TimeSpan.TryParse(filterViewModel.Begining, out var beg) ? Maybe.None : beg,
                Date = !DateTime.TryParse(filterViewModel.Date, out var date) ? Maybe.None : date,
                CurrentPage = filterViewModel.Page,
                FreeSeatsCount = filterViewModel.FreeSeatsCount == 0 ? Maybe.None : filterViewModel.FreeSeatsCount,
                FreeSeatsInRowCount = filterViewModel.FreeSeatsInRowCount == 0 ? Maybe.None : filterViewModel.FreeSeatsInRowCount,
            };

            var rooms = await _roomService.GetPagedListAsync(filter);
            var viewModel = new RoomCollectionViewModel
            {
                Items = rooms.Items.Select(x => new RoomItemViewModel { Id = x.Id.ToString(), Name = x.Name }).ToList(),
                TotalItemsCount = rooms.TotalItemsCount,
                PageSize = rooms.PageSize
            };
            return Ok(new { Items = viewModel.Items, TotalItemsCount = rooms.TotalItemsCount, PageSize = filter.PageSize });
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
