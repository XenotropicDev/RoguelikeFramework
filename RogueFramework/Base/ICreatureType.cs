using System;
using System.Collections.Generic;
using System.Text;

namespace RogueFramework.Base
{
    public interface ICreatureType
    {
        string Name { get; set; }        
        char CreatureIcon { get; set; }
    }
}
