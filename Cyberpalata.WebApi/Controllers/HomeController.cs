using Microsoft.AspNetCore.Mvc;
using System.Net.Security;

namespace Cyberpalata.WebApi.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Hello wrold";
        }
    }
}
