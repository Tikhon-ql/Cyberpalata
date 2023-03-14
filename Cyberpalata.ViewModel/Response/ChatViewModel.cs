using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.ViewModel.Response
{
    public class ChatViewModel
    {
        public Guid ChatId { get; set; }
        public Guid OtherId { get; set; }
        public Guid TeamId { get; set; }
        public string OtherUserName {  get; set; }
        public string OtherUserSurname { get; set; }
        public bool IsYouACaptain {  get; set; }
    }
}
