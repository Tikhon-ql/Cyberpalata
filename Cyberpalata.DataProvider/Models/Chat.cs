using Cyberpalata.DataProvider.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Models
{
    public class Chat : BaseEntity
    {
        [Required]
        public virtual User UserToJoin { get; set; }
        [Required]
        public virtual User Captain { get; set; }
        public bool IsDeleted { get; set; }
        public virtual List<Message>? Messages { get; set; }
    }
}
