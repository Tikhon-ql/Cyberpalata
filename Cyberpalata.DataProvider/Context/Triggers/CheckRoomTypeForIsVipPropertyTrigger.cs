using Cyberpalata.Common.Enums;
using Cyberpalata.DataProvider.Models;
using EntityFrameworkCore.Triggered;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Context.Triggers
{
    internal class CheckRoomTypeForIsVipPropertyTrigger : IBeforeSaveTrigger<Room>
    {
        private readonly ApplicationDbContext _context;

        public CheckRoomTypeForIsVipPropertyTrigger(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task BeforeSave(ITriggerContext<Room> context, CancellationToken cancellationToken)
        {
            if(context.ChangeType == ChangeType.Added || context.ChangeType == ChangeType.Modified)
            {
                //??? Why game console cannot be vip or common
                if (context.Entity.Type == RoomType.Lounge && context.Entity.IsVip == true)
                {
                    if (context.ChangeType == ChangeType.Added)
                        _context.Rooms.Remove(context.Entity);
                    if (context.ChangeType == ChangeType.Modified)
                    {
                        _context.Entry(context.Entity).Property(r => r.Name).IsModified = false;
                        _context.Entry(context.Entity).Property(r => r.Prices).IsModified = false;
                        _context.Entry(context.Entity).Property(r => r.Seats).IsModified = false;
                        _context.Entry(context.Entity).Property(r => r.IsVip).IsModified = false;
                        _context.Entry(context.Entity).Property(r => r.Bookings).IsModified = false;
                        _context.Entry(context.Entity).Property(r => r.Type).IsModified = false;
                    }
                }
            }         
            return Task.CompletedTask;
        }
    }
}
