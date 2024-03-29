﻿using Cyberpalata.Logic.Models.Identity;
using Cyberpalata.Logic.Models.Room;
using Cyberpalata.Logic.Models.Seats;
using System.ComponentModel.DataAnnotations;

namespace Cyberpalata.Logic.Models.Booking
{
    public class BookingDto
    {
        public Guid Id { get; set; }
        [Required]
        public UserDto User { get; set; } = new();
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public TimeSpan Begining { get; set; }
        [Required]
        public int HoursCount { get; set; }
        [Required]
        public RoomDto Room { get; set; } = new();     
        [Required]
        public decimal Price { get; set; }
        public bool IsPaid { get; set; }
        [Required]
        public List<SeatDto> Seats { get; set; } = new();
        public List<GameDto> GamesToDownloadBefore { get; set; } = new();
        public bool IsExpired { get; set; }
    }
}
