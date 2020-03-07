using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace RogueFramework.Tests
{
    [TestClass()]
    public class RoomDemoTests
    {
        [TestMethod()]
        public void DemoTest()
        {
            for (int i = 0; i < 100; i++)
            {
                //System.Threading.Thread.Sleep(2);
                var room = RoomFactory.GetRoom();
                room.CreateRoom();
            }
        }

        [TestMethod()]
        public void DecoratedRoomTest()
        {
            IRoom room = new CastleRoom();
            room = new OrnateRoom(room);
            room = new FloodedRoom(room);
            room.CreateRoom();
        }
    }
}