namespace Cyberpalata.ViewModel.Response.Rooms.GamingRoom
{
    public class GamingRoomViewModel
    {
        public List<PcViewModel> PcInfos { get; set; }
        public List<PeripheryViewModel> Peripheries { get; set; } = new();
    }
}
