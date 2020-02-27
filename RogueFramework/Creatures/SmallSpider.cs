using System;
using System.Collections.Generic;
using System.Text;
using RogueFramework.Base;

namespace RogueFramework.Creatures
{
    class SmallSpider : Base.ICreature
    {
        public string Name { get; set; }             
        public ICreatureClass CreatureClass { get; set; }
        public ICreatureType CreatureType { get; set; }
        public List<IItem> Inventory { get; set; }        

        public char Icon { get; set; }
        public ConsoleColor Color { get; set; }

        public int XPos { get; set; }
        public int YPos { get; set; }

        public List<IEffect> ActiveEffects { get; set; }

        public double Strength { get; set; }
        public double Agility { get; set; }
        public double Consitution { get; set; }
        public double Inteligence { get; set; }
        public double Wisdom { get; set; }
        public double Charimsa { get; set; }
        public double MoveSpeed { get; set; }
        public double AttackSpeed { get; set; }
        public double HitDie { get; set; }

        public SmallSpider()
        {
            Name = "Small Spider";
            CreatureClass = new CreatureClasses.Leper();
            CreatureType = new Races.Beast();
            Inventory = new List<IItem>();            
            Icon = '@';
            Color = CreatureClass.ClassColor;
            XPos = 20;
            YPos = 20;
        }
    }
}
