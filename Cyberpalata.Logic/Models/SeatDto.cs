namespace Cyberpalata.Logic.Models
{
    public class SeatDto
    {
        public SeatDto(int number)
        {
            Number = number;
        }

        public Guid Id { get; set; }
        public int Number { get; set; }
    }
}
