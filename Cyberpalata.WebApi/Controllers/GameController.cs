using Cyberpalata.Common.Intefaces;
using Cyberpalata.Logic.Filters;
using Cyberpalata.Logic.Interfaces.Services;
using Cyberpalata.ViewModel.Response.GameLibrary;
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
            var filter = new BaseFilterBL
            {
                CurrentPage = 1,
                PageSize = 10,
            };
            var games = await _gameService.GetPagedListAsync(filter);
            var viewModel = new GameLibraryViewModel { Games = games.Items.Select(g => g.GameName).ToList() };
            return await ReturnSuccess(viewModel);
        }
    }
}
