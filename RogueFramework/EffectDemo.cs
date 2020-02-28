using System;
using System.Collections.Generic;

namespace RogueFramework
{
    public class EffectDemo
    {
        public static void Demo()
        {
            Item item = new Item { Name = "Sword", Durability = 100 };
            Console.WriteLine($"Item: {item.Name} [{item.Durability}]");

            IItemEffect itemEffect = new WeakenItem();
            item.ActiveEffects.Add(itemEffect);

            //simulate a game tick
            item.GameTick();
            Console.WriteLine($"Item: {item.Name} [{item.Durability}]");

            //simulate a few game ticks
            item.GameTick();
            item.GameTick();
            item.GameTick();

            //Show the result
            Console.WriteLine($"Item: {item.Name} [{item.Durability}]");
        }
    }

    public class Item
    {
        public List<IItemEffect> ActiveEffects;
        public string Name { get; set; }
        public int Durability { get; set; }

        public Item()
        {
            ActiveEffects = new List<IItemEffect>();
        }

        public void GameTick()
        {
            foreach (var effect in ActiveEffects)
            {
                effect.ApplyEffect(this);
            }
            ActiveEffects.RemoveAll(e => e.IsComplete);
        }
    }

    public interface IItemEffect
    {
        void ApplyEffect(Item item);

        void RemoveEffect(Item item);

        bool IsComplete { get; }
    }

    public class WeakenItem : IItemEffect
    {
        private bool applied = false;
        private int ticksRemaining;

        public WeakenItem()
        {
            ticksRemaining = 2;
        }

        public WeakenItem(int Ticks)
        {
            ticksRemaining = Ticks;
        }

        public bool IsComplete
        {
            get { return ticksRemaining <= 0; }
        }

        public void ApplyEffect(Item item)
        {
            if (applied)
            {
                ticksRemaining--;
                if (ticksRemaining <= 0) RemoveEffect(item);
                return;
            }

            applied = true;
            item.Name = "Weakened " + item.Name;
            item.Durability -= 5;
        }

        public void RemoveEffect(Item item)
        {
            item.Name = item.Name.Replace("Weakened ", string.Empty);
            item.Durability += 5;
        }
    }
}