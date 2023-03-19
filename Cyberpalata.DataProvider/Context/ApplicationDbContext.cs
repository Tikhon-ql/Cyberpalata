using Cyberpalata.Common.Enums;
using Cyberpalata.DataProvider.Models.Devices;
using Cyberpalata.DataProvider.Models.Identity;
using Cyberpalata.DataProvider.Models.Peripheral;
using Cyberpalata.DataProvider.Models;
using Microsoft.EntityFrameworkCore;
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
        public DbSet<HtmlContent> Htmls { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<BatleResult> BatleResults { get; set; }
        public DbSet<TeamJoinRequest> Requests { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            UniqueIndexesCreating(modelBuilder);
            ConfigureRelationships(modelBuilder);
            ConstraintsConfiguration(modelBuilder);
            InitialData(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private void ConfigureIdAutoGeneration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeamMember>().Property(r => r.Id).HasDefaultValueSql("NEWID()");
        }

        private void ConfigureRelationships(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>().HasOne(b => b.Room).WithMany(r => r.Bookings).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Booking>().HasMany(b => b.Seats).WithMany(s => s.Bookings)
                  .UsingEntity<Dictionary<Guid, Guid>>("SeatsBookings",
                  j => j.HasOne<Seat>().WithMany().OnDelete(DeleteBehavior.NoAction),
                  j => j.HasOne<Booking>().WithMany().OnDelete(DeleteBehavior.NoAction));
            
            modelBuilder.Entity<Chat>().HasOne(c => c.UserToJoin).WithMany().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Message>().HasOne(c => c.Sender).WithMany().OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Batle>().HasOne(b=>b.FirstTeam).WithMany().OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Batle>().HasOne(b=>b.SecondTeam).WithMany().OnDelete(DeleteBehavior.SetNull);

            //modelBuilder.Entity<TeamJoinRequest>().HasOne(tjr => tjr.TeamMember).WithMany().OnDelete(DeleteBehavior.NoAction);
            //modelBuilder.Entity<Tournament>().HasOne(t => t.Winner).WithMany();
            //modelBuilder.Entity<UserRefreshToken>().HasOne(urt => urt.User).WithMany().OnDelete(DeleteBehavior.Cascade);
            //modelBuilder.Entity<Booking>().HasOne(b => b.User).WithMany(u => u.Bookings).OnDelete(DeleteBehavior.Cascade);
            //modelBuilder.Entity<Chat>().HasOne(c => c.UserToJoin).WithOne().OnDelete(DeleteBehavior.NoAction);
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

            modelBuilder.Entity<JoinRequestState>().HasData(JoinRequestState.InProgress);
            modelBuilder.Entity<JoinRequestState>().HasData(JoinRequestState.Accepted);
            modelBuilder.Entity<JoinRequestState>().HasData(JoinRequestState.Rejected);
            modelBuilder.Entity<JoinRequestState>().HasData(JoinRequestState.None);

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
            modelBuilder.Entity<HtmlContent>().HasData(new HtmlContent { Id = "ResetPasswordHtml", Html = resetPasswordHtml });
            modelBuilder.Entity<HtmlContent>().HasData(new HtmlContent { Id = "EmailVerificationHtml", Html = emailVerificationHtml });

            //var rooms = new List<Room>();
            //for (int i = 0; i < 10; i++)
            //{
            //    rooms.Add(new Room
            //    {
            //        Id = Guid.NewGuid(),
            //        Name = $"Generated room {i + 1}",
            //        TypeId = 3,
            //        IsVip = true,
            //    });
            //}

            //modelBuilder.Entity<Room>().HasData(rooms); 
            //for(int i = 0;i < rooms.Count();i++)
            //{
            //    var seatList = new List<Seat>();
            //    for (int j = 0; j < 30; j++)
            //    {
            //        seatList.Add(new Seat
            //        {
            //            Id = Guid.NewGuid(),
            //            Number = j + 1,
            //            RoomId = rooms.ElementAt(i).Id,
            //        });
            //    }
            //    modelBuilder.Entity<Seat>().HasData(seatList);
            //}



            //var userRole = new Role { Id = Guid.NewGuid(), Name = "User" };
            //var adminRole = new Role { Id = Guid.NewGuid(), Name= "Admin" };
            //modelBuilder.Entity<Role>().HasData(userRole);
            //modelBuilder.Entity<Role>().HasData(adminRole);
            //{ code}
        }/*{_configuration["PasswordResetPageUrl"]}*/

        private void UniqueIndexesCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRefreshToken>().HasIndex(urf => urf.RefreshToken).IsUnique();
        }
    }
}
