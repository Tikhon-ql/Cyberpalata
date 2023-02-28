using CSharpFunctionalExtensions;
using Cyberpalata.DataProvider.Models.Identity;
using Cyberpalata.DataProvider.Models.Tournaments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Filters
{
    public class TournamentFilter : BaseFilter<Tournament>
    {
        public Maybe<Guid> CaptainId { get; set; }
        public Maybe<bool> IsActual { get; set; }

        public override IQueryable<Tournament> EnrichQuery(IQueryable<Tournament> query)
        {   
            if (CaptainId.HasValue)
            {
                query = query.Where(q => q.Batles.Any(b => b.FirstTeam.Members.Any(m => m.IsCaptain && m.MemberId == CaptainId.Value) 
                || b.SecondTeam.Members.Any(m => m.IsCaptain && m.MemberId == CaptainId.Value)));
            }
            if (IsActual.HasValue)
            {
                if(IsActual.Value)
                    query = query.Where(q=>q.Date > DateTime.UtcNow);
                else
                    query = query.Where(q => q.Date < DateTime.UtcNow);
            }
            return query;
        }
    }
}
