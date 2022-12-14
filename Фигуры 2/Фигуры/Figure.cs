using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Фигуры_2
{
    [Serializable]
     abstract class Figure
    {
        public int w { get; set; }
        public int h { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public Color fillcolor { get; set; }
        public Color linecolor { get; set; }

        [NonSerialized]
        public bool choice = false;
        public Figure() { }
        public Figure(int x, int y, int w, int h, Color fillcolor, Color linecolor)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
            this.fillcolor = fillcolor;
            this.linecolor = linecolor;        
        }
        public virtual void Resize(int x,int y)
        {
            w += x;
            h += y;
        }
        public virtual void Location(int x,int y)
        {
            this.x += x;
            this.y += y;
        }
        public abstract bool IsIn(int x, int y);
        public abstract void Draw(Graphics g);

        public virtual Figure Clone()
        {
            Figure fig = (Figure)this.MemberwiseClone();
            fig.x += 30;
            fig.y += 30;
            return fig;
        }
    }

}
