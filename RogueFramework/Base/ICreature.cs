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
    }
}
