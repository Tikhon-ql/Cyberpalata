using Cyberpalata.Common;
using Cyberpalata.Common.Intefaces;
using Cyberpalata.Logic.Interfaces;
using Cyberpalata.Logic.Models;
using Cyberpalata.ViewModel.GameLibrary;
using Microsoft.AspNetCore.Mvc;

namespace Cyberpalata.WebApi.Controllers
{
    [ApiController]
    [Route("/games")]
    public class GameController : BaseController
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService, IUnitOfWork unitOfWork): base(unitOfWork) 
        {
            _gameService = gameService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var games = _gameService.GetPagedListAsync(1).Result;
            var viewModel = new GameLibraryViewModel { Games = games.Items.Select(g => g.GameName).ToList() };
            return await ReturnSuccessAsync(viewModel);
        }
    }
}
