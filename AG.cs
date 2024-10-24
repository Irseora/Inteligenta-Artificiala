using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteligenta_Artificiala
{
    public static class AG
    {
        public static Graph graph;

        public static void Init()
        {
            graph = new Graph(@"../../GraphIn.txt");
        }
    }
}
