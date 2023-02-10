using Cyberpalata.Common.Intefaces;
using Cyberpalata.Logic.Interfaces.Services;
using Cyberpalata.ViewModel.GameLibrary;
using Microsoft.AspNetCore.Mvc;

namespace Cyberpalata.WebApi.Controllers
{
    [ApiController]
    [Route("/games")]
    public class GameController : BaseController
    {
        private readonly IGameService _gameService;
        private readonly ILogger<GameController> _logger;

        public GameController(IGameService gameService, IUnitOfWork unitOfWork, ILogger<GameController> logger) : base(unitOfWork)
        {
            _gameService = gameService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var games = await _gameService.GetPagedListAsync(1);
            var viewModel = new GameLibraryViewModel { Games = games.Items.Select(g => g.GameName).ToList() };
            return await ReturnSuccess(viewModel);
        }
    }
}
