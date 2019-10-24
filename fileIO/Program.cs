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
            Wall_types[,] Map = new Wall_types[5, 5];
            Random rnd = new Random(Guid.NewGuid().GetHashCode());

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Map[i, j] = new Wall_types();
                    Map[i, j].init_wall(rnd.Next(1, 12));
                }
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    while (true)
                    {
                        break;
                    }

                    int x = j * 6;
                    int y = i * 3;
                    string[] str = Map[i, j].GetWall();

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
        }
    }
}
