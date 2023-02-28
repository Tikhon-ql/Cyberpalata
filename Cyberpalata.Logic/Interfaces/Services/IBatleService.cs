using CSharpFunctionalExtensions;
using Cyberpalata.ViewModel.Request.Tournament;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Interfaces.Services
{
    public interface IBatleService
    {
        Task<Result> SetWinner(SetWinnerViewModel viewModel); 
    }
}
