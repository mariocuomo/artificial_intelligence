using System;
using System.Collections.Generic;
using System.Text;

namespace Artificial_Intelligence
{
    class Program
    {
        static void Main(string[] args)
        {            
            Graph<String> graph = new Graph<string>(Service.ListGraph());
            Console.WriteLine("Search path using BFS...");

            List<String> path = Service.searchPath_BFS(graph);
            if(path==null)
                Console.WriteLine("No path available");
            else{
                Console.WriteLine("Path available");
                printPath(path);
            }


            Console.WriteLine("Search path using DFS...");

            path = Service.searchPath_DFS(graph);
            if (path == null)
                Console.WriteLine("No path available");
            else
            {
                Console.WriteLine("Path available");
                printPath(path);
            }


            Console.WriteLine("Search path using DFS Recursive...");

            path = Service.searchPath_DFS_Recursive(graph);
            if (path == null)
                Console.WriteLine("No path available");
            else
            {
                Console.WriteLine("Path available");
                printPath(path);
            }

            Console.WriteLine("Search path using Depth Limited Search...");

            path = Service.searchPath_DFS_Limited(graph);
            if (path == null)
                Console.WriteLine("No path available");
            else
            {
                Console.WriteLine("Path available");
                printPath(path);
            }

            Console.WriteLine("Search path using Uniform Cost Search...");

            path = Service.searchPathUCS(graph);
            if (path == null)
                Console.WriteLine("No path available");
            else
            {
                Console.WriteLine("Path available");
                printPath(path);
            }

            Console.WriteLine("Search path using Greedy...");

            path = Service.searchPath_Greedy(graph);
            if (path == null)
                Console.WriteLine("No path available");
            else
            {
                Console.WriteLine("Path available");
                printPath(path);
            }

            Console.WriteLine("Search path using A*...");

            path = Service.searchPath_AStar(graph);
            if (path == null)
                Console.WriteLine("No path available");
            else
            {
                Console.WriteLine("Path available");
                printPath(path);
            }
        }

        static void printPath(List<String> path)
        {
            StringBuilder sb = new StringBuilder();
            foreach (String state in path)
                sb.Append(state + "\n");
            sb.Append("The cost of the path is " + Service.getCost(path)+"\n");
            
            Console.WriteLine(sb.ToString());
        }


    }

}
