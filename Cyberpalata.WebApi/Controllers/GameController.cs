using Cyberpalata.Common.Intefaces;
using Cyberpalata.Logic.Interfaces;
using Cyberpalata.ViewModel.GameLibrary;
using Microsoft.AspNetCore.Mvc;
using System.Data.OleDb;

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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var games = await _gameService.GetPagedListAsync(1);
            var viewModel = new GameLibraryViewModel { Games = games.Items.Select(g => g.GameName).ToList() };
            return await ReturnSuccess(viewModel);
        }
        [HttpGet("count")]
        public int[] Get(int count)
        {
            var rnd = new Random(DateTime.Now.Millisecond);
            var arr = new int[count];
            for (int i = 0; i < count; i++)
            {
                arr[i] = rnd.Next();
            }
            return arr;
        }
    }
}
