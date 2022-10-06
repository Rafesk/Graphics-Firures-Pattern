using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Фигуры_2
{
    [Serializable]
    class Ellipse : Figure
    {
        private Ellipse(int x, int y, int w, int h, Color fillcolor, Color linecolor) : base(x, y, w, h, fillcolor, linecolor) { }

        public override void Draw(Graphics g)
        {
            g.FillEllipse(new SolidBrush(fillcolor), x, y, w, h);
            g.DrawEllipse(new Pen(linecolor), x, y, w, h);
        }
        public override bool IsIn(int x, int y)
        {
            int a = this.w / 2;
            int b = this.h / 2;
            return (Math.Pow(x - (this.x + this.w / 2), 2) / Math.Pow(a, 2) + Math.Pow(y - (this.y + this.h / 2), 2) / Math.Pow(b, 2)) < 1;
        }

        public class CreateEllipse : Creator
        {
            public override Figure ModelCreator(int x, int y, int w, int h, Color fillcolor, Color linecolor)
            {
                return new Ellipse(x, y, w, h, fillcolor, linecolor);
            }
        }
    }
}
