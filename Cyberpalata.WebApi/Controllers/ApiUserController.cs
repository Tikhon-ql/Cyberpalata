using Cyberpalata.Common.Intefaces;
using Cyberpalata.Logic.Interfaces;
using Cyberpalata.Logic.Models.Identity;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public async Task<IActionResult> Get(string userName, string password)
        { 
            await _userService.LoginAsync(userName, password,false);
            Console.WriteLine(User.Identity.Name);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post(string userName, string password)
        {
            var apiUserDto = new ApiUserDto { Email = userName };
            await _userService.CreateAsync(apiUserDto, password);
            return ReturnSuccess();
        }
    }
}
