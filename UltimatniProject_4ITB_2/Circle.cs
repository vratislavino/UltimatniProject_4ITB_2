using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimatniProject_4ITB_2
{
    public class Circle : Shape
    {
        public Circle(Color color, int x, int y, bool filled) : base(color, x, y, filled)
        {
        }

        public Circle(ShapeDTO data) : base(data)
        {
        }

        public override void DoYourThing()
        {
            height += 10;
            width += 10;
        }

        public override void Draw(Graphics g)
        {
            if(filled)
            {
                g.FillEllipse(brush, x, y, width, height);
            } else
            {
                g.DrawEllipse(pen, x, y, width, height);
            }
            base.Draw(g);
        }

        public override bool IsMouseOver(int mX, int mY)
        {
            // c = odm (a2 + b2)
            int sx = x + width / 2;
            int sy = y + height / 2;
            double distance = Math.Sqrt(Math.Pow(mX - sx, 2) + Math.Pow(mY - sy, 2));
            return distance < width / 2;
        }
    }
}
