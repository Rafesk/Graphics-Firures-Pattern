using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Фигуры_2
{
    public partial class Form1 : Form
    {
        Creator creator;
        MFigures figures = new MFigures();
        Manipulator manipulator = new Manipulator();
        int x1, y1;
        Figure obj;
        GroupFigure group = new GroupFigure(0, 0, 0, 0, Color.Transparent, Color.Transparent);
        bool down = false;
        Dictionary<string, Creator> creators = new Dictionary<string, Creator>();

        public Form1()
        {
            InitializeComponent();

            creators.Add("Rectangle", new Rectangle.CreateRectangle());
            creators.Add("Ellipse", new Ellipse.CreateEllipse());
            creators.Add("Triangle", new Triangle.CreateTriangle());
            creators.Add("Select", null);
        }

        private void button_Click(object sender, EventArgs e)
        {
            creator = creators[((Button)sender).Tag.ToString()];
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Figure f in figures.mfigures)
            {
                f.Draw(e.Graphics);
            }
            manipulator.Draw(e.Graphics);
        }


        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (down)
            {
                if (creator == null)
                {
                    manipulator.Drag(e.X-x1, e.Y-y1);
                }
                
            }
            Refresh();
            x1 = e.X;
            y1 = e.Y;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            x1 = e.X;
            y1 = e.Y;
            if (creator != null)
            {
                obj = creator.ModelCreator(x1, y1, 50, 50, colorDialog1.Color, Color.Black);
                figures.AddFigure(obj);
            }
            else
            {
                if (!manipulator.IsIn(x1, y1))
                {
                    var tmp = figures.Hit(x1, y1);
                    if (e.Button == MouseButtons.Right)
                    {
                        group.AddFigure(tmp);
                        manipulator.SetFigure(group);
                    }
                    else
                    {
                        manipulator.SetFigure(tmp);
                        group.Clear();
                        //manipulator.Clear();
                    }
                }
                

            }
            down = true;

        }

        private void button9_Click(object sender, EventArgs e)//копировать
        {
            if (manipulator.IsEmpty()) { return; }
            figures.AddFigure(manipulator.Clone());
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            obj = null;
            down = false;
        }
    }
}
