using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class DepthFirstTraverse
    {     
     class StackX
     {
        private const int SIZE = 20;
        private int[] st;
        private int top;

        public StackX()
        {
            st = new int[SIZE];
            top = -1;
        }

        public void Push(int j)
        {
            st[++top] = j;
        }

        public int Pop()
        {
            return st[top--];
        }

        public int Peek()
        {
            return st[top];
        }

        public bool IsEmpty()
        {
            return (top == -1);
        }
    }

    class Vertex
    {
        public char Label { get; }
        public bool WasVisited { get; set; }

        public Vertex(char lab)
        {
            Label = lab;
            WasVisited = false;
        }
    }

    class Graph
    {
        private const int MAX_VERTS = 20;
        private Vertex[] vertexList;
        private int[,] adjMat;
        private int nVerts;
        private StackX theStack;

        public Graph()
        {
            vertexList = new Vertex[MAX_VERTS];
            adjMat = new int[MAX_VERTS, MAX_VERTS];
            nVerts = 0;

            for (int j = 0; j < MAX_VERTS; j++)
            {
                for (int k = 0; k < MAX_VERTS; k++)
                {
                    adjMat[j, k] = 0;
                }
            }

            theStack = new StackX();
        }

        public void AddVertex(char lab)
        {
            vertexList[nVerts++] = new Vertex(lab);
        }

        public void AddEdge(int start, int end)
        {
            adjMat[start, end] = 1;
            adjMat[end, start] = 1;
        }

        public void DisplayVertex(int v)
        {
            Console.Write(vertexList[v].Label);
        }

        public void Dfs()
        {
            vertexList[0].WasVisited = true;
            DisplayVertex(0);
            theStack.Push(0);

            while (!theStack.IsEmpty())
            {
                int v = GetAdjUnvisitedVertex(theStack.Peek());

                if (v == -1)
                {
                    theStack.Pop();
                }
                else
                {
                    vertexList[v].WasVisited = true;
                    DisplayVertex(v);
                    theStack.Push(v);
                }
            }

            for (int j = 0; j < nVerts; j++)
            {
                vertexList[j].WasVisited = false;
            }
        }

        public int GetAdjUnvisitedVertex(int v)
        {
            for (int j = 0; j < nVerts; j++)
            {
                if (adjMat[v, j] == 1 && !vertexList[j].WasVisited)
                {
                    return j;
                }
            }
            return -1;
        }
    }
        public void runDFT()
        {
           
                Graph theGraph = new Graph();
                theGraph.AddVertex('A'); // 0 (start for dfs)
                theGraph.AddVertex('B'); // 1
                theGraph.AddVertex('C'); // 2
                theGraph.AddVertex('D'); // 3
                theGraph.AddVertex('E'); // 4

                theGraph.AddEdge(0, 1); // AB
                theGraph.AddEdge(1, 2); // BC
                theGraph.AddEdge(0, 3); // AD
                theGraph.AddEdge(3, 4); // DE

                Console.Write("Visits: ");
                theGraph.Dfs(); // depth-first search
                Console.WriteLine();

            }
        }

    }

