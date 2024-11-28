using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Inteligenta_Artificiala
{
    public class Edge
    {
        Vertex start, end;

        float cost, absoluteDistance;
        string info;

        public Vertex Start { get { return start; } }
        public Vertex End { get { return end; } }
        public float Cost { get { return cost; } }
        public string Info { get { return info; } }
        public float AbsoluteDistance { get { return absoluteDistance; } }

        // ---------------------------------------------------------------

        public Edge(Vertex start, Vertex end)
        {
            this.start = start;
            this.end = end;
        }

        public Edge(string data, List<Vertex> vertices)
        {
            this.info = data;
            string[] dataSplit = data.Split(' ');

            this.start = vertices[int.Parse(dataSplit[0])];
            this.end = vertices[int.Parse(dataSplit[1])];
            this.cost = float.Parse(dataSplit[2]);

            absoluteDistance = (float)Math.Sqrt((start.location.X - end.location.X) * (start.location.X - end.location.X) +
                                                (start.location.Y - end.location.Y) * (start.location.Y - end.location.Y));
        }

        // ---------------------------------------------------------------

        public void Draw(Graphics handler)
        {
            handler.DrawLine(Pens.Black, Start.location, End.location);
        }
    }
}
