﻿using System.ComponentModel.DataAnnotations;

namespace Cyberpalata.DataProvider.Models.Identity
{
    public class ApiUser
    {
        [Key]
        [Required] 
        public Guid Id { get; set; }
        [Required] 
        public string Username { get; set; }
        [Required] 
        public string Surname { get; set; }

        [Required]
        [RegularExpression("^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(pattern: "^[\\+]?[(]?[0-9]{3}[)]?[-\\s\\.]?[0-9]{3}[-\\s\\.]?[0-9]{4,6}$")]
        public string Phone { get; set; }

        [Required] 
        public string Password { get; set; }
        [Required] 
        public string Salt { get; set; }
        public virtual List<Booking> Bookings { get; set; }
    }
}
