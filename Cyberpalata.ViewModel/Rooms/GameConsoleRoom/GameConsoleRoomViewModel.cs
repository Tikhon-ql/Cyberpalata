namespace Cyberpalata.ViewModel.Rooms.GameConsoleRoom
{
    public class GameConsoleRoomViewModel
    {
        public List<string> GameConsoles { get; set; } = new();
        public List<PriceViewModel> Prices { get; set; } = new();
    }
}
