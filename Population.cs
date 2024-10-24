using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Inteligenta_Artificiala
{
    internal class Population
    {
        static int N = 5000;
        static int K = 30;
        public List<Solution> solutions;
        public List<Solution> par;

        public static Random random = new Random();

        public Population()
        {
            solutions = new List<Solution>();
            for (int i = 0; i < N; i++)
                solutions.Add(new Solution(AG.graph));

            par = new List<Solution>();
        }

        public void Sort()
        {
            solutions.Sort(delegate (Solution A, Solution B) { return A.Fitness().CompareTo(B.Fitness()); });
        }

        public void Selection()
        {
            par.Clear();
            for (int i = 0; i < K; i++)
                par.Add(solutions[i]);
        }

        public Solution Cross(Solution A, Solution B)
        {
            Solution toRet = new Solution(AG.graph);

            int t = random.Next(1, toRet.graph.vertices.Count - 1);

            for (int i = 0; i < t; i++)
            {
                toRet.graph.vertices[i].location.X = A.graph.vertices[i].location.X;
                toRet.graph.vertices[i].location.Y = A.graph.vertices[i].location.Y;
            }

            for (int i = t; i < B.graph.vertices.Count; i++)
            {
                toRet.graph.vertices[i].location.X = B.graph.vertices[i].location.X;
                toRet.graph.vertices[i].location.Y = B.graph.vertices[i].location.Y;
            }

            return toRet;
        }
    }
}
