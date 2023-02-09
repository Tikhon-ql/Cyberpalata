using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Cyberpalata.Common.Enums;

namespace Cyberpalata.DataProvider.Models
{
    public class MenuItem : BaseEntity
    {
        //[Key] 
        //[Required] 
        //public Guid Id { get; set; }
        [Required] 
        [MaxLength(50)] 
        public string Name { get; set; }
        [Required] 
        public decimal Cost { get; set; }
        [Required]
        public int TypeId { get; set; }
        [ForeignKey("TypeId")]
        public virtual MenuItemType Type { get; set; }
    }
}