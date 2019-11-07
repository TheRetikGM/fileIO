using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace fileIO
{
    public class Wall_type
    {
        public string[] Wall;
        public bool[] Sides_acc;

        public Wall_type()
        {
            Sides_acc = new bool[4];
            for (int i = 0; i < 4; i++)
                Sides_acc[i] = false;
        }

        public string[] GetWall()
        {
            return Wall;
        }
        public static Sides GetOpositeSide(Sides s)
        {
            if (s == Sides.Up) return Sides.Down;
            else if (s == Sides.Down) return Sides.Up;
            else if (s == Sides.Left) return Sides.Left;
            else if (s == Sides.Right) return Sides.Right;
            else return s;
        }
        public void init_wall_only(int i)
        {
            string path = string.Format("../../Walls/wall{0}.txt", i);
            Wall = File.ReadAllLines(path);
            Wall = Wall.Skip(4).ToArray();
        }
        public void init_wall(int i)
        {
            string path = string.Format("../../Walls/wall{0}.txt", i);
            Wall = File.ReadAllLines(path);
            for (int j = 0; j < 4; j++)
            {
                foreach (char c in Wall[j])
                {
                    int k = c - '0';
                    if (k == 0)
                        Sides_acc[j] = false;
                    else if (k == 1)
                        Sides_acc[j] = true;
                }
            }
            Wall = Wall.Skip(4).ToArray();
        }
        public void Print_wall()
        {
            foreach (string s in Wall)
                Console.WriteLine(s);
        }
        public void Print_sides()
        {
            for (int i = 0; i < 4; i++)
                Console.WriteLine(Sides_acc[i]);
        }
    }
}
