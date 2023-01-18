using System.ComponentModel.DataAnnotations;

namespace Cyberpalata.DataProvider.Models.Identity
{
    public class UserRefreshToken
    {
        [Key] 
        public Guid Id { get; set; }
        [Required] 
        public ApiUser User { get; set; }
        [Required]
        public string RefreshToken { get; set; }
        [Required] 
        public DateTime Expiration { get; set; }
    }
}
