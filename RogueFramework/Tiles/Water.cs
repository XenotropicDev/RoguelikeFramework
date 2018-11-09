using System;
using System.Collections.Generic;
using System.Text;

namespace RogueFramework.Tiles
{
    public class Water : Base.ITile
    {
        public double SpeedMod { get; set; }
        public char Icon { get; set; }
        public ConsoleColor Color { get; set; }
        public int XPos { get; set; }
        public int YPos { get; set; }

        public Water()
        {
            SpeedMod = 0.5d;
            Icon = '.'; // ≈
            Color = ConsoleColor.Cyan;
        }

        public Water(int X, int Y)
        {            
            SpeedMod = 0.5d;
            Icon = '.';
            Color = ConsoleColor.Cyan;
            XPos = X;
            YPos = Y;
        }
    }
}
