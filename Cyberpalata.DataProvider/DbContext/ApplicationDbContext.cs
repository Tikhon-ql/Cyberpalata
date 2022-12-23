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
    public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Room> Rooms { get; set; }
        //public DbSet<GamingModule> GamingModules { get; set; }
        //public DbSet<GamingModule> ConsoleModules { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<MenuItem> MenuPositions { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Periphery> Peripheries { get; set; }
    }
}
