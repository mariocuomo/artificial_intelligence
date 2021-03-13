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
        }

        static void printPath(List<String> path)
        {
            StringBuilder sb = new StringBuilder();
            foreach (String state in path)
                sb.Append(state + "\n");
            
            Console.WriteLine(sb.ToString());
        }

    }

}
