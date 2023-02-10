using CSharpFunctionalExtensions;
using Cyberpalata.Common.Intefaces;
using Cyberpalata.Logic.Interfaces.Services;
using Cyberpalata.Logic.Models.Seats;
using Cyberpalata.ViewModel.Rooms;
using Cyberpalata.WebApi.ActionFilters;
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
        [ServiceFilter(typeof(ModelStateValidationFilter))]
        [HttpPost("getSeats")]
        public async Task<IActionResult> GetSeats([FromBody]SeatsGettingRequest request)
        {
            var seats = await _seatService.GetSeatsByRoomInRangeIdAsync(request);
            if (seats.HasNoValue)
                return BadRequest("Bad seat getting request!");
            var viewModel = seats.Value.Select(s => new SeatViewModel { Number = s.Number, IsFree = s.IsFree }).ToList();
            return Ok(viewModel);
        }
    }   
}
