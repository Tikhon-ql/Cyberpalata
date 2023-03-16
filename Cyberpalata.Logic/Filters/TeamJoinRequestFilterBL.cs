using CSharpFunctionalExtensions;
using Cyberpalata.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Filters
{
    public class TeamJoinRequestFilterBL : BaseFilterBL
    {
        public Maybe<Guid> TeamId { get; set; }
        public Maybe<Guid> UserToJoinId { get; set; }
        public Maybe<List<JoinRequestState>> State { get; set; }
    }
}
