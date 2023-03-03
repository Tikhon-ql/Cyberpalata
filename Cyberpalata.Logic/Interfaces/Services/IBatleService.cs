using CSharpFunctionalExtensions;
using Cyberpalata.ViewModel.Request.Tournament;

namespace Cyberpalata.Logic.Interfaces.Services
{
    public interface IBatleService
    {
        Task<Result> SetWinner(SetWinnerViewModel viewModel); 
    }
}
