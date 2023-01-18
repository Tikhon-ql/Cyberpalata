namespace Cyberpalata.Logic.Models
{
    public class GameDto
    {
        public GameDto(string gameName)
        {
            GameName = gameName;
        }

        public Guid Id { get; set; }
        public string GameName { get; set; }
    }
}
