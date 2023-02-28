using Cyberpalata.ViewModel.Response.Tournament;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.ViewModel.Request.Tournament
{
    public class CreateTournamentViewModel
    {
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int RoundCount { get; set; }
        //public int TeamsMaxCount { get; set; }
        //public List<RoundCreateViewModel> Rounds { get; set; }
    }
}
