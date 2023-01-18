namespace Cyberpalata.Logic.Models
{
    public class RoomDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }


        public virtual List<PriceDto> Prices { get; set; } = new();
        public virtual List<SeatDto> Seats { get; set; } = new();
    }
}
