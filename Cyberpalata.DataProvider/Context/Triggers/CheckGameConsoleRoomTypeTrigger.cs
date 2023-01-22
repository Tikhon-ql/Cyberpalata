using Cyberpalata.Common.Enums;
using Cyberpalata.DataProvider.Models.Devices;
using EntityFrameworkCore.Triggered;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Context.Triggers
{
    internal class CheckGameConsoleRoomTypeTrigger : IBeforeSaveTrigger<GameConsole>
    {
        private readonly ApplicationDbContext _context;
        public CheckGameConsoleRoomTypeTrigger(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task BeforeSave(ITriggerContext<GameConsole> context, CancellationToken cancellationToken)
        {
            if (context.ChangeType == ChangeType.Added || context.ChangeType == ChangeType.Modified)
            {
                if (context.Entity.ConsoleRoom.Type != RoomType.GameConsoleRoom)
                {
                    if (context.ChangeType == ChangeType.Added)
                        _context.GameConsoles.Remove(context.Entity);
                    if (context.ChangeType == ChangeType.Modified)
                    {
                        _context.Entry(context.Entity).Property(gc => gc.ConsoleName).IsModified = false;
                        _context.Entry(context.Entity).Property(gc => gc.ConsoleRoom).IsModified = false;
                    }
                }
            }
            return Task.CompletedTask;
        }
    }
}
