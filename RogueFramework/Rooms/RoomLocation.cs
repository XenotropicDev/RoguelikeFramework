using System;
using System.Collections.Generic;
using System.Text;

namespace RogueFramework.Rooms
{
    public class RoomLocation : Base.ILocation
    {
        public int XPos { get; set; }
        public int YPos { get; set; }

        public RoomLocation(int x, int y)
        {
            XPos = x;
            YPos = y;
        }
    }
}
