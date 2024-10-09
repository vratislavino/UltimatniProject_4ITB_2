using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UltimatniProject_4ITB_2
{
    public partial class Canvas : UserControl
    {
        List<Shape> shapes = new List<Shape>();

        public Canvas()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        internal void AddShape(Shape shape)
        {
            shapes.Add(shape);
            Invalidate();
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            foreach (var shape in shapes)
            {
                shape.Draw(e.Graphics);
            }
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            foreach(var shape in shapes)
            {
                if(shape.IsMouseOver(e.X, e.Y)) // ještě odoznačit
                {
                    shape.Highlight();
                    Invalidate();
                    break;
                }
            }
        }
    }
}
