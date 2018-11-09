using System;
using System.Collections.Generic;
using System.Text;
//using RogueFramework.Base;

namespace RogueFramework.Races
{
    class Human : Base.ICreatureType
    {
        public char CreatureIcon { get; set; }
        public string Name { get; set; }

        public Human()
        {
            Name = "Human";
            CreatureIcon = 'H';
        }
    }
}
