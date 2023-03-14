using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.ViewModel.Request.Tournament
{
    public class AnswerJoinRequestViewModel
    {
        public Guid TeamId { get; set; }
        public Guid UserToJoinId { get; set; }
        public Guid ChatId { get; set; }
        public bool IsAccepted { get; set; }
    }
}
