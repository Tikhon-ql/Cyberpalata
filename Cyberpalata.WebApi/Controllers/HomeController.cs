using Cyberpalata.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net.Security;

namespace Cyberpalata.WebApi.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : ControllerBase
    {

        private readonly ILoggerManager _logger;

        public HomeController(ILoggerManager logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            _logger.LogInformation("Helloworld");
            _logger.LogWarning("WARNIGNG");
            return "Hello wrold";
        }
    }
}
