using System;
using System.Collections.Generic;
using System.Text;
using RogueFramework.Base;

namespace RogueFramework.Creatures
{
    class SampleCharacter : Base.ICreature
    {
        public string Name { get; set; }             
        public ICreatureClass CreatureClass { get; set; }
        public ICreatureType CreatureType { get; set; }
        public List<IItem> Inventory { get; set; }        

        public char Icon { get; set; }
        public ConsoleColor Color { get; set; }

        public int XPos { get; set; }
        public int YPos { get; set; }

        public SampleCharacter()
        {
            Name = "Sample";
            CreatureClass = new CreatureClasses.Leper();
            CreatureType = new Races.Human();
            Inventory = new List<IItem>();            
            Icon = '@';
            Color = CreatureClass.ClassColor;
            XPos = 20;
            YPos = 20;
        }
    }
}
