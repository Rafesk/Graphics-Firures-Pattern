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
        public int deltX = 0;
        public int deltY = 0;
        public int xN = 0;
        public int yN = 0;
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
        public void DELT(int x, int y)
        {
            deltX = x-this.x;
            deltY = y-this.y;
        }
        public void NACH(int x, int y)
        {
            DELT(x, y);
            xN = x;
            yN = y;
        }
        public void Resize(int x,int y)
        {
            w = x - this.x;
            h = y - this.y;
        }
        public void Location(int x,int y)
        {
            this.x = x-deltX;
            this.y = y-deltY;
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
