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
    public class RoomController : BaseController
    {
        private readonly IPcService _pcService;
        private readonly IPeripheryService _peripheryService;
        private readonly IRoomService _roomService;
        public RoomController(IPcService pcService, IPeripheryService peripheryService, IRoomService roomService, IUnitOfWork uinOfWork) : base(uinOfWork)
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
                Items = rooms.Items.Select(x => new RoomItemViewModel { Id = x.Id, Name = x.Name }).ToList(),
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

            var viewModel = new List<RoomItemViewModel>();

            foreach (var room in rooms.Items.OrderBy(r=> r.Name).ToList()) 
            {
                viewModel.Add(new RoomItemViewModel
                {
                    Id = room.Id,
                    Name = room.Name,
                    FreeSeatsCount = (await _roomService.GetFreeSeatsCount(room.Id, filter)).Value
                });
            }
            viewModel = viewModel.OrderByDescending(vm => vm.FreeSeatsCount).ToList();
            return Ok(new { Items = viewModel, TotalItemsCount = rooms.TotalItemsCount, PageSize = filter.PageSize,CurrentPage = rooms.CurrentPageNumber });
        }

        [HttpGet("getRoomInfo")]
        public async Task<IActionResult> GetRoomInfo(Guid id)
        {

            var peripheryFilter = new PeripheriesFilterBl
            {
                CurrentPage = 1,
                PageSize = int.MaxValue,
                RoomId = id
            };

            var peripheries = await _peripheryService.GetPageList(peripheryFilter);

            var pcFilter = new PcFilterBl
            {
                CurrentPage = 1,
                PageSize = int.MaxValue,
                RoomId = id
            };

            var pc = (await _pcService.GetPagedList(pcFilter)).Items.ElementAt(0);

            var pcInfoList = new List<PcViewModel>();

            foreach(var prop in pc.GetType().GetProperties())
            {
                pcInfoList.Add(new PcViewModel
                {
                    Name = prop.GetValue(pc).ToString(),
                    Type = prop.Name
                });
            }
            pcInfoList.RemoveAt(0);

            var viewModel = new GamingRoomViewModel
            {
                PcInfos= pcInfoList,
                Peripheries = peripheries.Items.Select(p => new PeripheryViewModel(p.Name, p.Type.Name)).ToList(),
            };
            return await ReturnSuccess(viewModel);
        }

        [HttpPost("searchRooms")]
        public async Task<IActionResult> SearchRooms([FromBody]SearchRoomViewModel viewModel)
        {
            //var rooms = await _roomService.SearchRooms(viewModel);
            //if (rooms.HasNoValue)
            //    return await ReturnSuccess();
            return await ReturnSuccess();
        }
    }
}
