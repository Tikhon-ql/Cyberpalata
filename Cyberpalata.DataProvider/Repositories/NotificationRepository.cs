using Cyberpalata.DataProvider.Context;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Repositories
{
    internal class NotificationRepository : BaseRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
