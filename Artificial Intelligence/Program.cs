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
            List<String> path = Service.searchPath(graph);
            if(path==null)
                Console.WriteLine("No path available");
            else{
                StringBuilder sb = new StringBuilder();
                sb.Append("Path available\n");
                foreach (String state in path)
                {
                    sb.Append(state+"\n");
                }

                Console.WriteLine(sb.ToString());
            }
        }
    }

}
