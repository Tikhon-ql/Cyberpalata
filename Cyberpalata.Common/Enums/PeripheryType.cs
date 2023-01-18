namespace Cyberpalata.Common.Enums
{
    public class PeripheryType : Enumeration
    {
        public static PeripheryType Headphone = new(1, nameof(Headphone));
        public static PeripheryType Keypad = new(2, nameof(Keypad));
        public static PeripheryType Mouse = new(3, nameof(Mouse));
        public static PeripheryType Screen = new(4, nameof(Screen));
        public static PeripheryType Chair = new(5, nameof(Chair));

        public PeripheryType(int id, string name) : base(id, name)
        {
        }
    }
}
