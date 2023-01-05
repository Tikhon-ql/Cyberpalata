using Cyberpalata.Common.Intefaces;
using Cyberpalata.Logic.Interfaces;
using Cyberpalata.Logic.Models.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

namespace Cyberpalata.WebApi.Controllers
{
    [ApiController]
    [Route("/users")]
    public class ApiUserController : BaseController
    {
        private readonly IApiUserService _userService;
        public ApiUserController(IApiUserService userService, IUnitOfWork uinOfWork) : base(uinOfWork)
        {
            _userService = userService;
        }

        //[HttpGet]
        //public async Task<IActionResult> Get(string userName, string password)
        //{ 
        //    await _userService.LoginAsync(userName, password,false);
        //    Console.WriteLine(User.Identity.Name);
        //    return Ok();
        //}

        [HttpPost]
        public async Task<IActionResult> Post([FromForm]AuthorizationRequest request)
        {
            await _userService.CreateAsync(request);
            return await ReturnSuccessAsync();
        }
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromForm]AuthenticateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("");
            }
            var result = await _userService.ValidateUserAsync(request);
            if (result.IsFailure)
                return BadRequest(result.Error);

            var token = _userService.GenerateToken(request);

            return await ReturnSuccessAsync(token);
        }
    }
}
