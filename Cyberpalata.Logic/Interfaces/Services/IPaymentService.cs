using CSharpFunctionalExtensions;
using Cyberpalata.Logic.Models;
using Cyberpalata.ViewModel.Request.Bookings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Interfaces.Services
{
    public interface IPaymentService
    {
        Result MakeTransaction(Card card, decimal price, Guid userId);
    }
}
