using Cyberpalata.Common;
using Cyberpalata.Logic.Interfaces;
using Cyberpalata.Logic.Models;
using Cyberpalata.ViewModel.GameLibrary;
using Microsoft.AspNetCore.Mvc;

namespace Cyberpalata.WebApi.Controllers
{
    [ApiController]
    [Route("/games")]
    public class GameController : Controller
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public GameLibraryViewModel Get()
        {
            var games = _gameService.GetPagedListAsync(1).Result;
            var viewModel = new GameLibraryViewModel { Games = games.Items.Select(g => g.GameName).ToList() };
            return viewModel;
        }
    }
}
