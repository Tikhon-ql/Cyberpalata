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
        private readonly IRoomService _roomService;
        private readonly ILogger<BookingController> _logger;

        public BookingController(IBookingService bookingService, ISeatService seatService, IUnitOfWork uinOfWork, IRoomService roomService, ILogger<BookingController> logger) : base(uinOfWork)
        {
            _bookingService = bookingService;
            _seatService = seatService;
            _roomService = roomService;
            _logger = logger;
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
        [HttpGet("calculateBookingPrice")]
        public async Task<IActionResult> CalculateBookingPrice(TimeSpan beg, int hours)
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

        [Authorize]
        [HttpGet("getBookingSmallInfo")]
        public async Task<IActionResult> GetBookingsSmallInfo(int page)
        {
            var userId = Guid.Parse(User.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.Sid).Value);
            //var user = await _userService.ReadAsync(userId);
            var bookings = await _bookingService.GetPagedListAsync(page, userId);

            var viewModel = new List<BookingSmallViewModel>();
            foreach (var item in bookings.Items)
            {
                viewModel.Add(new BookingSmallViewModel
                {
                    Id = item.Id,
                    Begining = item.Begining.ToString(@"hh\:mm"),
                    HoursCount = item.HoursCount,
                    Price = item.Price,
                    Date = item.Date.ToString("yyyy-MM-dd"),
                    RoomName = item.Room.Name
                });
            }
            return Ok(new { viewModel, bookings.TotalItemsCount });
        }
    }
}
