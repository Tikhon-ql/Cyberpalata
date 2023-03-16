namespace Cyberpalata.WebApi.Connections
{
    public class NotificationViewModel
    {
        public Guid NotificationId { get; set; }
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Sender { get; set; }
        public Guid Receiver { get; set; }
    }
}
