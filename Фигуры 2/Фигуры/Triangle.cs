using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Фигуры_2
{
    [Serializable]
    class Triangle:Figure
    {
        private Triangle(int x, int y, int w, int h, Color fillcolor, Color linecolor) : base(x, y, w, h, fillcolor, linecolor) { }

        public override void Draw(Graphics g)
        {
            Point[] points = new Point[3];
            points[0] = new Point(x + w / 2, y);
            points[1] = new Point(x, h + y);
            points[2] = new Point(w + x, h + y);
            g.FillPolygon(new SolidBrush(fillcolor), points);
            g.DrawPolygon(new Pen(linecolor), points);
        }
        public override bool IsIn(int x, int y)
        {
            return y > 2 * (this.y - (this.y + this.h)) * (x - this.x) / ((this.x + this.w) - this.x) + (this.y + this.h)
                    && y > 2 * (this.y - (this.y + this.h)) * (x - (this.x + this.w)) / (this.x - (this.x + this.w)) + (this.y + this.h)
                    && y < (this.y + this.w);
        }

        public class CreateTriangle : Creator
        {
            public override Figure ModelCreator(int x, int y, int w, int h, Color fillcolor, Color linecolor)
            {
                return new Triangle(x, y, w, h, fillcolor, linecolor);
            }
        }
    }
}
