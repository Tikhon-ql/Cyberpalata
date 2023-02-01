using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cyberpalata.DataProvider.Models.Identity
{
    public class UserRefreshToken
    {
        [Key] 
        public Guid Id { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApiUser User { get; set; }
        [Required]
        public string RefreshToken { get; set; }
        [Required] 
        public DateTime Expiration { get; set; }
    }
}
