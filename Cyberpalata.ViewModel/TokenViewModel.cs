using System.ComponentModel.DataAnnotations;

namespace Cyberpalata.ViewModel
{
    public class TokenViewModel
    {
        [Required]
        public string AccessToken { get; set; }
        [Required]
        public string RefreshToken { get; set; }
    }
}
