using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Фигуры_2
{
    [Serializable]
    class Rectangle : Figure
    {
        public Rectangle(int x, int y, int w, int h, Color fillcolor, Color linecolor) : base(x, y, w, h, fillcolor, linecolor) { }
        public override void Draw(Graphics g)
        {
            g.FillRectangle(new SolidBrush(fillcolor), x, y, w, h);
            g.DrawRectangle(new Pen(linecolor), x, y, w, h);
        }
        public override bool IsIn(int x, int y)
        {            
            return (x > this.x && x < (this.w + this.x)) && (y > this.y && y < (this.h + this.y));
        }


        public class CreateRectangle :Creator
        {
            public override Figure ModelCreator(int x, int y, int w, int h, Color fillcolor, Color linecolor)
            {
                return new Rectangle(x,y,w,h,fillcolor,linecolor);
            }
        }
    }
}
