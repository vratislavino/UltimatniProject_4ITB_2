using System.Drawing;
using UltimatniProject_4ITB_2;

namespace MyNewShapes
{
    public class Triangle : Shape
    {
        public Triangle(Color color, int x, int y, bool filled) : base(color, x, y, filled)
        {
        }

        public Triangle(ShapeDTO data) : base(data) { }

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

        public override void Draw(Graphics g)
        {
            if(filled)
            {
                g.FillPolygon(brush, new Point[] {
                    new Point(x, y + height),
                    new Point(x + width, y + height),
                    new Point(x+width/2, y)
                });
            } else
            {
                g.DrawPolygon(pen, new Point[] {
                    new Point(x, y + height),
                    new Point(x + width, y + height),
                    new Point(x+width/2, y)
                });
            }
            base.Draw(g);
        }
    }
}
