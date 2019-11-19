using System;
using System.Collections.Generic;
using System.Text;
using RogueFramework.Base;

namespace RogueFramework.Races
{
    class Beast : Base.ICreatureType
    {
        public string Name { get => Name; set => Name = value; }
        public char CreatureIcon { get; set; }

        public Beast()
        {
            Name = "Beast";
            CreatureIcon = 'b';
        }
    }
}
