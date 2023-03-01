using System.ComponentModel.DataAnnotations;

namespace Cyberpalata.DataProvider.Models
{
    public class Game : BaseEntity
    {
        [MaxLength(50)] 
        [Required] 
        public string GameName { get; set; }
        public string ImageUrl { get; set; }
    }
}
