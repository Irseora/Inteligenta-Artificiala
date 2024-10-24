using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteligenta_Artificiala
{
    public class Graph
    {
        public List<Vertex> vertices;
        public List<Edge> edges;
        Random random = new Random();

        // ------------------------------------------------------------------------------------------

        public Graph(string fileName)
        {
            vertices = new List<Vertex>();
            edges = new List<Edge>();

            TextReader sr = new StreamReader(fileName);

            int n = int.Parse(sr.ReadLine());

            vertices = new List<Vertex>();
            for (int i = 0; i < n; i++)
                vertices.Add(new Vertex(i.ToString(), random));

            string line;
            while ((line =  sr.ReadLine()) != null)
                edges.Add(new Edge(line, vertices));
        }

        public Graph()
        {
            vertices = new List<Vertex>();
            edges = new List<Edge>();
        }

        // ------------------------------------------------------------------------------------------

        public void Draw(Graphics handler)
        {
            foreach (Vertex vertex in vertices) vertex.Draw(handler);
            foreach (Edge edge in edges) edge.Draw(handler);
        }

        public Graph Clone()
        {
            Graph clone = new Graph();

            for (int i = 0; i < this.vertices.Count; i++)
                clone.vertices.Add(new Vertex(i.ToString(), random));

            foreach (Edge edge in this.edges)
                clone.edges.Add(new Edge(edge.Info, clone.vertices));

            return clone;
        }
    }
}
