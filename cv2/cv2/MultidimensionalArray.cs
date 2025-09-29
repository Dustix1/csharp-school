using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv2
{
    internal class MultidimensionalArray
    {
        public void Run()
        {
            bool[,] playSpace = new bool[15, 25];

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

        private void Print(bool[,] ps)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Red;

            for (int y = 0; y < ps.GetLength(1); y++)
            {
                for (int x = 0; x < ps.GetLength(0); x++)
                {
                    if (ps[x, y])
                    {
                        Console.Write("\u2588\u2588");
                    } else
                    {
                        Console.Write("  ");
                    }
                }
                Console.Write('\n');
            }

            Console.BackgroundColor = ConsoleColor.Black;
        }

        private void MoveDown(bool[,] ps)
        {
            for (int y = ps.GetLength(1) - 1; y > 0 ; y--)
            {
                for (int x = 0; x < ps.GetLength(0); x++)
                {
                    ps[x, y] = ps[x, y - 1];
                }
            }

            for (int i = 0; i <  ps.GetLength(0); i++)
            {
                ps[i, 0] = false;
            }
        }

        private void CreateT(int x, int y, bool[,] ps)
        {
            ps[x, y] = true;
            ps[x + 1, y] = true;
            ps[x + 2, y] = true;
            ps[x + 1, y + 1] = true;
            ps[x + 1, y + 2] = true;
            ps[x + 1, y + 3] = true;
        }

        private void CreateZ(int x, int y, bool[,] ps)
        {
            ps[x, y] = true;
            ps[x + 1, y] = true;
            ps[x + 2, y] = true;
            ps[x + 3, y] = true;
            ps[x + 2, y + 1] = true;
            ps[x + 1, y + 2] = true;
            ps[x, y + 3] = true;
            ps[x + 1, y + 3] = true;
            ps[x + 2, y + 3] = true;
            ps[x + 3, y + 3] = true;
        }
    }
}
