using Cyberpalata.Logic.Models.Identity;

namespace Cyberpalata.Logic.Models
{
    public class NotificationDto
    {
        public Guid Id { get; set; }
        public UserDto User { get; set; }
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? SentDate { get; set; }
    }
}
