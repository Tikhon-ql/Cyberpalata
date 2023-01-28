using CSharpFunctionalExtensions;
using Cyberpalata.Common.Intefaces;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.Logic.Interfaces;
using Cyberpalata.Logic.Models;
using Cyberpalata.ViewModel;
using Cyberpalata.ViewModel.Rooms;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Cyberpalata.WebApi.Controllers
{
    [ApiController]
    [Route("/booking")]
    public class BookingController : BaseController
    {
        private readonly IBookingService _bookingService;
        private readonly IRoomService _roomService;
        private readonly ILogger<BookingController> _logger;

        public BookingController(IBookingService bookingService,IRoomService roomService,IUnitOfWork uinOfWork, ILogger<BookingController> logger) : base(uinOfWork)
        {
            _bookingService = bookingService;
            _roomService = roomService;
            _logger = logger;
        }

        //[Authorize]
        [HttpGet("seats")]
        public async Task<IActionResult> GetRoomFreeSeats(Guid roomId)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest($"Bad request: {ModelState.ToString()}");
            }
            var room = await _roomService.ReadAsync(roomId);
            if(room.HasNoValue)
                return BadRequest("Bad room id!");
            var freeSeats = await _roomService.GetRoomFreeSeats(roomId);
            // no metter to check is seats null, so probably Maybe isn't needed.
            var tarrifs = room.Value.Prices;

            var resultSeats = new List<Seat>();

            //или создать метод проверки места и здесь вызывать?
            foreach(var item in room.Value.Seats)
            {
                if (freeSeats.Value.FirstOrDefault(i => i.Id == item.Id) == null)
                    resultSeats.Add(new Seat {Number = item.Number, IsFree = false });
                else
                    resultSeats.Add(new Seat { Number = item.Number, IsFree = true });
            }

            resultSeats[0].IsFree = false;
            resultSeats[2].IsFree = false;
            resultSeats[4].IsFree = false;
            resultSeats[10].IsFree = false;
            resultSeats[15].IsFree = false;
            resultSeats[18].IsFree = false;

            var viewModel = new BookingViewModel
            {
                //??? why here is Maybe?? 
                RoomName = room.Value.Name,
                Seats = resultSeats,
                Tariffs = tarrifs.Select(t => new Price(t.Hours, t.Cost)).ToList()
            };

            return await ReturnSuccess(viewModel);
        }

        //[Authorize]
        [HttpPost]
        public async Task<IActionResult> Post(BookingDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest($"Bad request: {ModelState.ToString()}");
            }

            await _bookingService.CreateAsync(dto);
            return await ReturnSuccess();
        }
    }
}
