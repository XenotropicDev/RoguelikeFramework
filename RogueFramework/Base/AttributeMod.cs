using System;
using System.Collections.Generic;
using System.Text;

namespace RogueFramework.Base
{
    public class AttributeMod
    {
        public double Strength { get; set; }
        public double Agility { get; set; }
        public double Consitution { get; set; }
        public double Inteligence { get; set; }
        public double Wisdom { get; set; }
        public double Charimsa { get; set; }
        
        public double MoveSpeed { get; set; }
        public double AttackSpeed { get; set; }
        public double HitDie { get; set; }
        public double HitPoints { get; set; }

        private int tickRate;
        private int tickCount;
        private System.Timers.Timer modTimer;

        public int TickRate
        {
            get { return tickRate; }
            set
            {
                tickRate = value;
                modTimer = new System.Timers.Timer(tickRate);
            }
        }

        public int TickCount
        {
            get { return tickCount; }
            set
            {
                tickCount = value;
                if (tickCount == 0)
                {
                    modTimer.Enabled = false;
                }
                else if (!modTimer.Enabled)
                {
                    modTimer.Enabled = true;
                }
            }
        }


        public AttributeMod()
        {

        }
    }
}
