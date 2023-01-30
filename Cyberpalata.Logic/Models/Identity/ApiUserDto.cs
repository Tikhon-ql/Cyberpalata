using Cyberpalata.Logic.Models.Booking;
using System.ComponentModel.DataAnnotations;

namespace Cyberpalata.Logic.Models.Identity
{
    public class ApiUserDto
    {
        public Guid Id { get; set; }
        [Required] public string Username { get; set; } = "";
        //[Required] public string Surname { get; set; } = "";

        [Required]
        [RegularExpression("^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$")]
        public string Email { get; set; } = "";

        //[Required]
        [RegularExpression(pattern: "^[\\+]?[(]?[0-9]{3}[)]?[-\\s\\.]?[0-9]{3}[-\\s\\.]?[0-9]{4,6}$")]
        public string Phone { get; set; } = "";

        //[Required]
        public string Password { get; set; } = "";
        public List<BookingDto> Bookings { get; set; } = new();
    }
}
