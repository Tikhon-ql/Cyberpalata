using Cyberpalata.DataProvider.Models.Identity;
using System.ComponentModel.DataAnnotations;

namespace Cyberpalata.DataProvider.Models
{
    public class Notification : BaseEntity
    {
        [Required]
        public virtual User User { get; set; }
        [Required]
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? SentDate { get; set; }
    }
}
