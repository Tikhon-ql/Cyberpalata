﻿using Cyberpalata.Common.Enums;
using Cyberpalata.DataProvider.Models;
using Cyberpalata.DataProvider.Models.Devices;
using Cyberpalata.Logic.Models.Booking;
using Cyberpalata.Logic.Models.Devices;
using Cyberpalata.Logic.Models.Peripheral;
using System.ComponentModel.DataAnnotations;

namespace Cyberpalata.Logic.Models
{
    public class RoomDto
    {
        [Key] public Guid Id { get; set; }
        [Required][MaxLength(50)] public string Name { get; set; }
        //[Required] public RoomType Type { get; set; }
        public bool IsVip { get; set; }
        public List<PriceDto> Prices { get; set; } = new List<PriceDto>();
        public List<SeatDto> Seats { get; set; } = new List<SeatDto>();
        public List<BookingDto> Bookings { get; set; } = new List<BookingDto>();
        public List<GameConsoleDto> Consoles { get; set; }
        public List<PcDto> Pcs { get; set; }
        public List<PeripheryDto> Peripheries { get; set; }
    }
}
