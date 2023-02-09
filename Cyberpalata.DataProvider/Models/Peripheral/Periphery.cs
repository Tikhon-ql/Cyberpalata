using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Cyberpalata.Common.Enums;

namespace Cyberpalata.DataProvider.Models.Peripheral
{
    public class Periphery : BaseEntity
    {
        //[Key]
        //[Required]
        //public Guid Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string? Name { get; set; }
        [Required]
        public int TypeId { get; set; }
        [ForeignKey("TypeId")]
        public virtual PeripheryType Type { get; set; }
        public Guid RoomId { get; set; }
        [ForeignKey("RoomId")]
        public virtual Room GamingRoom { get; set; }
    }
}
