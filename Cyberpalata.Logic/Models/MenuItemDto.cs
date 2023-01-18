using Cyberpalata.Common.Enums;

namespace Cyberpalata.Logic.Models
{
    public class MenuItemDto
    {
        public MenuItemDto(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }

        public MenuItemType Type { get; set; } = MenuItemType.Food;
    }
}
