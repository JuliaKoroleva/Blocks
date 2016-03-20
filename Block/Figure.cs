using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Block
{
    public class Figure
    {
        public int[,] shape;
        public Color color;

        public Figure(int[,] shape, Color color)
        {
            this.shape = shape;
            this.color = color;
        }
    }
}
