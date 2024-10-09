using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimatniProject_4ITB_2
{
    public class Square : Shape
    {
        public Square(Color color, int x, int y, bool filled) : base(color, x, y, filled)
        {
        }

        public override void Draw(Graphics g)
        {
            if(filled)
            {
                g.FillRectangle(brush, x, y, width, height);
            } else
            {
                g.DrawRectangle(pen, x, y, width, height);
            }
            base.Draw(g);
        }

        public override void DoYourThing()
        {
            throw new NotImplementedException();
        }

        public override bool IsMouseOver(int mX, int mY)
        {
            return 
                mX >= x && 
                mX <= x + width && 
                mY >= y && 
                mY <= y + height;
        }
    }
}
