using Cyberpalata.DataProvider.Models.Devices;
using Cyberpalata.DataProvider.Models.Peripheral;
using Cyberpalata.DataProvider.Models;
using Cyberpalata.DataProvider.Models.Identity;
using Microsoft.EntityFrameworkCore;
using Cyberpalata.Common.Enums;

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
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureIdAutoGeneration(modelBuilder);
            UniqueIndexesCreating(modelBuilder);
            ConfigureRelationships(modelBuilder);
            ConstraintsConfiguration(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private void ConfigureRelationships(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>().HasMany(r => r.Prices).WithOne(p => p.Room);
            modelBuilder.Entity<Room>().HasMany(r => r.Seats).WithOne(s => s.Room);
            modelBuilder.Entity<Room>().HasOne(r => r.Type).WithMany();
            modelBuilder.Entity<Room>().HasMany(r => r.Bookings).WithOne().OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Pc>().HasOne(pc => pc.GamingRoom).WithMany();
            modelBuilder.Entity<Periphery>().HasOne(p => p.GamingRoom).WithMany();
            modelBuilder.Entity<GameConsole>().HasOne(gc => gc.ConsoleRoom).WithMany();

            modelBuilder.Entity<UserRefreshToken>().HasOne(urt => urt.User).WithMany();
            modelBuilder.Entity<Periphery>().HasOne(p => p.Type).WithMany();

            modelBuilder.Entity<Booking>().HasMany(b => b.Seats).WithMany()
                .UsingEntity<Dictionary<string, object>>("SeatsBookings",
                j => j.HasOne<Seat>().WithMany().OnDelete(DeleteBehavior.NoAction),
                j => j.HasOne<Booking>().WithMany().OnDelete(DeleteBehavior.NoAction));

            modelBuilder.Entity<Booking>().HasMany(b=>b.GamesToDownloadBefore).WithMany();
            modelBuilder.Entity<Booking>().HasOne(b => b.Tariff).WithOne().HasForeignKey<Booking>();
            //modelBuilder.Entity<Booking>().HasOne().WithMany(r => r.Bookings);
          
        }

        private void ConfigureIdAutoGeneration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().Property(g => g.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Pc>().Property(p => p.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Periphery>().Property(p => p.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Price>().Property(p => p.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<GameConsole>().Property(g => g.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Room>().Property(p => p.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<ApiUser>().Property(a => a.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<UserRefreshToken>().Property(t => t.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Booking>().Property(t => t.Id).HasDefaultValueSql("NEWID()");
        }

        private void ConstraintsConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>().HasCheckConstraint("IsVip","TypeId = 3");
        }

        private void UniqueIndexesCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRefreshToken>().HasIndex(urf => urf.RefreshToken).IsUnique();
            modelBuilder.Entity<ApiUser>().HasIndex(user=>user.Email).IsUnique();
        }
    }
}
