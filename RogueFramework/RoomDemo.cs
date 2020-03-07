using RogueFramework.Base;
using RogueFramework.Items;
using System;
using System.Collections.Generic;

namespace RogueFramework
{
    /// <summary>
    /// This uses factory pattern and Decorator so that you can make things like a DungeonRoom that is decorated with a flooded room
    /// </summary>
    public class RoomDemo
    {
        public static void Demo()
        {
            IRoom room1 = RoomFactory.GetRoom();
            IRoom room2 = RoomFactory.GetRoom("Flooded");

            room1.CreateRoom();
            room2.CreateRoom();
        }
    }

    public interface IRoom
    {
        string Name { get; set; }
        int Wealth { get; set; }

        void CreateRoom();
    }

    public static class RoomFactory
    {
        public static IRoom GetRoom(string Type = null)
        {
            IRoom room;
            int transforms = 0;

            //Setup the base room type
            if (GameRandom.Random.NextDouble() > 0.5) room = new CastleRoom();
            else room = new DungeonRoom();

            //Apply random room statuses to the base room
            if (GameRandom.Random.NextDouble() >= 0.95) { room = new OrnateRoom(room); transforms++; }
            if (GameRandom.Random.NextDouble() >= 0.95) { room = new HiddenTreasureRoom(room); transforms++; }
            if (GameRandom.Random.NextDouble() >= 0.75) { room = new FloodedRoom(room); transforms++; }
            if (GameRandom.Random.NextDouble() >= 0.75 && transforms < 3) { room = new DirtyRoom(room); transforms++; }
            if (GameRandom.Random.NextDouble() >= 0.75 && transforms < 3) { room = new OvergrownRoom(room); transforms++; }
            if (GameRandom.Random.NextDouble() >= 0.90 && transforms < 3) { room = new ArmoryRoom(room); transforms++; }
            return room;
        }

        private static IRoom RandomRoom(int MaxWealth = int.MaxValue)
        {
            //if (GameRandom.Random.NextDouble() > 0.7)
            return new CastleRoom();
        }
    }

    public class CastleRoom : IRoom
    {
        public CastleRoom()
        {
            Name = "Castle Room";
        }

        public string Name { get; set; }
        public int Wealth { get; set; } = 100;

        public void CreateRoom()
        {

        }
    }

    public class DungeonRoom : IRoom
    {
        public DungeonRoom()
        {
            Name = "Dungeon Room";
        }

        public string Name { get; set; }
        public int Wealth { get; set; } = 100;

        public void CreateRoom()
        {

        }
    }

    public abstract class RoomDecorator : IRoom
    {
        private IRoom _room;

        public RoomDecorator(IRoom room)
        {
            _room = room;
        }

        public string Name { get; set; }
        public int Wealth { get; set; }

        public virtual void CreateRoom()
        {
            _room.CreateRoom();
        }
    }

    public class FloodedRoom : RoomDecorator
    {
        public FloodedRoom(IRoom room) : base(room)
        {
            this.Name = "Flooded " + room.Name;
            this.Wealth -= 50;
        }

        public override void CreateRoom()
        {
            base.CreateRoom();
        }
    }

    public class OrnateRoom : RoomDecorator
    {
        public OrnateRoom(IRoom room) : base(room)
        {
            this.Name = "Ornate " + room.Name;
            this.Wealth += 500;
        }

        public override void CreateRoom()
        {
            base.CreateRoom();
        }
    }

    public class HiddenTreasureRoom : RoomDecorator
    {
        public HiddenTreasureRoom(IRoom room) : base(room)
        {
            this.Name = "Treasure " + room.Name;
            this.Wealth += 500;
        }

        public override void CreateRoom()
        {
            Console.WriteLine("Something is hidden in here.");
            base.CreateRoom();
        }
    }

    public class OvergrownRoom : RoomDecorator
    {
        public OvergrownRoom(IRoom room) : base(room)
        {
            this.Name = "Overgrown " + room.Name;
            this.Wealth -= 25;
        }
    }

    public class DirtyRoom : RoomDecorator
    {
        public DirtyRoom(IRoom room) : base(room)
        {
            this.Name = "Dirty " + room.Name;
            this.Wealth -= 50;
        }
    }

    public class ArmoryRoom : RoomDecorator
    {
        public ArmoryRoom(IRoom room) : base(room)
        {
            this.Name = "Armory " + room.Name;
            this.Wealth += 50;
        }
    }
}