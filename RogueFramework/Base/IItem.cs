using System;
using System.Collections.Generic;
using System.Text;

namespace RogueFramework.Base
{
    public interface IItem
    {
        string Name { get; set; }
        int Durability { get; set; }
        ItemSlot? Slot { get; set; }
        List<IEffect> Effects { get; set; }
    }
}
