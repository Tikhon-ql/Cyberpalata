using Cyberpalata.Common.Enums;

namespace Cyberpalata.Logic.Models
{
    public class MenuItemDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }

        public MenuItemType Type { get; set; } = MenuItemType.Food;
    }
}
