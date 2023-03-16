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
        public Timer _timer;
        public TournamentBackgroundWorker(IServiceScopeFactory serviceFactory, ILogger<TournamentBackgroundWorker> logger)
        {
            _serviceFactory = serviceFactory;
            _logger = logger;
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while(!stoppingToken.IsCancellationRequested)
            {
                var filter = new TournamentFilter
                {
                    CurrentPage = 1,
                    IsActual = true,
                    PageSize = int.MaxValue,
                };
                PagedList<Tournament> actualTournaments = null;
                using (var scope = _serviceFactory.CreateScope())
                {
                    _unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                    _tournamentRepository = scope.ServiceProvider.GetRequiredService<ITournamentRepository>();
                    actualTournaments = await _tournamentRepository.GetPageListAsync(filter);
                    _batleService = scope.ServiceProvider.GetRequiredService<IBatleService>();
                    foreach (var tournament in actualTournaments.Items.ToList())
                    {
                        if (!tournament.IsGone && tournament.Date >= DateTime.UtcNow)
                        {
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
                            tournament.IsGone = true;
                            await _unitOfWork.CommitAsync();
                        }
                    }
                }
                await Task.Delay(10000, stoppingToken);
            }      
        }
    }
}
