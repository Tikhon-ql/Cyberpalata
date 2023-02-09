using System.ComponentModel.DataAnnotations;

namespace Cyberpalata.DataProvider.Models
{
    public class Game : BaseEntity
    {
        //[Key] 
        //[Required] 
        //public Guid Id { get; set; }
        [MaxLength(50)] 
        [Required] 
        public string GameName { get; set; }
    }
}
