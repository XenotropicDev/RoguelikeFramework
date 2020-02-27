using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace RogueFramework
{
    public class Cell
    {
        private const int MIN_CELL_SIZE = 8;

        private Random rand;

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
         
        public Cell LeftChild { get; set; }
        public Cell RightChild { get; set; }

        public Rectangle? Room { get; set; }
        public List<Rectangle> halls = new List<Rectangle>();

        public Cell(int x, int y, int width, int height, Random seed)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            rand = seed;
            Room = null;
        }

        public bool Split()
        {
            if (LeftChild != null || RightChild != null)
            {
                return false;
            }           

            bool splitH = (rand.NextDouble() > 0.5d);

            if (Width > Height && Width / Height >= 1.25)
            {
                splitH = false;
            }
            else if (Height > Width && Height / Width >= 1.25)
            {
                splitH = true;
             }

            int max = (splitH ? Height : Width) - MIN_CELL_SIZE;

            if (max <= MIN_CELL_SIZE)
                return false;

            int split = rand.Next(MIN_CELL_SIZE, max);

            if (splitH)
            {
                LeftChild = new Cell(this.X, this.Y, this.Width, split, this.rand);
                RightChild = new Cell(this.X, this.Y + split, this.Width, this.Height - split, this.rand);
            }
            else
            {
                LeftChild = new Cell(this.X, this.Y, split, this.Height, this.rand);
                RightChild = new Cell(this.X + split, this.Y, this.Width - split, this.Height, this.rand);
            }
            return true;            
        }

        public void CreateRooms()
        {
	        // this function generates all the rooms and hallways for this cell and all of its children.
	        if (LeftChild != null || RightChild != null)
	        {
		        // this cell has been split, so go into the children cells
		        if (LeftChild != null)
		        {
			        LeftChild.CreateRooms();
		        }
		        if (RightChild != null)
		        {
			        RightChild.CreateRooms();
		        }

                // Check if there's rooms on both sides, and connect those specific rooms
                var room1 = LeftChild.GetRoom();
                var room2 = RightChild.GetRoom();
                if (room1 != null && room2 != null && this.halls.Count == 0)
                {
                    this.ConnectRooms(room1.Value, room2.Value);
                }
            }
	        else
	        {
                // this cell needs a room
                Point roomSize;
                Point roomPos;
		        // the room can be between 3 x 3 up to the size of the cell - 2.
		        roomSize = new Point(rand.Next(3, Width - 2), rand.Next(3, Height - 2));

		        roomPos = new Point(rand.Next(1, Width - roomSize.X - 1), rand.Next(1, Height - roomSize.Y - 1));
		        Room = new Rectangle(X + roomPos.X, Y + roomPos.Y, roomSize.X, roomSize.Y);
	        }
        }

        //public void CreateHalls()
        //{
        //    // this function generates all the rooms and hallways for this cell and all of its children.
        //    if (LeftChild != null || RightChild != null)
        //    {
        //        // this cell has been split, so go into the children cells
        //        if (LeftChild != null)
        //        {
        //            LeftChild.CreateHalls();
        //        }
        //        if (RightChild != null)
        //        {
        //            RightChild.CreateHalls();
        //        }
        //    }           

        //    // if there are both left and right children in this cell, create a hallway between them
        //    if (LeftChild != null && RightChild != null && LeftChild.GetRoom().HasValue && RightChild.GetRoom().HasValue)
        //    {                
        //        this.ConnectRooms(LeftChild.GetRoom().Value, RightChild.GetRoom().Value);
        //    }

        //}

        public Rectangle? GetRoom()
        {
            // iterate all the way through these cells to find a room, if one exists.
            if (Room != null) //&& (Room.Width > 0 && Room.Height > 0))
                return Room;
            else
            {
                Rectangle? lRoom = null;
                Rectangle? rRoom = null;
                if (LeftChild != null)
                {
                    lRoom = LeftChild.GetRoom();
                }
                if (RightChild != null)
                {
                    rRoom = RightChild.GetRoom();
                }
                if (lRoom == null && rRoom == null)
                {
                    return null;
                }
                else if (rRoom == null)
                {
                    return lRoom;
                }
                else if (lRoom == null)
                {
                    return rRoom;
                }
                else if (rand.NextDouble() > 0.5d)
                {
                    return lRoom;
                }
                else
                {
                    return rRoom;
                }
            }
        }

        public bool IsLeaf()
        {
            if (this.LeftChild == null && this.RightChild == null)
            {
                return true;
            }
            return false;
        }

        public void ConnectRooms(Rectangle l, Rectangle r)

        {
            // Connect two rooms together by joining random points within the rooms together.

            int hallSize = 0;

            Point point1; 
            Point point2;
            
            if (l.Right > 2 && l.Bottom > 2 && r.Right > 2 && r.Bottom > 2)
            {
                point1 = new Point(rand.Next(l.Left + 1, l.Right - 2), rand.Next(l.Top + 1, l.Bottom - 2));
                point2 = new Point(rand.Next(r.Left + 1, r.Right - 2), rand.Next(r.Top + 1, r.Bottom - 2));
            }
            else
            {
                point1 = new Point(rand.Next(l.Left, l.Right), rand.Next(l.Top, l.Bottom));
                point2 = new Point(rand.Next(r.Left, r.Right), rand.Next(r.Top, r.Bottom));
            }

            var w = point2.X - point1.X;
            var h = point2.Y - point1.Y;

            if (w < 0)
            {
                if (h < 0)
                {
                    if (rand.NextDouble() < 0.5)
                    {
                        halls.Add(new Rectangle(point2.X, point1.Y, Math.Abs(w), hallSize));
                        halls.Add(new Rectangle(point2.X, point2.Y, hallSize, Math.Abs(h)));
                    }
                    else
                    {
                        halls.Add(new Rectangle(point2.X, point2.Y, Math.Abs(w), hallSize));
                        halls.Add(new Rectangle(point1.X, point2.Y, hallSize, Math.Abs(h)));
                    }
                }
                else if (h > 0)
                {
                    if (rand.NextDouble() < 0.5)
                    {
                        halls.Add(new Rectangle(point2.X, point1.Y, Math.Abs(w), hallSize));
                        halls.Add(new Rectangle(point2.X, point1.Y, hallSize, Math.Abs(h)));
                    }
                    else
                    {
                        halls.Add(new Rectangle(point2.X, point2.Y, Math.Abs(w), hallSize));
                        halls.Add(new Rectangle(point1.X, point1.Y, hallSize, Math.Abs(h)));
                    }
                }
                else // if (h == 0)
                {
                    halls.Add(new Rectangle(point2.X, point2.Y, Math.Abs(w), hallSize));
                }
            }
            else if (w > 0)
            {
                if (h < 0)
                {
                    if (rand.NextDouble() < 0.5)
                    {
                        halls.Add(new Rectangle(point1.X, point2.Y, Math.Abs(w), hallSize));
                        halls.Add(new Rectangle(point1.X, point2.Y, hallSize, Math.Abs(h)));
                    }
                    else
                    {
                        halls.Add(new Rectangle(point1.X, point1.Y, Math.Abs(w), hallSize));
                        halls.Add(new Rectangle(point2.X, point2.Y, hallSize, Math.Abs(h)));
                    }
                }
                else if (h > 0)
                {
                    if (rand.NextDouble() < 0.5)
                    {
                        halls.Add(new Rectangle(point1.X, point1.Y, Math.Abs(w), hallSize));
                        halls.Add(new Rectangle(point2.X, point1.Y, hallSize, Math.Abs(h)));
                    }
                    else
                    {
                        halls.Add(new Rectangle(point1.X, point2.Y, Math.Abs(w), hallSize));
                        halls.Add(new Rectangle(point1.X, point1.Y, hallSize, Math.Abs(h)));
                    }
                }
                else // if (h == 0)
                {
                    halls.Add(new Rectangle(point1.X, point1.Y, Math.Abs(w), hallSize));
                }
            }
            else // if (w == 0)
            {
                if (h < 0)
                {
                    halls.Add(new Rectangle(point2.X, point2.Y, hallSize, Math.Abs(h)));
                }
                else if (h > 0)
                {
                    halls.Add(new Rectangle(point1.X, point1.Y, hallSize, Math.Abs(h)));
                }
            }
        }        
    }
}
