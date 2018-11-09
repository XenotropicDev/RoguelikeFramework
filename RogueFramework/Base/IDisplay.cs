using System;
using System.Collections.Generic;
using System.Text;

namespace RogueFramework.Base
{
    public interface IDisplay
    {
        char Icon { get; set; }
        ConsoleColor Color { get; set; }
    }
}
