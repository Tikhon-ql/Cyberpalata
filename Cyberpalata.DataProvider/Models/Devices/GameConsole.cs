﻿using System.ComponentModel.DataAnnotations;
using Cyberpalata.DataProvider.Models.Rooms;

namespace Cyberpalata.DataProvider.Models.Devices
{
    public class GameConsole
    {
        [Key][Required] public Guid Id { get; set; }
        [MaxLength(50)] [Required] public string ConsoleName { get; set; }
        public virtual Room ConsoleRoom { get; set; }
    }
}