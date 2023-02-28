using Cyberpalata.Common.Intefaces;
using Cyberpalata.Logic.Interfaces.Services;
using Cyberpalata.ViewModel.Request.Tournament;
using Microsoft.AspNetCore.Mvc;

namespace Cyberpalata.WebApi.Controllers
{
    [ApiController]
    [Route("/batles")]
    public class BatleController : BaseController
    {
        private readonly IBatleService _batleService;
        public BatleController(IUnitOfWork uinOfWork,IBatleService batleService) : base(uinOfWork)
        {
            _batleService = batleService;
        }
        [HttpPost("setWinner")]
        public async Task<IActionResult> SetWinner(SetWinnerViewModel viewModel)
        {
            var result = await _batleService.SetWinner(viewModel);
            return await ReturnSuccess();
        }
    }
}
