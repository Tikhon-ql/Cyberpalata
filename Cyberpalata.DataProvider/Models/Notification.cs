using Cyberpalata.DataProvider.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Models
{
    public class Notification : BaseEntity
    {
        public virtual User User { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
