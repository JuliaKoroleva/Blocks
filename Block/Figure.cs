using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Block
{
    public class Figure
    {
        const int M = 4;
        public int[,] shape;

        public Figure(int[,] shape)
        {
            shape = new int[M, M];
        }
    }
}
