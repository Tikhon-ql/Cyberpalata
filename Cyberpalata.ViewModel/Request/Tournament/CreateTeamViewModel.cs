using System.ComponentModel.DataAnnotations;

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
