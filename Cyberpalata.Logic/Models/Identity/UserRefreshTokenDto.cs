using System.ComponentModel.DataAnnotations;

namespace Cyberpalata.Logic.Models.Identity
{
    public class UserRefreshTokenDto
    {
        [Required] public string RefreshToken { get; set; }
        [Required] public DateTime Expiration { get; set; }
    }
}
