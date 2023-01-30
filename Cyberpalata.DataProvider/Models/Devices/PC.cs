﻿using CSharpFunctionalExtensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cyberpalata.DataProvider.Models.Devices
{
    public class Pc
    {
        [Key]
        [Required] 
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Gpu { get; set; } = String.Empty;
        [Required]
        [MaxLength(50)] 
        public string Cpu { get; set; } = String.Empty;
        [Required]
        [MaxLength(50)] 
        public string Ram { get; set; } = String.Empty;
        [Required]
        [MaxLength(50)] 
        public string Hdd { get; set; } = String.Empty;
        [Required]
        [MaxLength(50)] 
        public string Ssd { get; set; } = String.Empty;
        [ForeignKey("RoomId")]
        public virtual Room Room { get; set; } 
    }
}
