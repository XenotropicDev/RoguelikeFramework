﻿using System;
using System.Collections.Generic;
using System.Text;
using RogueFramework.Base;

namespace RogueFramework.CreatureClasses
{
    class SpiderClass : Base.ICreatureClass
    {
        public string Name { get; set; }
        public int HitDie { get; set; }
        public List<IEffect> ClassEffects { get; set; }
        public ConsoleColor ClassColor { get; set; }

        public SpiderClass()
        {
            Name = "Spider";
            HitDie = 4;
            ClassEffects = new List<IEffect>();
            ClassColor = ConsoleColor.Green;
        }
    }
}
