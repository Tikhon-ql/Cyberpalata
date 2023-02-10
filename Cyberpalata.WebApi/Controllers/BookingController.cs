using CSharpFunctionalExtensions;
using Cyberpalata.Common.Intefaces;
using Cyberpalata.Logic.Interfaces.Services;
using Cyberpalata.Logic.Models.Booking;
using Cyberpalata.ViewModel.Booking;
using Cyberpalata.ViewModel.Booking.Enum;
using Cyberpalata.WebApi.ActionFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using SeatBookingViewModel = Cyberpalata.ViewModel.Booking.SeatBookingViewModel;

namespace Cyberpalata.WebApi.Controllers
{
    [ApiController]
    [Route("/booking")]
    public class BookingController : BaseController
    {
        private readonly IBookingService _bookingService;
        private readonly ISeatService _seatService;
        private readonly IPriceService _priceService;
        private readonly IRoomService _roomService;
        //private readonly IRoomService _roomService;
        private readonly ILogger<BookingController> _logger;

        public BookingController(IBookingService bookingService, ISeatService seatService,IPriceService priceService, IUnitOfWork uinOfWork, IRoomService roomService, ILogger<BookingController> logger) : base(uinOfWork)
        {
            _bookingService = bookingService;
            _seatService = seatService;
            _priceService = priceService;
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
            //var room = await _roomService.ReadAsync(roomId);
            //if(room.HasNoValue)
            //    return BadRequest("Bad room id!");
            //Maybe<List<SeatDto>> freeSeats = new List<SeatDto>();//await _roomService.GetRoomFreeSeats(roomId);
            //// no metter to check is seats null, so probably Maybe isn't needed.
            //var tarrifs = room.Value.Prices;

            //var resultSeats = new List<Seat>();

            ////или создать метод проверки места и здесь вызывать?
            //foreach(var item in room.Value.Seats)
            //{
            //    if (freeSeats.Value.FirstOrDefault(i => i.Id == item.Id) == null)
            //        resultSeats.Add(new Seat {Number = item.Number, IsFree = false });
            //    else
            //        resultSeats.Add(new Seat { Number = item.Number, IsFree = true });
            //}

            //var resultSeats = await _seatService.GetSeatsByRoomId(roomId);
            //if (resultSeats.HasNoValue)
               //return BadRequest("Something wrong with room id or its seats");
            var tariffs = await _priceService.GetByRoomIdAsync(roomId);
            if(tariffs.HasNoValue)
                return BadRequest("Something wrong with room id or its tariffs");

            var viewModel = new BookingAddingViewModel
            {
                //Seats = resultSeats.Value.Select(s =>  new SeatViewModel { Number = s.Number, IsFree = s.IsFree}).ToList(),
                Tariffs = tariffs.Value.Select(t => new PriceViewModel(t.Hours, t.Cost)).ToList()
            };

            return Ok(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ServiceFilter(typeof(ModelStateValidationFilter))]
        public async Task<IActionResult> Post(BookingCreateRequest request)
        {
            var userId = Guid.Parse(User.Claims.Single(claim => claim.Type == JwtRegisteredClaimNames.Sid).Value);
            var result = await _roomService.AddBookingToRoom(userId,request);
            if (result.IsFailure)
                return BadRequestJson(result);
            return await ReturnSuccess();
        }

        [Authorize]
        [HttpGet("getPrice")]
        public async Task<IActionResult> GetPrice(TimeSpan beg, int hours)
        {
            return Ok(hours);
        }

        [Authorize]
        [HttpGet("getBooking")]
        public async Task<IActionResult> GetBooking(Guid id)
        {
            var booking = await _bookingService.ReadAsync(id);
            if (booking.HasNoValue)
                return BadRequest($"Booking with id: {id} doen't exist!");
            var viewModel = new BookingViewModel
            {
                RoomName = booking.Value.Room.Name,
                Date = booking.Value.Date.ToString(),
                Begining = booking.Value.Begining.ToString(@"hh\:mm"),
                Price = booking.Value.Price,
                HoursCount = booking.Value.HoursCount,
                Seats = new List<SeatBookingViewModel>(),
            };

            var seats = await _seatService.GetSeatsByRoomIdAsync(booking.Value.Room.Id);
            var resultSeats = new List<SeatBookingViewModel>();
            seats.Value.ForEach((seat =>
            {
                resultSeats.Add(new SeatBookingViewModel
                {
                    Number = seat.Number,
                    Type = SeatType.Free,
                });
            }));

            resultSeats = resultSeats.OrderBy(seat => seat.Number).ToList();
            foreach (var bookingSeat in booking.Value.Seats)
            {
                resultSeats[bookingSeat.Number - 1].Type = SeatType.UsersSeat;
            }
            viewModel.Seats = resultSeats;
            return Ok(viewModel);
        }
    }
}
