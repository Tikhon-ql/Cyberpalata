using Cyberpalata.DataProvider.Models.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cyberpalata.DataProvider.Models
{
    public class Chat : BaseEntity
    {
        [Required]
        public Guid UserToJoinId { get; set; }
        [ForeignKey("UserToJoinId")]
        public virtual User UserToJoin { get; set; }
        [Required]
        public Guid CaptainId { get; set; }
        [ForeignKey("CaptainId")]
        public virtual User Captain { get; set; }
        public bool IsDeleted { get; set; }
        public virtual List<Message>? Messages { get; set; }
    }
}
