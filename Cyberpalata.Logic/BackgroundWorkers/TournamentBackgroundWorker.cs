using Cyberpalata.Common;
using Cyberpalata.Common.Intefaces;
using Cyberpalata.DataProvider.Filters;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Tournaments;
using Cyberpalata.Logic.Interfaces.Services;
using Cyberpalata.ViewModel.Request.Tournament;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Cyberpalata.Logic.BackgroundWorkers
{
    public class TournamentBackgroundWorker : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceFactory;
        private IUnitOfWork _unitOfWork;
        private ITournamentRepository _tournamentRepository;
        private readonly ILogger<TournamentBackgroundWorker> _logger;
        private IBatleService _batleService;
        public TournamentBackgroundWorker(IServiceScopeFactory serviceFactory, ILogger<TournamentBackgroundWorker> logger)
        {
            _serviceFactory = serviceFactory;
            _logger = logger;
        }

        private async Task<List<Tournament>> GetTournaments()
        {
            var filter = new TournamentFilter
            {
                CurrentPage = 1,
                IsActual = false,
                PageSize = int.MaxValue,
            };
            var actualTournaments = await _tournamentRepository.GetPageListAsync(filter);
            return actualTournaments.Items;
        }

        private void SetServices(IServiceScope scope)
        {
            _unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
            _tournamentRepository = scope.ServiceProvider.GetRequiredService<ITournamentRepository>();
            _batleService = scope.ServiceProvider.GetRequiredService<IBatleService>();
        }

        private async Task CheckTournament(Tournament tournament)
        {
            _logger.LogInformation($"Checking tournament with id: {tournament.Id} name: {tournament.Name}");
            foreach (var batle in tournament.Batles.ToList())
            {
                if (!batle.IsFirstTeamApproved && batle.IsSecondTeamApproved)
                {
                    await _batleService.SetWinner(new SetWinnerViewModel
                    {
                        BatleId = batle.Id,
                        TournamentId = tournament.Id,
                        WinnerId = batle.SecondTeam.Id
                    });
                }
                if (!batle.IsSecondTeamApproved && batle.IsFirstTeamApproved)
                {
                    await _batleService.SetWinner(new SetWinnerViewModel
                    {
                        BatleId = batle.Id,
                        TournamentId = tournament.Id,
                        WinnerId = batle.FirstTeam.Id
                    });
                }
            }
        }

        private async Task HandleTournaemnts(List<Tournament> tournaments)
        {
            foreach (var tournament in tournaments.ToList())
            {
                if (!tournament.IsGone)
                {
                    _logger.LogCritical(tournament.Date.ToString() + tournament.IsGone);
                    await CheckTournament(tournament);
                    tournament.IsGone = true;
                    await _unitOfWork.CommitAsync();
                }
            }
        }

        private async Task DoWork()
        {
            using (var scope = _serviceFactory.CreateScope())
            {
                SetServices(scope);
                var tournaments = await GetTournaments();
                await HandleTournaemnts(tournaments);
            }
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await DoWork();
                await Task.Delay(10000, stoppingToken);
            }
        }
    }
}
