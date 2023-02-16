using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.ViewModel.Request.Tournament
{
    public class CreateTeamViewModel
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        public Guid CaptainId { get; set; }
    }
}
