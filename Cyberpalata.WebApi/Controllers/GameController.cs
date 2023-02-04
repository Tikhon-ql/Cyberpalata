using Cyberpalata.Common.Intefaces;
using Cyberpalata.Logic.Interfaces;
using Cyberpalata.ViewModel.GameLibrary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data.OleDb;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest($"Bad request: {ModelState.ToString()}");
            //}
            //_logger.LogInformation("Loggin");
            //var games = await _gameService.GetPagedListAsync(1);
            //var viewModel = new GameLibraryViewModel { Games = games.Items.Select(g => g.GameName).ToList() };
            //return await ReturnSuccess(viewModel);
            return StatusCode(500);
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
