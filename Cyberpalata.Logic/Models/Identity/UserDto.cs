using Cyberpalata.Logic.Models.Booking;
using Cyberpalata.Logic.Models.Tournament;
using System.ComponentModel.DataAnnotations;

namespace Cyberpalata.Logic.Models.Identity
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = String.Empty;
        public string Surname { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Phone { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public List<BookingDto> Bookings { get; set; } = new();
        public RoleDto Role { get; set; } = new();
        public TeamDto Team { get; set; } = new();
    }
}
