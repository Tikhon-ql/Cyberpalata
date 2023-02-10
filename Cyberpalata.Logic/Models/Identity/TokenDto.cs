using System.ComponentModel.DataAnnotations;

namespace Cyberpalata.Logic.Models.Identity
{
    public class TokenDto
    {
        [Required]
        public string AccessToken { get; set; }
        [Required]
        public string RefreshToken { get; set; }
    }
}
