namespace Cyberpalata.ViewModel.Rooms.GamingRoom
{
    public class GamingRoomViewModel
    {
        public List<PcInfo> PcInfos { get; set; }
        public List<Periphery> Peripheries { get; set; } = new();
        public List<Price> Prices { get; set; } = new();
        public List<int> Seats { get; set; } = new();
    }
}
