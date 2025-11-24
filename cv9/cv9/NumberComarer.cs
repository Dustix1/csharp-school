using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv9
{
    internal class NumberComarer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (x == y) return 0;

            if (x % 2 == 0 && y % 2 == 0 || x % 2 != 0 && y % 2 != 0)
            {
                if (x < y) return -1;
                return 1;
            }
            if (x % 2 == 0) return -1;
            if (y % 2 == 0) return 1;

            return 1;
        }
    }
}
