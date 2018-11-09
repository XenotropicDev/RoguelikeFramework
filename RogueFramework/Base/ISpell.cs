using System;
using System.Collections.Generic;
using System.Text;

namespace RogueFramework.Base
{
    public interface ISpell
    {
        string Name { get; set; }
        int ManaCost { get; set; }
        int SpellLevel { get; set; }
        List<IEffect> SpellEffects { get; set; }
    }
}
