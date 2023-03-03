using System.ComponentModel.DataAnnotations;

namespace Cyberpalata.ViewModel.Request.Tournament
{
    public class CreateTournamentViewModel
    {
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public string RoundCount { get; set; }
    }
}
