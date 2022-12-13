using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Фигуры_2
{
    internal class Manipulator : Figure
    {
        Figure fig;
        Action<Figure,int,int> activeStrategy;
        CornerStrategy[] masfig = new CornerStrategy[4];
        public Manipulator()
        {
            fillcolor= linecolor = Color.Red;

            masfig[0] = new UpLeftCorner(0, 0, 30, 30, fillcolor, linecolor);
            masfig[1] = new UpRightCorner(0, 0, 30, 30, fillcolor, linecolor);
            masfig[2] = new DownRightCorner(0, 0, 30, 30, fillcolor, linecolor);
            masfig[3] = new DownLeftCorner(0, 0, 30, 30, fillcolor, linecolor);
        }
        public override void Draw(Graphics g)
        {
            if (fig == null) return;
            g.DrawRectangle(Pens.Black, x, y, w, h);
            

            fig.Draw(g);
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
            if (fig == null) return false;
            for (int i = 0; i < masfig.Length; i++)
            {
                if (masfig[i].IsIn(x, y))
                {
                    activeStrategy = masfig[i].Execute;
                    return true;
                }
            }
            if (fig.IsIn(x, y))
            {
                activeStrategy = MoveStrategy;
                return true;
            }
            /*
             * в какой сектор попал
             */
            activeStrategy = null;
            return false;
        }
        public void Location(int x, int y)
        {
            fig.Location(x, y);

            Update();

            /*
             * Изменение положение всех секторов, вместе с фигурой
             */
        }

        private void Update()
        {
            masfig[0].Location(fig.x - 30, fig.y - 30);
            masfig[1].Location(fig.x + fig.w, fig.y - 30);
            masfig[2].Location(fig.x + fig.w, fig.y + fig.h);
            masfig[3].Location(fig.x - 30, fig.y + fig.h);

            x = fig.x;
            y = fig.y;
            w = fig.w;
            h = fig.h;
        }
        public void Resize(int x, int y)
        {
            if (fig == null) return;
            fig.Resize(x, y);
            Update();
            /*
             * Перерисовка всех секторов, при изменение
             */
        }
        public void SetFigure(Figure f)
        {
            this.fig = f;
            if (fig == null) return;
            Update();

            /*
             * Выбранная фигура
             * Создание рамки вокруг, создание новых элементов вокруг фигуры, 5 секторов.
             */
        }
        public void Drag(int dx, int dy)
        {
            if (fig == null) return;
            activeStrategy?.Invoke(fig, dx, dy);
            Update();
            /*
             * изменение фигуры в зависимости от того, какой сектор
             */
        }

        public void MoveStrategy(Figure f, int dx, int dy)
        {
            f.Location(dx, dy);
        }
    }
}
