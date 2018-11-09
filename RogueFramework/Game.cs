﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Text;

namespace RogueFramework
{
    public class Game
    {
        public List<Base.ICreature> LevelCreatures; 
        public List<Base.ITile> LevelTiles; 
        public List<Base.IWall> LevelWalls; 
        public List<Rooms.RoomLocation> rooms;
        public Base.ICreature PC;

        public Random rand = new Random();

        public void Start()
        {
            PC = new Creatures.SampleCharacter();
            Initialize();
            DrawCreature(PC);
            

            while (true)
            {                
                var key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        MoveCreature(PC, -1, 0);
                        break;
                    case ConsoleKey.RightArrow:
                        MoveCreature(PC, +1, 0);
                        break;
                    case ConsoleKey.DownArrow:
                        MoveCreature(PC, 0, +1);
                        break;
                    case ConsoleKey.UpArrow:
                        MoveCreature(PC, 0, -1);
                        break;
                    case ConsoleKey.Escape:
                        return;
                    case ConsoleKey.F8:
                        break;
                    case ConsoleKey.F7:                        
                        CreateBSPRooms();
                        ConnectRooms();
                        //ConnectAllRooms();
                        PopulateTiles();
                        PopulateWalls();
                        //CutOutRooms();                        
                        CutoutForBSP();
                        DrawLevel();
                        DrawCreature(PC);
                        Console.CursorVisible = false;
                        break;
                    case ConsoleKey.F5:
                        Initialize();
                        break;
                    default:
                        break;
                }
            }
        }

        public void Initialize()
        {
            LevelCreatures = new List<Base.ICreature>();
            LevelTiles = new List<Base.ITile>();
            LevelWalls = new List<Base.IWall>();
            rooms = new List<Rooms.RoomLocation>();
            PopulateTiles();
            PopulateWalls();
            //CutOutRooms();
            CreateBSPRooms();
            ConnectRooms();
            CutoutForBSP();            
            DrawLevel();
            DrawCreature(PC);
            Console.CursorVisible = false;
        }

        public void ConnectAllRooms()
        {
            foreach (var cell1 in this.mapCells)
            {
                var room1 = cell1.GetRoom();
                foreach (var cell2 in this.mapCells)
                {
                    var room2 = cell2.GetRoom();
                    if (room1 == room2)
                    {
                        continue;
                    }
                    cell1.ConnectRooms(room1.Value, room2.Value);
                }
            }
        }

        public void PopulateTiles()
        {
            Random rand = new Random();

            for (int y = 1; y < Console.WindowHeight; y++)
            {
                for (int x = 1; x < Console.WindowWidth; x++)
                {
                    Base.ITile tile = new Tiles.Stone(x, y);
                    if (rand.Next(0, 100) < 10)
                    {
                        tile = new Tiles.Water(x, y);
                    }                    
                    LevelTiles.Add(tile);
                    DrawTile(tile);
                }
            }
        }

        public void PopulateWalls()
        {
            Random rand = new Random();

            for (int y = 0; y <= Console.WindowHeight; y++)
            {
                for (int x = 0; x < Console.WindowWidth; x++)
                {
                    Base.IWall wall = new Walls.DungeonWall(x, y);
                    LevelWalls.Add(wall);                              
                }
            }
        }

        public void CutOutRooms()
        {
            Random rand = new Random();

            for (int y = 1; y < Console.WindowHeight; y++)
            {
                for (int x = 1; x < Console.WindowWidth; x++)
                {
                    int roomSize = rand.Next(4, 10);

                    if (x + roomSize + 1 > Console.WindowWidth || x - roomSize < 0) continue;
                    if (y + roomSize + 1 > Console.WindowHeight || y - roomSize < 0) continue;

                    if (rand.NextDouble() > 0.975d)
                    {
                        for (int tempY = y -1; tempY <= y + roomSize + 1; tempY++)
                        {
                            for (int tempX = x - 1; tempX <= x + roomSize + 1; tempX++)
                            {
                                if (!LevelWalls.Exists(w => w.XPos == tempX && w.YPos == tempY)) continue;
                            }
                        }

                        LevelWalls.RemoveAll(w => w.XPos >= x && w.XPos <= x + roomSize && w.YPos >= y && w.YPos <= y + roomSize);
                        rooms.Add(new Rooms.RoomLocation(x, y));
                    }                    
                }
            }
        }

        private List<Cell> mapCells;
        private Cell root;

        public void CreateBSPRooms()
        {
            const int MAX_LEAF_SIZE = 24;

            mapCells = new List<Cell>();
            root = new Cell(2, 2, Console.WindowWidth - 2, Console.WindowHeight - 2, rand);
            mapCells.Add(root);

            bool didSplit = true;

            while (didSplit)
            {
                didSplit = false;
                for (int i = 0; i < mapCells.Count; i++)
                    ////for (int i = leafs.Count - 1; i >= 0; i--)                
                {
                    if (mapCells[i].LeftChild == null && mapCells[i].RightChild == null) // if this Leaf is not already split...
                    {
                        // if this Leaf is too big, or 75% chance...
                        if (mapCells[i].Width > MAX_LEAF_SIZE || mapCells[i].Height > MAX_LEAF_SIZE || rand.NextDouble() > 0.25)
                        {
                            if (mapCells[i].Split()) // split the Leaf!
                            {
                                // if we did split, push the child leafs to the Vector so we can loop into them next
                                mapCells.Add(mapCells[i].LeftChild);
                                mapCells.Add(mapCells[i].RightChild);
                                didSplit = true;
                            }
                        }
                    }
                }
            }
            root.CreateRooms();
            ////root.ConnectRooms(root.LeftChild.GetRoom().Value, root.RightChild.GetRoom().Value);
        }

        private void CutoutForBSP()
        {
            foreach (Cell l in mapCells)
            {
                if (l.GetRoom().HasValue)
                {
                    LevelWalls.RemoveAll(w => w.XPos >= l.GetRoom().Value.Left && w.XPos <= l.GetRoom().Value.Right && w.YPos >= l.GetRoom().Value.Top && w.YPos <= l.GetRoom().Value.Bottom);
                }
                foreach (Rectangle hall in l.halls)
                {
                    LevelWalls.RemoveAll(w => w.XPos >= hall.Left && w.XPos <= hall.Right && w.YPos >= hall.Top && w.YPos <= hall.Bottom);
                }
            }
        }
        

        private void ConnectRooms()
        {
            var room = root.GetRoom();
            foreach (Cell c in mapCells)
            {

            }
        }



        public void DrawCreature(Base.ICreature creature)
        {            
            Console.SetCursorPosition(creature.XPos, creature.YPos);
            Console.ForegroundColor = creature.Color;
            Console.Write(creature.Icon);
        }

        public void DrawTile(Base.ITile tile)
        {
            Console.SetCursorPosition(tile.XPos, tile.YPos);
            Console.ForegroundColor = tile.Color;
            Console.Write(tile.Icon);
        }

        public void DrawWall(Base.IWall wall)
        {
            Console.SetCursorPosition(wall.XPos, wall.YPos);
            Console.ForegroundColor = wall.Color;
            Console.Write(wall.Icon);
        }

        public void DrawLevel()
        {
            foreach (Base.IWall wall in LevelWalls)
            {
                DrawWall(wall);
            }
        }

        public void MoveCreature(Base.ICreature creature, int dx, int dy)
        {
            if (IsValidMove(creature, dx, dy))
            {
                DrawTile(GetTileUnderCreature(creature));
                creature.XPos += dx;
                creature.YPos += dy;
                DrawCreature(creature);
            }            
        }

        public bool IsValidMove(Base.ICreature creature, int dx, int dy)
        {
            int x = creature.XPos + dx;
            int y = creature.YPos + dy;
            if (x >= Console.WindowWidth || x <= 0) return false;
            if (y >= Console.WindowHeight || y <= 0) return false;
            if (LevelCreatures.Exists(c => c.XPos == x && c.YPos == y)) return false;
            if (LevelWalls.Exists(w => w.XPos == x && w.YPos == y)) return false;
            //if (LevelTiles.Exists(t => t.XPos == x && t.YPos == y && t.GetType() == typeof(Tiles.Water))) return false;

            return true;
        }

        public Base.ITile GetTileUnderCreature(Base.ICreature creature)
        {
            var tile = LevelTiles.Find(t => t.XPos == creature.XPos && t.YPos == creature.YPos);
            return tile; //?? new Tiles.Stone(creature.XPos, creature.YPos);
        }
    }
}
