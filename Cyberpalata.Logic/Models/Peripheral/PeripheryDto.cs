using Cyberpalata.Common.Enums;

namespace Cyberpalata.Logic.Models.Peripheral
{
    public class PeripheryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public PeripheryType Type { get; set; }
    }
}
