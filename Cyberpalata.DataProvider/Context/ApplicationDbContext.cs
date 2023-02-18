using Cyberpalata.Common.Enums;
using Cyberpalata.DataProvider.Models.Devices;
using Cyberpalata.DataProvider.Models.Identity;
using Cyberpalata.DataProvider.Models.Peripheral;
using Cyberpalata.DataProvider.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cyberpalata.DataProvider.Models.Tournaments;

namespace Cyberpalata.DataProvider.Context
{
    internal class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = true;
        }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Pc> Pcs { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Periphery> Peripheries { get; set; }
        public DbSet<GameConsole> GameConsoles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRefreshToken> RefreshTokens { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Prize> Prizes { get;set; }
        public DbSet<HtmlContent> Htmls { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            UniqueIndexesCreating(modelBuilder);
            ConfigureRelationships(modelBuilder);
            ConstraintsConfiguration(modelBuilder);
            InitialData(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private void ConfigureRelationships(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>().HasOne(b => b.Room).WithMany(r => r.Bookings).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Booking>().HasMany(b => b.Seats).WithMany(s => s.Bookings)
                  .UsingEntity<Dictionary<Guid, Guid>>("SeatsBookings",
                  j => j.HasOne<Seat>().WithMany().OnDelete(DeleteBehavior.NoAction),
                  j => j.HasOne<Booking>().WithMany().OnDelete(DeleteBehavior.NoAction));

            modelBuilder.Entity<Tournament>().HasMany(t => t.Teams).WithMany(t => t.Tournaments)
                    .UsingEntity<Dictionary<Guid, Guid>>("TeamsTournaments",
                    j => j.HasOne<Team>().WithMany().OnDelete(DeleteBehavior.NoAction),
                    j => j.HasOne<Tournament>().WithMany().OnDelete(DeleteBehavior.NoAction));

            modelBuilder.Entity<TeamMember>().HasOne(t => t.Member).WithMany().OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Tournament>().HasOne(t => t.Winner).WithMany();

            modelBuilder.Entity<User>().HasMany(u => u.Roles).WithMany();

            //modelBuilder.Entity<Room>().HasMany(r => r.Prices).WithOne(p => p.Room);
            //modelBuilder.Entity<Room>().HasMany(r => r.Seats).WithOne(s => s.Room);
            //modelBuilder.Entity<Room>().HasOne(r => r.Type).WithMany();

            ////modelBuilder.Entity<Room>().HasMany(r => r.Bookings).WithOne().OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<Periphery>().HasOne(p => p.GamingRoom).WithMany();
            //modelBuilder.Entity<GameConsole>().HasOne(gc => gc.ConsoleRoom).WithMany();

            modelBuilder.Entity<UserRefreshToken>().HasOne(urt => urt.User).WithMany().OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Booking>().HasOne(b => b.User).WithMany(u => u.Bookings).OnDelete(DeleteBehavior.Cascade);
            //modelBuilder.Entity<Periphery>().HasOne(p => p.Type).WithMany();



            ////modelBuilder.Entity<Booking>().HasMany(b => b.Seats).WithMany(s => s.Bookings);
            //modelBuilder.Entity<Booking>().HasMany(b => b.GamesToDownloadBefore).WithMany();
            //modelBuilder.Entity<Booking>().HasOne(b => b.Tariff).WithOne().HasForeignKey<Booking>();
            //modelBuilder.Entity<Booking>().HasOne(b => b.Room).WithMany(r => r.Bookings).OnDelete(DeleteBehavior.NoAction);
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

            string resetPasswordHtml = @$"<html>
                                    <div>
                                        <a href='http://localhost:3000/passwordReset' class='btn btn-outline-dark btn-sm text-white w-50 m-1'>Reset password</a>
                                    </div>
                                </html>";
            string emailVerificationHtml = @$"<html>
                                <div>
                                    <h1>Your verification code:</h1>
                                    <div><b></b></div>
                                </div>
                            </html>";
            modelBuilder.Entity<HtmlContent>().HasData(new HtmlContent { Id = "ResetPasswordHtml",Html = resetPasswordHtml });
            modelBuilder.Entity<HtmlContent>().HasData(new HtmlContent { Id = "EmailVerificationHtml", Html = emailVerificationHtml });

            var user1 = new User
            {
                Id = Guid.NewGuid(),
                Username = "user1",
                Surname = "Userovich",
                Email = "user1@mail.ru",
                Phone = "+375257175402",
                Salt = "salt1",
                Password = "password1salt1",
                IsActivated= true,
            };
            var user2 = new User
            {
                Id = Guid.NewGuid(),
                Username = "user2",
                Surname = "Userovich2",
                Email = "user2@mail.ru",
                Phone = "+375257175402",
                Salt = "salt2",
                Password = "password2salt2",
                IsActivated = true,
            };
            var user3 = new User
            {
                Id = Guid.NewGuid(),
                Username = "user3",
                Surname = "Userovich3",
                Email = "user3@mail.ru",
                Phone = "+375257175402",
                Salt = "salt3",
                Password = "password3salt3",
                IsActivated = true,
            };

            var user4 = new User
            {
                Id = Guid.NewGuid(),
                Username = "user4",
                Surname = "Userovich4",
                Email = "user4@mail.ru",
                Phone = "+375257175402",
                Salt = "salt4",
                Password = "password4salt4",
                IsActivated = true,
            };

            var user5 = new User
            {
                Id = Guid.NewGuid(),
                Username = "user5",
                Surname = "Userovich5",
                Email = "user5@mail.ru",
                Phone = "+375257175402",
                Salt = "salt5",
                Password = "password5salt5",
                IsActivated = true,
            };

            var user6 = new User
            {
                Id = Guid.NewGuid(),
                Username = "user6",
                Surname = "Userovich6",
                Email = "user6@mail.ru",
                Phone = "+375257175402",
                Salt = "salt6",
                Password = "password6salt6",
                IsActivated = true,
            };

            var userRole = new Role { Id = Guid.NewGuid(), Name = "User" };
            var adminRole = new Role { Id = Guid.NewGuid(), Name= "Admin" };
            modelBuilder.Entity<Role>().HasData(userRole);
            modelBuilder.Entity<Role>().HasData(adminRole);
            //{ code}
        }/*{_configuration["PasswordResetPageUrl"]}*/

        private void UniqueIndexesCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRefreshToken>().HasIndex(urf => urf.RefreshToken).IsUnique();
        }
    }
}
