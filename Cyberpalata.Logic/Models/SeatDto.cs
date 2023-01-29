﻿using Cyberpalata.DataProvider.Models;
using System.ComponentModel.DataAnnotations;

namespace Cyberpalata.Logic.Models
{
    public class SeatDto
    {
        public Guid Id { get; set; }
        [Required] public int Number { get; set; }
        public bool IsFree { get; set; } = false;
    }
}
