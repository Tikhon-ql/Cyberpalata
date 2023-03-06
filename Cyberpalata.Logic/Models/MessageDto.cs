using Cyberpalata.Logic.Models;
using Cyberpalata.Logic.Models.Identity;

namespace Cyberpalata.DataProvider.Models
{
    public class MessageDto
    {
        public UserDto Sender { get; set; }
        public string MessageText { get; set; }
        public DateTime SentDate { get; set; }
        public ChatDto Chat { get; set; }
    }
}
