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
        public static float k = 2;
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
                fitness += (edge.AbsoluteDistance - edge.Cost * k) * (edge.AbsoluteDistance - edge.Cost * k);

            return fitness;
        }

        public void Draw(Graphics handler)
        {
            this.graph.Draw(handler);
        }

        /// <summary>
        /// 
        /// Radius tot mai mic pe masura ce ajungem mai aproape de solutie
        /// </summary>
        /// <param name="radius"></param>
        public void Mutate(float radius)
        {
            int r = random.Next(this.graph.vertices.Count);
            float alpha = (float)(random.NextDouble() * 2 * Math.PI);

            this.graph.vertices[r].location.X += radius * (float)Math.Cos(alpha);
            this.graph.vertices[r].location.Y += radius * (float)Math.Sin(alpha);
        }
    }
}
