using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Filters
{
    public class TeamFilterBL : BaseFilterBL
    {
        public Guid UserId { get; set; } = Guid.Empty;
        public bool IsHiring { get; set; }
    }
}
