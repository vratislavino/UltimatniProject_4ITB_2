using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimatniProject_4ITB_2
{
    public abstract class Shape
    {
        protected Color color;
        protected int x;
        public int X => x;

        protected int y;
        public int Y => y;

        protected int width;
        protected int height;
        protected bool filled;

        protected Pen pen;
        protected Brush brush;

        private static Pen outlinePen = new Pen(Color.Black, 2f);

        protected bool highlighted = false;
        public int dragOffsetX = 0;
        public int dragOffsetY = 0;
        public Shape(Color color, int x, int y, bool filled)
        {
            this.color = color;
            pen = new Pen(color, 8f);
            brush = new SolidBrush(color);
            this.filled = filled;
            width = 100;
            height = 100;
            this.x = x-width/2;
            this.y = y-height/2;

            outlinePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            outlinePen.DashPattern = new float[] { 5, 5 };
        }

        public virtual void Draw(Graphics g)
        {
            if(highlighted)
            {
                g.DrawRectangle(
                    outlinePen, 
                    x - pen.Width / 2,
                    y - pen.Width / 2,
                    width + pen.Width,
                    height + pen.Width
                    );
            }
        }

        public abstract bool IsMouseOver(int mX, int mY);

        public abstract void DoYourThing();

        public void Highlight(bool enable)
        {
            highlighted = enable;
        }

        public void Move(int mx, int my)
        {
            this.x = mx - dragOffsetX;
            this.y = my - dragOffsetY;
        }
    }
}
