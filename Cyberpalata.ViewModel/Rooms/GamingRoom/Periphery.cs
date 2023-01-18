namespace Cyberpalata.ViewModel.Rooms.GamingRoom
{
    public class Periphery
    {
        public Periphery(string name, string typeName)
        {
            Name = name;
            TypeName = typeName;
        }
        public string? Name { get; set; }
        public string? TypeName { get; set; }
    }
}
