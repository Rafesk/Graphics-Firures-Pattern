using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Фигуры_2
{
    internal class GroupFigure : Figure
    {
        List<Figure> figures = new List<Figure>();
        public GroupFigure(int x, int y, int w, int h, Color fillcolor, Color linecolor) : base(x, y, w, h, fillcolor, linecolor)
        {}
        public class CreateGroup : Creator
        {
            public override Figure ModelCreator(int x, int y, int w, int h, Color fillcolor, Color linecolor)
            {
                return new Rectangle(x, y, w, h, Color.Transparent, Color.Transparent);
            }
        }


        public void AddFigure(Figure f)
        {
            if (f == null) return;
            figures.Add(f);
            LocationAndResize();
        }
        public void LocationAndResize()
        {
            int minX,minY, maxXW, maxYH;
            maxXW = maxYH = 0;
            minX=minY = 10000;
            
            foreach (Figure figure in figures)
            {
                if (figure.x < minX) minX = figure.x;
                if (figure.y < minY) minY = figure.y;
                if (figure.x+figure.w > maxXW) maxXW = figure.x+figure.w;
                if (figure.y+figure.h > maxYH) maxYH = figure.y+ figure.h;
            }
            x = minX;
            y = minY;
            w = maxXW;
            h = maxYH;
        }

        public override bool IsIn(int x, int y)
        {
            return (x > this.x && x < (this.w + this.x)) && (y > this.y && y < (this.h + this.y));
        }
        public override void Draw(Graphics g)
        {
            foreach (Figure figure in figures)
            {
                figure.Draw(g);
            }
        }
    }
}
