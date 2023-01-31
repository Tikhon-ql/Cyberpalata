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
        public DbSet<Seat> Seats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            ConfigureIdAutoGeneration(modelBuilder);
            UniqueIndexesCreating(modelBuilder);
            ConfigureRelationships(modelBuilder);
            ConstraintsConfiguration(modelBuilder);
            InitialData(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private void ConfigureRelationships(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Room>().HasMany(r => r.Prices).WithOne(p => p.Room);
            modelBuilder.Entity<Room>().HasMany(r => r.Seats).WithOne(s => s.Room);
            modelBuilder.Entity<Room>().HasOne(r => r.Type).WithMany();
            //modelBuilder.Entity<Room>().HasOne(r => r.Pc).WithOne(p=>p.Room).HasForeignKey<Pc>().OnDelete(DeleteBehavior.NoAction); ;
            //modelBuilder.Entity<Room>().HasMany(r => r.Bookings).WithOne().OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Periphery>().HasOne(p => p.GamingRoom).WithMany();
            modelBuilder.Entity<GameConsole>().HasOne(gc => gc.ConsoleRoom).WithMany();

            modelBuilder.Entity<UserRefreshToken>().HasOne(urt => urt.User).WithMany();
            modelBuilder.Entity<Periphery>().HasOne(p => p.Type).WithMany();

            modelBuilder.Entity<Booking>().HasMany(b => b.Seats).WithMany(s=>s.Bookings)
                .UsingEntity<Dictionary<Guid, Guid>>("SeatsBookings",
                j => j.HasOne<Seat>().WithMany().OnDelete(DeleteBehavior.NoAction),
                j => j.HasOne<Booking>().WithMany().OnDelete(DeleteBehavior.NoAction));

            //modelBuilder.Entity<Booking>().HasMany(b => b.Seats).WithMany(s => s.Bookings);
            modelBuilder.Entity<Booking>().HasMany(b => b.GamesToDownloadBefore).WithMany();
            modelBuilder.Entity<Booking>().HasOne(b => b.Tariff).WithOne().HasForeignKey<Booking>();
            modelBuilder.Entity<Booking>().HasOne(b=>b.Room).WithMany(r => r.Bookings).OnDelete(DeleteBehavior.NoAction);


          
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
            //modelBuilder.Entity<Booking>().Property(t => t.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Seat>().Property(s => s.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Seat>().Property(s => s.Number).ValueGeneratedOnAdd();
        }

        private void ConstraintsConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>().HasCheckConstraint("IsVip", "IsVip = 0 or(IsVip = 1 and TypeId between 2 and 3)");
        }

        private void InitialData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoomType>().HasData(RoomType.Lounge);
            modelBuilder.Entity<RoomType>().HasData(RoomType.GameConsoleRoom);
            modelBuilder.Entity<RoomType>().HasData(RoomType.GamingRoom);

            modelBuilder.Entity<PeripheryType>().HasData(PeripheryType.Headphone);
            modelBuilder.Entity<PeripheryType>().HasData(PeripheryType.Keypad);
            modelBuilder.Entity<PeripheryType>().HasData(PeripheryType.Mouse);
            modelBuilder.Entity<PeripheryType>().HasData(PeripheryType.Screen);
            modelBuilder.Entity<PeripheryType>().HasData(PeripheryType.Chair);
        }

        private void UniqueIndexesCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRefreshToken>().HasIndex(urf => urf.RefreshToken).IsUnique();
            modelBuilder.Entity<ApiUser>().HasIndex(user=>user.Email).IsUnique();
        }
    }
}
