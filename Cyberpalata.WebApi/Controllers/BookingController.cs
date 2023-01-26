using Cyberpalata.Common.Intefaces;
using Cyberpalata.Logic.Interfaces;
using Cyberpalata.Logic.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cyberpalata.WebApi.Controllers
{
    [ApiController]
    [Route("/booking")]
    public class BookingController : BaseController
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService,IUnitOfWork uinOfWork, ILogger logger) : base(uinOfWork,logger)
        {
            _bookingService = bookingService;
        }
        [Authorize]
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
