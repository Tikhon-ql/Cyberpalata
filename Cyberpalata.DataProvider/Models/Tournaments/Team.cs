using Cyberpalata.DataProvider.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Models.Tournaments
{
    public class Team : BaseEntity
    {
        public string Name { get; set; }
        public virtual List<TeamMember> Members { get; set; }
        public virtual List<Tournament> Tournaments { get; set; }
        public bool IsHiring { get; set; }
    }
}
