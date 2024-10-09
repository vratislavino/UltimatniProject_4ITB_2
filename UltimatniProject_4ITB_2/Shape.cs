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
        protected int y;
        protected int width;
        protected int height;
        protected bool filled;

        protected Pen pen;
        protected Brush brush;

        protected bool highlighted = false;

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
        }

        public virtual void Draw(Graphics g)
        {
            if(highlighted)
            {
                g.DrawRectangle(Pens.Black, x,y,width, height);
            }
        }

        public abstract bool IsMouseOver(int mX, int mY);

        public abstract void DoYourThing();

        public void Highlight()
        {
            highlighted = true;
        }
    }
}
