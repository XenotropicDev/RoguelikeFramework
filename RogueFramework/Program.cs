﻿using System;
using System.Collections.Generic;

namespace RogueFramework
{
    class Program
    {
        static Game game = new Game();

        static void Main(string[] args)
        {
            EffectDemo.Demo();
            RoomDemo.Demo();
            game.Start();
        }
    }
}
