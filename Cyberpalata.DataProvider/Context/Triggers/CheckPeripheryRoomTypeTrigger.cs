using Cyberpalata.Common.Enums;
using Cyberpalata.DataProvider.Models.Peripheral;
using EntityFrameworkCore.Triggered;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Context.Triggers
{
    internal class CheckPeripheryRoomTypeTrigger : IBeforeSaveTrigger<Periphery>
    {
        private readonly ApplicationDbContext _context;
        public CheckPeripheryRoomTypeTrigger(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task BeforeSave(ITriggerContext<Periphery> context, CancellationToken cancellationToken)
        {
            if(context.ChangeType == ChangeType.Added || context.ChangeType == ChangeType.Modified)
            {
                if (context.Entity.GamingRoom.Type != RoomType.GamingRoom)
                {
                    if (context.ChangeType == ChangeType.Added)
                        _context.Peripheries.Remove(context.Entity);
                    if (context.ChangeType == ChangeType.Modified)
                    {
                        _context.Entry(context.Entity).Property(p => p.Name).IsModified = false;
                        _context.Entry(context.Entity).Property(p => p.Type).IsModified = false;
                        _context.Entry(context.Entity).Property(p => p.GamingRoom).IsModified = false;
                    }
                }
            }         
            return Task.CompletedTask;
        }
    }
}
