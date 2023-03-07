using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.ViewModel.Request
{
    public class MessageViewModel
    {
        public Guid ChatId { get; set; }
        public string Sender { get; set; }
        public string MessageText { get; set; }
    }
}
