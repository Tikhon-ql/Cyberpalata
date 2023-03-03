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

        public GameController(IGameService gameService, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _gameService = gameService;
        }

        [HttpGet("getGames")]
        public async Task<IActionResult> Get(int page)
        {
            var filter = new BaseFilterBL
            {
                CurrentPage = page,
                PageSize = 10,
            };
            var games = await _gameService.GetPagedListAsync(filter);
            var viewModel = new List<GameViewModel>();
            foreach(var item in games.Items)
            {
                viewModel.Add(new GameViewModel { Name = item.GameName,ImageUrl = item.ImageUrl});
            }
            return await ReturnSuccess(viewModel);
        }
    }
}
