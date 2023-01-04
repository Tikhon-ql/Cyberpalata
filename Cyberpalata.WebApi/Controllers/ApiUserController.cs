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
        public async Task<IActionResult> Post(string email, string userName, string surname,string phone, string password)
        {
            ///На этом этапе нужно пароль преобразовывать в хеш и кидать на регистрацию или это нужно делать на слое бизнес логики?
            var request = new AuthorizationRequest {Email = new MailAddress(email),Username = userName,Surname = surname, Phone = phone, Password = password };
            await _userService.CreateAsync(request);
            return await ReturnSuccessAsync();
        }
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(string email, string password)
        {
            var request = new AuthenticateRequest { Email = new MailAddress(email),Password = password };
            var result = await _userService.ValidateUserAsync(request);
            if (result.IsFailure)
                return BadRequest(result.Error);

            var token = await _userService.GenerateTokenAsync(request);

            return Ok(token);
        }
    }
}
