using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv2
{
    internal class JaggedArray
    {
        public void Run()
        {
            bool[][] playSpace = new bool[25][];

            for (int i = 0; i < playSpace.Length; i++)
            {
                playSpace[i] = new bool[15];
            }

            CreateT(0, 0, playSpace);
            CreateZ(10, 2, playSpace);

            CreateT(5, 10, playSpace);

            while (true)
            {
                Console.Clear();
                Print(playSpace);
                MoveDown(playSpace);
                Thread.Sleep(1000);
            }


        }

        private void Print(bool[][] ps)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Red;

            for (int y = 0; y < ps.Length; y++)
            {
                for (int x = 0; x < ps[y].Length; x++)
                {
                    if (ps[y][x])
                    {
                        Console.Write("\u2588\u2588");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }
                Console.Write('\n');
            }

            Console.BackgroundColor = ConsoleColor.Black;
        }

        private void MoveDown(bool[][] ps)
        {
            for (int y = ps.Length - 1; y > 0; y--)
            {
                ps[y] = ps[y - 1];
            }

            ps[0] = new bool[ps[0].Length];
        }

        private void CreateT(int x, int y, bool[][] ps)
        {
            ps[y][x] = true;
            ps[y][x + 1] = true;
            ps[y][x + 2] = true;
            ps[y + 1][x + 1] = true;
            ps[y + 2][x + 1] = true;
            ps[y + 3][x + 1] = true;
        }

        private void CreateZ(int x, int y, bool[][] ps)
        {
            ps[y][x] = true;
            ps[y][x + 1] = true;
            ps[y][x + 2] = true;
            ps[y][x + 3] = true;
            ps[y + 1][x + 2] = true;
            ps[y + 2][x + 1] = true;
            ps[y + 3][x] = true;
            ps[y + 3][x + 1] = true;
            ps[y + 3][x + 2] = true;
            ps[y + 3][x + 3] = true;
        }
    }
}
