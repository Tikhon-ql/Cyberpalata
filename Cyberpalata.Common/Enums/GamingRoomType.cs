namespace Cyberpalata.Common.Enums
{
    public class GamingRoomType : Enumeration
    {
        public static GamingRoomType Vip = new(1, nameof(Vip));
        public static GamingRoomType Common = new(2, nameof(Common));
        public GamingRoomType(int id, string name) : base(id, name)
        {
        }
    }
}
