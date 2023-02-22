using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Filters
{
    public class TournamentFilterBL : BaseFilterBL
    {
        public Maybe<Guid> CaptainId { get;set; }
        public Maybe<bool> IsActual { get; set; }
    }
}
