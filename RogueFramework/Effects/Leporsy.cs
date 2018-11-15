using System;
using System.Collections.Generic;
using System.Text;
using RogueFramework.Base;

namespace RogueFramework.Effects
{
    public class Leporsy : Base.IEffect
    {
        public string Name { get => "Leporsy"; set => Name = value; }
        public AttributeMod AttributeMod { get; set; }

        public Leporsy()
        {
            AttributeMod.Charimsa = -1;
            AttributeMod.MoveSpeed = -0.5d;
            AttributeMod.TickCount = -1;
            AttributeMod.TickRate = 1000;
        }
    }
}
