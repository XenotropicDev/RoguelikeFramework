using System;
using System.Collections.Generic;
using System.Text;

namespace RogueFramework.Walls
{
    class DungeonWall : Base.IWall
    {        
        public char Icon { get; set; }
        public ConsoleColor Color { get; set; }
        public int XPos { get; set; }
        public int YPos { get; set; }

        public DungeonWall()
        {
            Icon = '█';
            Color = ConsoleColor.White;
        }

        public DungeonWall(int X, int Y)
        {
            Icon = '█';
            Color = ConsoleColor.White;
            XPos = X;
            YPos = Y;
        }
    }
}
