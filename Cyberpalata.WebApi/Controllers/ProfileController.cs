using Cyberpalata.Common.Intefaces;
using Cyberpalata.Logic.Interfaces;
using Cyberpalata.Logic.Models.Identity.User;
using Cyberpalata.ViewModel.Booking;
using Cyberpalata.ViewModel.Rooms;
using Cyberpalata.ViewModel.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace Cyberpalata.WebApi.Controllers
{
    [ApiController]
    [Route("/profile")]
    public class ProfileController : BaseController
    {
        private readonly IApiUserService _userService;
        private readonly IBookingService _bookingService;
        private readonly ISeatService _seatService;

        public ProfileController(IApiUserService userService, IBookingService bookingService, ISeatService seatService,IUnitOfWork uinOfWork) : base(uinOfWork)
        {
            _userService = userService;
            _bookingService = bookingService;
            _seatService = seatService;
        }

        [Authorize]
        [HttpPut("profileEditing")]
        public async Task<IActionResult> EditProfile(UserUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest($"Bad request: {ModelState}");
            }
            request.UserId = Guid.Parse(User.Claims.Single(claim => claim.Type == JwtRegisteredClaimNames.Sid).Value.ToString());
            await _userService.UpdateUserAsync(request);
            return await ReturnSuccess();
        }

        [Authorize]
        [HttpGet("getProfile")]
        public async Task<IActionResult> GetProfile()
        {     
            var id = Guid.Parse(User.Claims.Single(claim => claim.Type == JwtRegisteredClaimNames.Sid).Value.ToString());
            var user = await _userService.ReadAsync(id);
            return Ok(new ProfileViewModel
            {
                Username = user.Value.Username,
                Surname = user.Value.Surname,
                Email = user.Value.Email,
                Phone = user.Value.Phone,
                BookingsCount = user.Value.Bookings.Count(),
                BookingsIds = user.Value.Bookings.Select(b=>b.Id).ToList(),
            }) ;
        }
        [Authorize]
        [HttpGet("getBookingSmallInfo")]
        public async Task<IActionResult> GetBookingsSmallInfo()
        {
            var userId = Guid.Parse(User.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.Sid).Value);
            var user = await _userService.ReadAsync(userId);
            var viewModel = new List<BookingSmallViewModel>();
            foreach(var item in user.Value.Bookings)
            {
                viewModel.Add(new BookingSmallViewModel
                {
                    Id = item.Id,
                    Begining = item.Begining,
                    Ending = item.Ending,
                    RoomName = item.Room.Name
                });
            }
            return Ok(viewModel);
        }

        //[Authorize]
        //[HttpGet("getUsersBookings")]
        //public async Task<IActionResult> GetUsersBookings()
        //{
        //    var id = Guid.Parse(User.Claims.Single(claim => claim.Type == JwtRegisteredClaimNames.Sid).Value.ToString());
        //    var user = await _userService.ReadAsync(id);

        //    var viewModel = new List<UserBookingViewModel>();

        //    var bookings = await _bookingService.GetBookingsByUserAsync(id);
        //    if (bookings.HasValue)
        //    {
        //        foreach (var booking in bookings.Value)
        //        {
        //            var resultSeats = new List<UserSeatViewModel>();
        //            var seats = await _seatService.GetSeatsByRoomId(booking.Room.Id);
        //            if (seats.HasNoValue)
        //                continue;

        //            seats.Value.ForEach(seat =>
        //            {
        //                resultSeats.Add(new UserSeatViewModel
        //                {
        //                    Number = seat.Number,
        //                    Type = seat.IsFree ? SeatType.Free : SeatType.IsTaken
        //                });
        //            });

        //            resultSeats.OrderBy(seat => seat.Number);
        //            foreach (var bookingSeat in booking.Seats)
        //            {
        //                resultSeats[bookingSeat.Number - 1].Type = SeatType.UsersSeat;
        //            }
        //            viewModel.Add(new UserBookingViewModel
        //            {
        //                Begining = booking.Begining,
        //                Ending = booking.Ending,
        //                RoomName = booking.Room.Name,
        //                Seats = resultSeats,
        //                Tariff = new PriceViewModel
        //                {
        //                    Cost = booking.Tariff.Cost,
        //                    Hours = booking.Tariff.Hours
        //                }
        //            });
        //        }
        //    }
        //    return Ok(viewModel);
        //}
    }
}
