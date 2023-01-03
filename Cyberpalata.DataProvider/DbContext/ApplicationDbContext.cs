using Cyberpalata.DataProvider.Models.Devices;
using Cyberpalata.DataProvider.Models.Peripheral;
using Cyberpalata.DataProvider.Models.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cyberpalata.DataProvider.Models;
using Cyberpalata.DataProvider.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Security.Policy;

namespace Cyberpalata.DataProvider.DbContext
{
    internal class ApplicationDbContext : IdentityDbContext<ApiUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //public DbSet<GamingRoom> GamingRooms { get; set; }
        //public DbSet<GameConsoleRoom> GameConsoleRooms { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Pc> Pcs { get; set; }

        //public DbSet<GameConsole> GameConsoles { get; set; }
        public DbSet<Game> Games { get; set; }
        //public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Price> Prices { get; set; }
        //public DbSet<Seat> Seats { get; set; }
        public DbSet<Periphery> Peripheries { get; set; }  
        public DbSet<GameConsole> GameConsoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().Property(g => g.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Pc>().Property(p => p.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Periphery>().Property(p => p.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Price>().Property(p => p.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<GameConsole>().Property(g => g.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<GameConsoleRoom>().Property(g => g.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Ignore<IdentityUserLogin<string>>();
            modelBuilder.Ignore<IdentityUserRole<string>>();

            modelBuilder.Entity<GameConsoleRoom>().HasMany(g=>g.Consoles).WithOne(gc=>gc.ConsoleRoom);

            modelBuilder.Entity<GameConsoleRoom>().HasData(new GameConsoleRoom { Id = new Guid("399ce32f-1610-44dd-b634-4ffdc223038b"),Name = "ConsoleRoom1" });

            base.OnModelCreating(modelBuilder);
        }
    }
}
