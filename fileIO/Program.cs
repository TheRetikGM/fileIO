using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace fileIO
{
    class Program
    {
        static void Main(string[] args)
        {
            Wall_type[,] Map = new Wall_type[5, 5];
            char[,] char_map = new char[15, 30];
            Wall_type[] wall_types = new Wall_type[16];
            Random rnd = new Random(Guid.NewGuid().GetHashCode());

            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    Map[i, j] = new Wall_type();
            for (int i = 0; i < 16; i++)
            {
                wall_types[i] = new Wall_type();
                wall_types[i].init_wall(i + 1);
            }

            bool[] sides = new bool[4];
            for (int i = 0; i < 4; i++)
                sides[i] = false;

            void check_around(int y, int x, bool up, bool down, bool left, bool right)
            {
                if (up)
                {

                    if (Map[y - 1, x].Wall == null)
                        sides[0] = (rnd.Next(0, 2) == 0) ? false : true;
                    else if (Map[y - 1, x].Sides_acc[1])
                        sides[0] = true;
                }
                if (down)
                {
                    if (Map[y + 1, x].Wall == null)
                        sides[1] = (rnd.Next(0, 2) == 0) ? false : true;
                    else if (Map[y + 1, x].Sides_acc[0])
                        sides[1] = true;
                }
                if (left)
                {
                    if (Map[y, x - 1].Wall == null)
                        sides[2] = (rnd.Next(0, 2) == 0) ? false : true;
                    else if (Map[y, x - 1].Sides_acc[3])
                        sides[2] = true;
                }
                if (right)
                {
                    if (Map[y, x + 1].Wall == null)
                        sides[3] = (rnd.Next(0, 2) == 0) ? false : true;
                    else if (Map[y, x + 1].Sides_acc[2])
                        sides[3] = true;
                }
                for (int k = 0; k < 16; k++)
                {
                    Console.SetCursorPosition(50, 0);
                    for (int l = 0; l < 4; l++)
                        Console.Write("{0}, ", sides[l]);
                    //Console.ReadKey(true);
                    int a = 0;
                    for (int l = 0; l < 4; l++)
                        if (sides[l] == wall_types[k].Sides_acc[l])
                            a++;
                    if (a == 4)
                        Map[y, x].init_wall(k + 1);
                }
            }

            for (int a = 0; a < 2; a++)
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (i == 0 && j == 0)
                            check_around(i, j, false, true, false, true);
                        else if (i == 4 && j == 0)
                            check_around(i, j, true, false, false, true);
                        else if (i == 0 && j == 4)
                            check_around(i, j, false, true, true, false);
                        else if (i == 4 && j == 4)
                            check_around(i, j, true, false, true, false);
                        else if (i == 0)
                            check_around(i, j, false, true, true, true);
                        else if (i == 4)
                            check_around(i, j, true, false, true, true);
                        else if (j == 0)
                            check_around(i, j, true, true, false, true);
                        else if (j == 4)
                            check_around(i, j, true, true, true, false);
                        else
                            if (a == 0)
                            check_around(i, j, true, true, true, true);
                    }
                }
            }


            string[] str_test = new string[3];
            for (int i = 0; i < 3; i++)
                str_test[i] = "      ";

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    int x = j * 6 + 10;
                    int y = i * 3 + 5;

                    string[] str;

                    if (Map[i, j].Wall == null)
                        str = str_test;
                    else
                        str = Map[i, j].Wall;

                    for (int k = 0; k < 3; k++)
                    {
                        Console.SetCursorPosition(x, y + k);
                        for (int l = 0; l < 6; l++)
                        {
                            string r = str[k];
                            if (r[l] == 's')
                            {
                                Console.Write(' ');
                            }
                            else
                            {
                                Console.Write(r[l]);
                            }
                        }
                    }
                }
            }
            Console.Clear();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        Console.SetCursorPosition(i * 3, j * 6 + k);
                        string line = Map[i, j].Wall[k];
                        for (int l = 0; l < 6; l++)
                        {
                            //char_map[k * i + k, l * j + l] = line[l];

                            Console.Write(line[l]);
                        }
                    }
                }
            }
            Console.ReadKey(true);
            Console.Clear();
            for (int i = 0; i < 15; i++)
                for (int j = 0; j < 30; j++)
                {
                    Console.SetCursorPosition(j, i);
                    Console.Write(char_map[i, j]);
                }
        }
    }
}
