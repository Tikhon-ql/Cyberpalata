using Cyberpalata.DataProvider.Models.Identity;
using Cyberpalata.Logic.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Models
{
    public class NotificationDto
    {
        public virtual UserDto User { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
