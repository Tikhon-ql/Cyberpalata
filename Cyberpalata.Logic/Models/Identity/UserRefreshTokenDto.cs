using System.ComponentModel.DataAnnotations;

namespace Cyberpalata.Logic.Models.Identity
{
    public class UserRefreshTokenDto
    {
        public string RefreshToken { get; set; }
        public DateTime Expiration { get; set; }
    }
}
