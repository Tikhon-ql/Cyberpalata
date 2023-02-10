using Cyberpalata.Logic.Models.Booking;
using System.ComponentModel.DataAnnotations;

namespace Cyberpalata.Logic.Models.Identity.User
{
    public class ApiUserDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = "";
        public string Surname { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Password { get; set; } = "";
        public List<BookingDto> Bookings { get; set; } = new();
    }
}
