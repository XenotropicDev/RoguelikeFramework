using System;
using System.Collections.Generic;
using System.Text;

namespace RogueFramework.Base
{
    public interface ITile : IDisplay, ILocation
    {
        double SpeedMod { get; set; }
    }
}
