using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Фигуры_2
{
    internal abstract class CornerStrategy : Rectangle
    {
        public CornerStrategy(int x, int y, int w, int h, System.Drawing.Color fillcolor, System.Drawing.Color linecolor) : base(x, y, w, h, fillcolor, linecolor)
        {
        }

        public abstract void Execute(Figure f, int dx, int dy);
    }

    internal class DownRightCorner : CornerStrategy
    {
        public DownRightCorner(int x, int y, int w, int h, System.Drawing.Color fillcolor, System.Drawing.Color linecolor) : base(x, y, w, h, fillcolor, linecolor)
        {
        }

        public override void Execute(Figure f, int dx, int dy)
        {
            f.Resize(dx, dy);
        }
    }
    internal class DownLeftCorner : CornerStrategy
    {
        public DownLeftCorner(int x, int y, int w, int h, System.Drawing.Color fillcolor, System.Drawing.Color linecolor) : base(x, y, w, h, fillcolor, linecolor)
        {
        }

        public override void Execute(Figure f, int dx, int dy)
        {
            f.Location(0, dy);
            f.Resize(dx, 0);
        }
    }
    internal class UpRightCorner : CornerStrategy
    {
        public UpRightCorner(int x, int y, int w, int h, System.Drawing.Color fillcolor, System.Drawing.Color linecolor) : base(x, y, w, h, fillcolor, linecolor)
        {
        }

        public override void Execute(Figure f, int dx, int dy)
        {
            f.Location(0, dy);
            f.Resize(dx, dy);
        }
    }
    internal class UpLeftCorner : CornerStrategy
    {
        public UpLeftCorner(int x, int y, int w, int h, System.Drawing.Color fillcolor, System.Drawing.Color linecolor) : base(x, y, w, h, fillcolor, linecolor)
        {
        }

        public override void Execute(Figure f, int dx, int dy)
        {
            f.Location(dx,dy);
            f.Resize(dx, dy);
        }
    }
}
