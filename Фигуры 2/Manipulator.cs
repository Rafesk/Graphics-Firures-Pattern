using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Фигуры_2
{
    internal class Manipulator :Figure
    {
        Figure fig;
        int activePoint = 0;
        public override void Draw(Graphics g)
        {
            
        }

        public override bool IsIn(int x, int y)
        {
            return false;
        }
        public void Location(int x, int y)
        {

        }
        public void Resize(int x, int y)
        {

        }
        public void SetFigure(Figure f)
        {

        }
        public void Drag(int dx, int dy)
        {

        }
    }
}
