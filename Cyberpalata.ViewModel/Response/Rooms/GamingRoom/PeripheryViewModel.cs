namespace Cyberpalata.ViewModel.Response.Rooms.GamingRoom
{
    public class PeripheryViewModel
    {
        public PeripheryViewModel(string name, string typeName)
        {
            Name = name;
            TypeName = typeName;
        }
        public string? Name { get; set; }
        public string? TypeName { get; set; }
    }
}
