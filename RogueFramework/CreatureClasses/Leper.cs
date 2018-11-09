using System;
using System.Collections.Generic;
using System.Text;
using RogueFramework.Base;

namespace RogueFramework.CreatureClasses
{
    class Leper : Base.ICreatureClass
    {
        public string Name { get; set; }
        public int HitDie { get; set; }
        public List<IEffect> ClassEffects { get; set; }
        public ConsoleColor ClassColor { get; set; }

        public Leper()
        {
            Name = "Leper";
            HitDie = 4;
            ClassEffects = new List<IEffect>();
            ClassColor = ConsoleColor.Green;
        }
    }
}
