using RogueFramework.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace RogueFramework.Items
{
    class Pebble : IItem
    {
        public Pebble()
        {
            Name = "Pebble";
            Durability = 100;
        }

        public string Name { get; set; }
        public int Durability { get; set; }
        public ItemSlot? Slot { get; set; }
        public List<IEffect> Effects { get; set; }
    }
}
