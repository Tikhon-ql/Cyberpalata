using CSharpFunctionalExtensions;
using Cyberpalata.Common.Intefaces;
using Cyberpalata.Logic.Interfaces.Services;
using Cyberpalata.ViewModel.Request.Seats;
using Cyberpalata.ViewModel.Response;
using Cyberpalata.ViewModel.Response.Booking.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cyberpalata.WebApi.Controllers
{
    [ApiController]
    [Route("/seats")]
    public class SeatsController : BaseController
    {
        private readonly ISeatService _seatService;
        public SeatsController(ISeatService seatService,IUnitOfWork uinOfWork) : base(uinOfWork)
        {
            _seatService = seatService;
        }
        [Authorize]
        [HttpPost("getSeats")]
        public async Task<IActionResult> GetSeats([FromBody]SeatsGettingViewModel request)
        {
            var seats = await _seatService.GetSeatsByRoomInRangeIdAsync(request);
            if (seats.HasNoValue)
                return BadRequest("Bad seat getting request!");
            var viewModel = seats.Value.Select(s => new SeatViewModel { Number = s.Number, Type = s.IsFree ? SeatType.Free : SeatType.IsTaken }).ToList();
            return Ok(viewModel);
        }
    }   
}
