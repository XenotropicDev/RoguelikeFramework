using System;
using System.Collections.Generic;
using System.Text;
using RogueFramework.Base;

namespace RogueFramework.CreatureClasses
{
    class Spider : Base.ICreature
    {
        public string Name { get => Name; set => throw new NotImplementedException(); }
        public ICreatureClass CreatureClass { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ICreatureType CreatureType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<IItem> Inventory { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<IEffect> ActiveEffects { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double Strength { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double Agility { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double Consitution { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double Inteligence { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double Wisdom { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double Charimsa { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double MoveSpeed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double AttackSpeed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double HitDie { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public char Icon { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ConsoleColor Color { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int XPos { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int YPos { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
