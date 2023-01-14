using Cyberpalata.DataProvider.Models.Devices;
using Cyberpalata.DataProvider.Models.Peripheral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cyberpalata.DataProvider.Models;
using Cyberpalata.DataProvider.Models.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;

namespace Cyberpalata.DataProvider.Context
{
    internal class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Pc> Pcs { get; set; }

        public DbSet<Game> Games { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Periphery> Peripheries { get; set; }  
        public DbSet<GameConsole> GameConsoles { get; set; }

        public DbSet<ApiUser> Users { get; set; }
        public DbSet<UserRefreshToken> RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().Property(g => g.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Pc>().Property(p => p.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Periphery>().Property(p => p.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Price>().Property(p => p.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<GameConsole>().Property(g => g.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Room>().Property(p => p.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<ApiUser>().Property(a => a.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<UserRefreshToken>().Property(t => t.Id).HasDefaultValueSql("NEWID()");

            //modelBuilder.Entity<GameConsoleRoom>().Property(g => g.Id).HasDefaultValueSql("NEWID()");

            //modelBuilder.Entity<GameConsoleRoom>().HasMany(g=>g.Consoles).WithOne(gc=>gc.ConsoleRoom);

            //modelBuilder.Entity<GameConsoleRoom>().HasData(new GameConsoleRoom { Id = new Guid("399ce32f-1610-44dd-b634-4ffdc223038b"),Name = "ConsoleRoom1" });

            base.OnModelCreating(modelBuilder);
        }
    }
}
