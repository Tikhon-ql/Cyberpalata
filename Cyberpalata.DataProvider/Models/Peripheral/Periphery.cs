using System.ComponentModel.DataAnnotations;
using Cyberpalata.Common.Enums;
using Cyberpalata.DataProvider.Models.Rooms;

namespace Cyberpalata.DataProvider.Models.Peripheral
{
    public class Periphery
    {
        [Key] [Required] public Guid Id { get; set; }
        [MaxLength(50)] [Required] public string? Name { get; set; }
        [Required] public PeripheryType Type { get; set; }
        public Room GamingRoom { get; set; }
    }
}
