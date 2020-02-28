using Microsoft.VisualStudio.TestTools.UnitTesting;
using RogueFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace RogueFramework.Tests
{
    [TestClass()]
    public class RoomDemoTests
    {
        [TestMethod()]
        public void DemoTest()
        {
            for (int i = 0; i<100; i++)
            {
                //System.Threading.Thread.Sleep(2);
                Console.WriteLine(RoomFactory.GetRoom().Name);
            }
        }
    }
}