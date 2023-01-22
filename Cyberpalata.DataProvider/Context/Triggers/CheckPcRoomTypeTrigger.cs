using Cyberpalata.Common.Enums;
using Cyberpalata.DataProvider.Models.Devices;
using EntityFrameworkCore.Triggered;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Context.Triggers
{
    internal class CheckPcRoomTypeTrigger : IBeforeSaveTrigger<Pc>
    {
        private readonly ApplicationDbContext _context;
        public CheckPcRoomTypeTrigger(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task BeforeSave(ITriggerContext<Pc> context, CancellationToken cancellationToken)
        {
            if (context.ChangeType == ChangeType.Added || context.ChangeType == ChangeType.Modified)
            {
                if (context.Entity.GamingRoom.Type != RoomType.GamingRoom)
                {
                    if (context.ChangeType == ChangeType.Added)
                        _context.Pcs.Remove(context.Entity);
                    if (context.ChangeType == ChangeType.Modified)
                    {
                        _context.Entry(context.Entity).Property(p => p.Gpu).IsModified = false;
                        _context.Entry(context.Entity).Property(p => p.Cpu).IsModified = false;
                        _context.Entry(context.Entity).Property(p => p.Ram).IsModified = false;
                        _context.Entry(context.Entity).Property(p => p.Ssd).IsModified = false;
                        _context.Entry(context.Entity).Property(p => p.Hdd).IsModified = false;
                        _context.Entry(context.Entity).Property(p => p.GamingRoom).IsModified = false;
                    }
                }
            }    
            return Task.CompletedTask;
        }
    }
}
