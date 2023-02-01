using Cyberpalata.Common.Intefaces;
using Cyberpalata.Logic.Interfaces;
using Cyberpalata.Logic.Models;
using Cyberpalata.Logic.Models.Identity.User;
using Cyberpalata.ViewModel;
using Cyberpalata.ViewModel.Rooms;
using Cyberpalata.ViewModel.User;
using Cyberpalata.ViewModel.User.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Mail;

namespace Cyberpalata.WebApi.Controllers
{
    [ApiController]
    [Route("/users")]
    public class ApiUserController : BaseController
    {
        private readonly IApiUserService _userService;
        private readonly IBookingService _bookingService;
        private readonly ISeatService _seatService;
        private readonly ILogger<ApiUserController> _logger;

        public ApiUserController(IApiUserService userService, ILogger<ApiUserController> logger,IBookingService bookingService, IUnitOfWork uinOfWork) : base(uinOfWork)
        {
            _userService = userService;
            _bookingService = bookingService;
            _logger = logger;
        }
        [Authorize]
        [HttpGet("profile")]
        public async Task<IActionResult> Profile()
        {
            //if(!ModelState.IsValid)
            //{
            //    return BadRequest($"Bad request: {ModelState.ToString()}");
            //}
            //var id = Guid.Parse(User.Claims.Single(claim => claim.Type == JwtRegisteredClaimNames.Sid).Value.ToString());
            //var user = await _userService.ReadAsync(id);
            //if (user.HasNoValue)
            //    return BadRequest($"User with id: {id} doesn't exist!");          

            //var viewModel = new ProfileViewModel
            //{
            //    User = new UserViewModel
            //    {
            //        Name = user.Value.Username,
            //        Surname = user.Value.Surname,
            //        Email = user.Value.Email,
            //        Phone = user.Value.Phone
            //    }
            //};

            //var bookings = await _bookingService.GetBookingsByUserAsync(id);

            //if (bookings.HasValue)
            //{
            //    foreach(var booking in bookings.Value)
            //    {
            //        var resultSeats = new List<UserSeatViewModel>();
            //        var seats = await _seatService.GetSeatsByRoomId(booking.Room.Id);
            //        if (seats.HasNoValue)
            //            continue;

            //        seats.Value.ForEach(seat =>
            //        {
            //            resultSeats.Add(new UserSeatViewModel
            //            {
            //                Number = seat.Number,
            //                Type = seat.IsFree ? SeatType.Free : SeatType.IsTaken
            //            });
            //        });

            //        resultSeats.OrderBy(seat => seat.Number);
            //        foreach(var bookingSeat in booking.Seats)
            //        {
            //            resultSeats[bookingSeat.Number - 1].Type = SeatType.UsersSeat;
            //        }

            //        var bookingViewModel = new UserBookingViewModel
            //        {
            //            RoomName = booking.Room.Name,
            //            Begining = booking.Begining,
            //            Ending = booking.Ending,
            //            Tariff = new PriceViewModel(booking.Tariff.Hours, booking.Tariff.Cost),
            //            Seats = resultSeats
            //        };
            //        viewModel.Bookings.Add(bookingViewModel);
            //    }
            //}
            var id = Guid.Parse(User.Claims.Single(claim => claim.Type == JwtRegisteredClaimNames.Sid).Value.ToString());
            var user = await _userService.ReadAsync(id);
            //if (user.HasNoValue)
            //    return BadRequest($"User with id: {id} doesn't exist!"); // we dont need it?

            return Ok(new ProfileViewModel {Username = user.Value.Username, Surname = user.Value.Surname, Email = user.Value.Email, Phone = user.Value.Phone });
        }

        [Authorize]
        [HttpPost("profileEditing")]
        public async Task<IActionResult> EditProfile(UserUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest($"Bad request: {ModelState.ToString()}");
            }
            request.UserId = Guid.Parse(User.Claims.Single(claim => claim.Type == JwtRegisteredClaimNames.Sid).Value.ToString());
            await _userService.UpdateUserAsync(request);
            return await ReturnSuccess();
        }

        [HttpGet("passwordRecovering")]
        public async Task<IActionResult> PasswordRecovering([EmailAddress]string email)
        {
            await _userService.PasswordRecoveryAsync(email);
            return Ok();
        }
        [HttpPost("passwordRecovering")]
        public async Task<IActionResult> PasswordRecovering(PasswordResetRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest($"Bad request: {ModelState.ToString()}");
            }
            var result = await _userService.ResetPasswordAsync(request);
            if (result.IsFailure)
                return BadRequest(result.Error);
            return await ReturnSuccess();
        }

        [HttpPost("emailConfirm")]
        public async Task<IActionResult> EmailConfrim(bool result,string email)
        {
            if (!result)
            {
                var deleteResult = await _userService.DeleteAsync(email);
                if (deleteResult.IsFailure)
                    return BadRequest(deleteResult.Error);
            }     
            return await ReturnSuccess();
        }
        [HttpPost("emailConfirm")]
        public async Task<IActionResult> EmailConfrim([EmailAddress]string email)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest($"Bad request: {ModelState.ToString()}");
            }
            int code = await _userService.SendCodeToMailAsync(email);
            return Ok(code);
        }
    }
}
