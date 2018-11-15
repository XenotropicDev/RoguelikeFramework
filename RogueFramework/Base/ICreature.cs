using System;
using System.Collections.Generic;
using System.Text;

namespace RogueFramework.Base
{
    public interface ICreature : IDisplay, ILocation
    {
        string Name { get; set; }
        ICreatureClass CreatureClass { get; set; }
        ICreatureType CreatureType { get; set; }
        List<IItem> Inventory { get; set; }        
        List<IEffect> ActiveEffects { get; set; }

        double Strength { get; set; }
        double Agility { get; set; }
        double Consitution { get; set; }
        double Inteligence { get; set; }
        double Wisdom { get; set; }
        double Charimsa { get; set; }

        double MoveSpeed { get; set; }
        double AttackSpeed { get; set; }
        double HitDie { get; set; }
    }
}
