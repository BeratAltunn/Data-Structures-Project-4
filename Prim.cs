using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    using System;

    public class PrimsMinimumSpanningTree
    {
        private const int INFINITY = int.MaxValue;

        public void Main()
        {
            int[,] graph = {
            {0, 2, 0, 6, 0},
            {2, 0, 3, 8, 5},
            {0, 3, 0, 0, 7},
            {6, 8, 0, 0, 9},
            {0, 5, 7, 9, 0}
        };

            int[] parent = PrimsMST(graph);

            Console.WriteLine("Edges in the minimum spanning tree:");
            for (int i = 1; i < graph.GetLength(0); i++)
            {
                Console.WriteLine($"Edge {parent[i]} - {i}, Weight: {graph[i, parent[i]]}");
            }
            Console.WriteLine();
        }
        

        private static int[] PrimsMST(int[,] graph)
        {
            int n = graph.GetLength(0);
            int[] parent = new int[n];
            int[] key = new int[n];
            bool[] mstSet = new bool[n];

            for (int i = 0; i < n; i++)
            {
                key[i] = INFINITY;
                mstSet[i] = false;
            }

            key[0] = 0;
            parent[0] = -1;

            for (int count = 0; count < n - 1; count++)
            {
                int u = MinKey(key, mstSet);
                mstSet[u] = true;

                for (int v = 0; v < n; v++)
                {
                    if (graph[u, v] != 0 && !mstSet[v] && graph[u, v] < key[v])
                    {
                        parent[v] = u;
                        key[v] = graph[u, v];
                    }
                }
            }

            return parent;
        }

        private static int MinKey(int[] key, bool[] mstSet)
        {
            int min = INFINITY;
            int minIndex = -1;

            for (int v = 0; v < key.Length; v++)
            {
                if (!mstSet[v] && key[v] < min)
                {
                    min = key[v];
                    minIndex = v;
                }
            }

            return minIndex;
        }
    }

}
