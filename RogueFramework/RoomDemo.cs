using System;

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

        void CreateRoom();
    }

    /// <summary>
    /// Always use the same random for creating rooms.
    /// </summary>
    public static class RoomRandom
    {
        private static Random _rand;

        public static Random Get()
        {
            if (_rand == null)
            {
                _rand = new Random();
            }
            return _rand;
        }
    }

    public static class RoomFactory
    {
        public static IRoom GetRoom(string Type = null)
        {
            IRoom room;
            int transforms = 0;

            //Make sure if we create a bunch of rooms we are getting different random seeds
            var rand = RoomRandom.Get();

            //Setup the base room type
            if (rand.Next(10) > 5) room = new CastleRoom();
            else room = new DungeonRoom();

            //Apply random room statuses to the base room
            if (rand.Next(1000) >= 999) { room = new OrnateRoom(room); transforms++; }
            if (rand.Next(100) >= 75) { room = new FloodedRoom(room); transforms++; }
            if (rand.Next(100) >= 75 && transforms < 3) { room = new DirtyRoom(room); transforms++; }
            if (rand.Next(100) >= 75 && transforms < 3) { room = new OvergrownRoom(room); transforms++; }
            return room;
        }
    }

    public class CastleRoom : IRoom
    {
        public CastleRoom()
        {
            Name = "Castle Room";
        }

        public string Name { get; set; }

        public void CreateRoom()
        {
            Console.WriteLine(this.Name);
        }
    }

    public class DungeonRoom : IRoom
    {
        public DungeonRoom()
        {
            Name = "Dungeon Room";
        }

        public string Name { get; set; }

        public void CreateRoom()
        {
            Console.WriteLine(this.Name);
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
        }
    }

    public class OrnateRoom : RoomDecorator
    {
        public OrnateRoom(IRoom room) : base(room)
        {
            this.Name = "Ornate " + room.Name;
        }
    }

    public class OvergrownRoom : RoomDecorator
    {
        public OvergrownRoom(IRoom room) : base(room)
        {
            this.Name = "Overgrown " + room.Name;
        }
    }

    public class DirtyRoom : RoomDecorator
    {
        public DirtyRoom(IRoom room) : base(room)
        {
            this.Name = "Dirty " + room.Name;
        }
    }
}