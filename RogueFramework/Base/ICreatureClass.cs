using System;
using System.Collections.Generic;
using System.Text;

namespace RogueFramework.Base
{
    public interface ICreatureClass
    {
        string Name { get; set; }
        int HitDie { get; set; }
        List<IEffect> ClassEffects { get; set; }
        ConsoleColor ClassColor { get; set; }
    }
}
