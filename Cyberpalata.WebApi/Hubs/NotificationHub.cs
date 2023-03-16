using Microsoft.AspNetCore.SignalR;

namespace Cyberpalata.WebApi.Hubs
{
    public class NotificationHub : Hub
    {
        public async Task JoinNotificationsBroadcasting(Guid userId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, userId.ToString());       
        }   

        public async Task SendNotification(Guid receiver)
        {
            await Clients.Group(receiver.ToString()).SendAsync("ReceiveNotification", "refreshUI","bot");
        }
    }
}
