using System.ComponentModel.DataAnnotations;
using Cyberpalata.Common.Enums;

namespace Cyberpalata.DataProvider.Models
{
    public class MenuItem
    {
        [Key] 
        [Required] 
        public Guid Id { get; set; }
        [Required] 
        [MaxLength(50)] 
        public string Name { get; set; }
        [Required] 
        public decimal Cost { get; set; }
        [Required] 
        public virtual MenuItemType Type { get; set; }
    }
}