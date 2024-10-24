using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteligenta_Artificiala
{
    internal class Solution
    {
        public Graph graph;
        public static float k = 1;
        public static Random random = new Random();

        // ---------------------------------------------------------------

        public Solution(Graph graph)
        {
            this.graph = graph.Clone();
        }

        // ---------------------------------------------------------------

        public float Fitness()
        {
            float fitness = 0;

            foreach (Edge edge in graph.edges)
                fitness += (edge.AbsoluteDistance * k - edge.Cost * k) * (edge.AbsoluteDistance * k - edge.Cost * k);

            return fitness;
        }

        public void Draw(Graphics handler)
        {
            this.graph.Draw(handler);
        }

        public void Mutate(float radius)
        {
            int r = random.Next(this.graph.vertices.Count);
            float alpha = (float)(random.NextDouble() * 2 * Math.PI);

            /*float xPrim = this.graph.vertices[r].location.X + radius * (float)Math.Cos(alpha);
            float yPrim = this.graph.vertices[r].location.Y + radius * (float)Math.Sin(alpha);
            this.graph.vertices[r].location.X = xPrim;
            this.graph.vertices[r].location.Y = yPrim;*/

            this.graph.vertices[r].location.X += radius * (float)Math.Cos(alpha);
            this.graph.vertices[r].location.Y += radius * (float)Math.Sin(alpha);
        }
    }
}
