using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
  

    public class DijkstraShortestPath
    {
        private const int INFINITY = int.MaxValue;
        public void Main()
        {
            int[,] graph = {
            {0, 4, 0, 0, 0, 0, 0, 8, 0},
            {4, 0, 8, 0, 0, 0, 0, 11, 0},
            {0, 8, 0, 7, 0, 4, 0, 0, 2},
            {0, 0, 7, 0, 9, 14, 0, 0, 0},
            {0, 0, 0, 9, 0, 10, 0, 0, 0},
            {0, 0, 4, 14, 10, 0, 2, 0, 0},
            {0, 0, 0, 0, 0, 2, 0, 1, 6},
            {8, 11, 0, 0, 0, 0, 1, 0, 7},
            {0, 0, 2, 0, 0, 0, 6, 7, 0}
        };

            int startNode = 0;
            int[] distances = Dijkstra(graph, startNode);
            Console.WriteLine("Shortest distances from node " + startNode + " to all other nodes:");
            for (int i = 0; i < distances.Length; i++)
            {
                Console.WriteLine($"Node {i}: {distances[i]}");
            }
        }

        private static int[] Dijkstra(int[,] graph, int startNode)
        {
            int n = graph.GetLength(0);
            int[] distances = new int[n];
            bool[] visited = new bool[n];

            for (int i = 0; i < n; i++)
            {
                distances[i] = INFINITY;
                visited[i] = false;
            }

            distances[startNode] = 0;

            for (int count = 0; count < n - 1; count++)
            {
                int minDistance = FindMinDistance(distances, visited);
                visited[minDistance] = true;

                for (int i = 0; i < n; i++)
                {
                    if (!visited[i] && graph[minDistance, i] != 0 && distances[minDistance] != INFINITY &&
                        distances[minDistance] + graph[minDistance, i] < distances[i])
                    {
                        distances[i] = distances[minDistance] + graph[minDistance, i];
                    }
                }
            }

            return distances;
        }

        private static int FindMinDistance(int[] distances, bool[] visited)
        {
            int min = INFINITY;
            int minIndex = -1;

            for (int i = 0; i < distances.Length; i++)
            {
                if (!visited[i] && distances[i] <= min)
                {
                    min = distances[i];
                    minIndex = i;
                }
            }

            return minIndex;
        }
    }

}
