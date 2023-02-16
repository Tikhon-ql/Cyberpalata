namespace Cyberpalata.ViewModel.Response.Rooms.GamingRoom
{
    public class PcViewModel
    {
        public PcViewModel(string type, string name)
        {
            Type = type;
            Name = name;
        }
        public string Type { get; set; }
        public string Name { get; set; }
    }
}
