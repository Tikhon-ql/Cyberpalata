using System.ComponentModel.DataAnnotations;

namespace Cyberpalata.ViewModel.Request.Room
{
    public class SearchRoomViewModel
    {
        [Required]
        public int Count { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public TimeSpan Begining { get; set; }
        [Required]
        public int HoursCount { get; set; }
    }
}
