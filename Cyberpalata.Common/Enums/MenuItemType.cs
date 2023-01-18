namespace Cyberpalata.Common.Enums
{
    public class MenuItemType : Enumeration
    {
        public static MenuItemType Drink = new(1, nameof(Drink));
        public static MenuItemType Food = new(2, nameof(Food));

        public MenuItemType(int id, string name) : base(id, name)
        {
        }
    }
}
