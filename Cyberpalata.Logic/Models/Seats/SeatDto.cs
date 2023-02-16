using Cyberpalata.DataProvider.Models;
using System.ComponentModel.DataAnnotations;

namespace Cyberpalata.Logic.Models.Seats
{
    public class SeatDto
    {
        public Guid Id { get; set; }
        [Required] 
        public int Number { get; set; }
        //A.K.
        public bool IsFree { get; set; } = true;//???
    }
}
