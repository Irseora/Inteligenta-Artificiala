using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteligenta_Artificiala
{
    public class Vertex
    {
        public PointF location;

        public string name;
        public static int resX = 500, resY = 500;

        // ---------------------------------------------------------------

        public Vertex(string name, Random random)
        {
            this.name = name;
            this.location.X = random.Next(0, resX);
            this.location.Y = random.Next(0, resY);
        }

        // ---------------------------------------------------------------

        public void Draw(Graphics handler)
        {
            int size = 3;
            handler.DrawEllipse(Pens.Black, location.X, location.Y, size, size);
        }
    }
}
