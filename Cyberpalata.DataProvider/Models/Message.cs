using Cyberpalata.DataProvider.Models.Identity;
using System.ComponentModel.DataAnnotations;

namespace Cyberpalata.DataProvider.Models
{
    public class Message : BaseEntity
    {
        [Required]
        public virtual User Sender { get; set; }
        [Required]
        public string MessageText { get; set; }
        [Required]
        public DateTime SentDate { get;set; }
        [Required]
        public virtual Chat Chat { get; set; }
    }
}
