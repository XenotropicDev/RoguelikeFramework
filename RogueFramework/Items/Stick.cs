using RogueFramework.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace RogueFramework.Items
{
    class Stick : IItem
    {
        public Stick()
        {
            Name = "Stick";
            Durability = 100;
        }

        public string Name { get; set; }
        public int Durability { get; set; }
        public ItemSlot? Slot { get; set; }
        public List<IEffect> Effects { get; set; }
        
    }
}
