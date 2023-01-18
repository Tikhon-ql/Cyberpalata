namespace Cyberpalata.ViewModel.Rooms.GamingRoom
{
    public class PcInfo
    {
        public PcInfo(string type, string name)
        {
            Type = type;
            Name = name;
        }
        public string Type { get; set; }
        public string Name { get; set; }
    }
}
