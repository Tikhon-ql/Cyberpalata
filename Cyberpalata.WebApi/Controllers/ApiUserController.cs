using Cyberpalata.Common.Intefaces;
using Cyberpalata.Logic.Interfaces;
using Cyberpalata.Logic.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace Cyberpalata.WebApi.Controllers
{
    [ApiController]
    [Route("/users")]
    public class ApiUserController : BaseController
    {
        private readonly IApiUserService _userService;

        public ApiUserController(IApiUserService userService,ILogger logger,IUnitOfWork uinOfWork) : base(uinOfWork,logger)
        {
            _userService = userService;
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            if(!ModelState.IsValid)
            {
                return BadRequest($"Bad request: {ModelState.ToString()}");
            }
            var id = new Guid(User.Claims.Single(claim => claim.Type == JwtRegisteredClaimNames.Sid).ToString());
            var user = await _userService.ReadAsync(id);
            return Ok(user.Value);
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Book(BookingDto bookingDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest($"Bad request: {ModelState.ToString()}");
            }

            return await ReturnSuccess();
        }
    }
}
