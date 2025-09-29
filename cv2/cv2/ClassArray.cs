using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv2
{
    internal class ClassArray
    {
        public void Run()
        {
            CompositeBrick[] compositeBricks = new CompositeBrick[2];
            compositeBricks[0] = CreateT(1, 1);
            compositeBricks[1] = CreateT(2, 5);
        }

        public CompositeBrick CreateT(int x, int y)
        {
            CompositeBrick b = new CompositeBrick();

            b.X = x;
            b.Y = y;

            b.Bricks = new Brick[4];
            b.Bricks[0] = new Brick() { X = 0, Y = 0 };
            b.Bricks[1] = new Brick() { X = 1, Y = 0 };
            b.Bricks[2] = new Brick() { X = 2, Y = 0 };
            b.Bricks[3] = new Brick() { X = 1, Y = 1 };

            return b;
        }
    }
}
