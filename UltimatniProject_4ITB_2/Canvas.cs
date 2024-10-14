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
        public IReadOnlyList<Shape> Shapes => shapes;

        Shape currentShape = null;
        bool isDragging = false;

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
            if (shapes.Count == 0) return;

            if(currentShape != null && isDragging)
            {
                currentShape.Move(e.X, e.Y);
                Invalidate();
                return;
            }

            var shape = shapes.FirstOrDefault(s => s.IsMouseOver(e.X, e.Y));
            if (shape != null)
            {
                if (currentShape != null)
                    currentShape.Highlight(false);

                currentShape = shape;
                currentShape.Highlight(true);
            }
            else
            {
                if (currentShape != null)
                {
                    currentShape.Highlight(false);
                    currentShape = null;
                }
            }
            Invalidate();
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if(currentShape != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    currentShape.dragOffsetX = e.X - currentShape.X;
                    currentShape.dragOffsetY = e.Y - currentShape.Y;
                    isDragging = true;
                }
            }
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
                isDragging = false;
        }

        public void ClearShapes()
        {
            shapes.Clear();
            currentShape = null;
            Invalidate();
        }
    }
}
