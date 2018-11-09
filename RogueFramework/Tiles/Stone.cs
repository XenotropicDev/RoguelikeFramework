using System;
using System.Collections.Generic;
using System.Text;

namespace RogueFramework.Tiles
{
    public class Stone : Base.ITile
    {
        public double SpeedMod { get; set; }
        public char Icon { get; set; }
        public ConsoleColor Color { get; set; }
        public int XPos { get; set; }
        public int YPos { get; set; }

        public Stone()
        {
            SpeedMod = 1.0d;
            Icon = '.';
            Color = ConsoleColor.Gray;
        }

        public Stone(int X, int Y)
        {
            SpeedMod = 1.0d;
            Icon = '.';
            Color = ConsoleColor.Gray;
            XPos = X;
            YPos = Y;
        }        
    }
}
