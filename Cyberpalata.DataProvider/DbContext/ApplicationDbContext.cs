using Cyberpalata.DataProvider.Models.Devices;
using Cyberpalata.DataProvider.Models.Peripheral;
using Cyberpalata.DataProvider.Models.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cyberpalata.DataProvider.Models;

namespace Cyberpalata.DataProvider.DbContext
{
    internal class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        //public DbSet<GamingRoom> GamingRooms { get; set; }
        //public DbSet<GameConsoleRoom> GameConsoleRooms { get; set; }
        //public DbSet<Pc> Pcs { get; set; }
        //public DbSet<GameConsole> GameConsoles { get; set; }
        public DbSet<Game> Games { get; set; }
        //public DbSet<MenuItem> MenuItems { get; set; }
        //public DbSet<Price> Prices { get; set; }
        //public DbSet<Seat> Seats { get; set; }
        //public DbSet<Periphery> Peripheries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().Property(g => g.Id).HasDefaultValueSql("NEWID()");
        }
    }
}
