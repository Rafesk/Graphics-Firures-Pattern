using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Фигуры_2
{
    abstract class Creator
    {
        public abstract Figure ModelCreator(int x, int y, int w, int h, Color fillcolor, Color linecolor);
    }
}
