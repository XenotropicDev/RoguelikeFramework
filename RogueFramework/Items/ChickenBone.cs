using RogueFramework.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace RogueFramework.Items
{
    class ChickenBone : IItem
    {
        public string Name { get; set; }
        public int Durability { get; set; }
        public ItemSlot? Slot { get; set; }
        public List<IEffect> Effects { get; set; }
    }
}
