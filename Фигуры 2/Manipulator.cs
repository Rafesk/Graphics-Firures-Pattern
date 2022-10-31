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
        Figure[] masfig = new Triangle[4];
        Figure ob;
        public override void Draw(Graphics g)
        {
            ob.Draw(g);
            masfig[0].Draw(g);
            masfig[1].Draw(g);
            masfig[2].Draw(g);
            masfig[3].Draw(g);
            /*
             * Прорисовка всех фигур
             */
        }

        public override bool IsIn(int x, int y)
        {
            /*
             * в какой сектор попал
             */
            return false;
        }
        public void Location(int x, int y)
        {
            ob.Location(x-10, y-10);
            masfig[0].Location(ob.x - 30, ob.y - 30);
            masfig[1].Location(ob.x + ob.w, ob.y - 30);
            masfig[2].Location(ob.x + ob.w, ob.y + ob.h);
            masfig[3].Location(ob.x - 30, ob.y + ob.h);
            /*
             * Изменение положение всех секторов, вместе с фигурой
             */
        }
        public void Resize(int x, int y)
        {
            /*
             * Перерисовка всех секторов, при изменение
             */
        }
        public void SetFigure(Figure f)
        {
            this.fig = f;
            int x = fig.x, y = fig.y, width = fig.w, height = fig.h;
            Color fillcolor = Color.Transparent, linecolor = Color.Black;
            ob = new Rectangle(x - 10, y - 10, width + 20, height + 20, fillcolor, linecolor);
            masfig[0] = new Rectangle(ob.x - 30, ob.y - 30, 30, 30, fillcolor, linecolor) ;
            masfig[1] = new Rectangle(ob.x+ob.w, ob.y-30, 30,30, fillcolor, linecolor);
            masfig[2] = new Rectangle(ob.x+ob.w, ob.y+ob.h, 30,30, fillcolor, linecolor);
            masfig[3] = new Rectangle(ob.x-30, ob.y+ob.h, 30, 30, fillcolor, linecolor);
            /*
             * Выбранная фигура
             * Создание рамики вокруг, создание новых элементов вокруг фигуры, 5 секторов.
             */
        }
        public void Drag(int dx, int dy)
        {
            /*
             * изменение фигуры в зависимости от того, какой сектор
             */
        }
    }
}
