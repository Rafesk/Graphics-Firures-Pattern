﻿using System;
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
        GroupFigure group = new GroupFigure(0,0,0,0, Color.Transparent, Color.Transparent);
        bool down = false;
        Dictionary<string, Creator> creators = new Dictionary<string, Creator>();

        public Form1()
        {
            InitializeComponent();

            creators.Add("Rectangle", new Rectangle.CreateRectangle());
            creators.Add("Ellipse", new Ellipse.CreateEllipse());
            creators.Add("Triangle", new Triangle.CreateTriangle());
            creators.Add("Group", new GroupFigure.CreateGroup());
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
                    manipulator.Drag(e.X, e.Y);
                }
                else
                {
                    obj.Resize(e.X, e.Y);
                }
                Refresh();
            }

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            x1 = e.X;
            y1 = e.Y;
            if (creator != null)
            {
                obj = creator.ModelCreator(x1, y1, 1, 1, colorDialog1.Color, Color.Black);
                if (creator is GroupFigure.CreateGroup) figures.AddFigure(group);
                else figures.AddFigure(obj);
                

            }
            else
            {
                if (!manipulator.IsIn(x1, y1))
                {
                    manipulator.SetFigure(figures.Hit(x1, y1));
                    if (figures.Hit(x1, y1) != null) { figures.Hit(x1, y1).NACH(x1, y1); }
                }
                
            }
            down = true;

        } 

        private void button9_Click(object sender, EventArgs e)//копировать
        {
            if (figures.Hit(x1, y1)== null) { return; }
            figures.AddFigure(figures.Hit(x1, y1).Clone());
        }

        private void button6_Click(object sender, EventArgs e)//добавить в группу
        {
            if(creator == null && figures.Hit(x1, y1) != null)
            {
                group.AddFigure(figures.Hit(x1, y1).Clone());
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            obj = null;
            down = false;
        }
    }
}
