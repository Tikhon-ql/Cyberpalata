using Cyberpalata.DataProvider.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Models
{
    public class Message : BaseEntity
    {
        public virtual User Sender { get; set; }
        public string MessageText { get; set; }
        public DateTime SentDate { get;set; }
        public virtual Chat Chat { get; set; }
    }
}
