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
        public ApiUserController(IApiUserService userService,IUnitOfWork uinOfWork) : base(uinOfWork)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Post(string userName, string password)
        {
            var apiUserDto = new ApiUserDto { UserName = userName };
            _userService.CreateAsync(apiUserDto, password);
            return Ok();
        }
    }
}
