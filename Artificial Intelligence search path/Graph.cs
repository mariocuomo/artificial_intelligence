using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artificial_Intelligence
{
    class Graph<String>
    {
        /*
         * this is a non oriented graph
         * we suppose that if there is the edge ("Roma","Milano",x)=("Milano","Roma",x) 
         * and there is just one couple of them
         * 
        */
        
        private List<(String, String, int)> edge = new List<(String, String, int)>();

        //we suppose that the list is correct
        public Graph(List<(String, String, int)> edge)
        {
            this.edge = edge;
        }

        public List<String> getNeighborhoods(String node)
        {   
            List <String> tmp = new List<String>();

            foreach ((String, String, int) item in edge)
            {
                if (item.Item1.Equals(node))
                    tmp.Add(item.Item2);
                if (item.Item2.Equals(node))
                    tmp.Add(item.Item1);
            }

            return tmp;
        }


        public List<String> getNodes()
        {
            List<String> tmp = new List<String>();

            foreach ((String, String, int) item in edge)
            {
                if (!tmp.Contains(item.Item1))
                    tmp.Add(item.Item1);
                if (!tmp.Contains(item.Item2))
                    tmp.Add(item.Item2);
            }

            return tmp;
        }

    }
}
