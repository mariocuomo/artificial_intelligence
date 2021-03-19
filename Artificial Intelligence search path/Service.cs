using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artificial_Intelligence
{
    static class Service
    {
        static readonly List<(String, String, int)> distancecityToCity = new List<(String, String, int)>
            {
                    ( "Aquila", "Ancona",19),
                    ( "Aquila", "Perugia",17),
                    ( "Aquila", "Roma",11),
                    ( "Ancona", "Bari",46),
                    ( "Ancona", "Bologna",21),
                    ( "Ancona", "Perugia",16),
                    ( "Bari", "Roma",45),
                    ( "Bologna", "Firenze",10),
                    ( "Bologna", "Milano",21),
                    ( "Firenze", "Genova",22),
                    ( "Firenze", "Perugia",15),
                    ( "Firenze", "Pisa",9),
                    ( "Firenze", "Roma",28),
                    ( "Genova", "Milano",14),
                    ( "Genova", "Pisa",16),
                    ( "Milano", "Torino",14),
                    ( "Napoli", "Roma",22),
                    ( "Perugia", "Roma",17),
                    ( "Pisa", "Roma",37),
            };
        
        static readonly List<(String, int)> distanceTNaples = new List<(String, int)>
            {
                    ( "Aquila",18),
                    ( "Ancona",31),
                    ( "Bari",22),
                    ( "Bologna",47),
                    ( "Firenze",40),
                    ( "Genova",58),
                    ( "Milano",65),
                    ( "Perugia",29),
                    ( "Pisa",44),
                    ( "Roma",18),
                    ( "Torino",71),
            };

        static readonly String start = "Milano";
        static readonly String goal = "Napoli";

        static public List<(String, String, int)> ListGraph()
        {
            return distancecityToCity;
        }


        /*
            BFS, Breadth First Search
            This algorithm visits the graph by first observing the nodes at a distance of 1, then at a distance of 2 and so on from the starting node.
        */
        static public List<String> searchPath_BFS(Graph<String> graph)
        {
            Queue<TreeNode<String>> fringe = new Queue<TreeNode<string>>();
            TreeNode<String> tree = new TreeNode<String>(start);

            foreach (String item in graph.getNeighborhoods(start))
            {
                TreeNode<String> tmp = new TreeNode<String>(item);
                tmp.Parent = tree;
                fringe.Enqueue(tmp);
            }

            while (fringe.Count != 0)
            {
                TreeNode<String> node = fringe.Dequeue();
                if (node.value.Equals(goal))
                    return buildPath(node);

                foreach (String item in graph.getNeighborhoods(node.value))
                {
                    //delete loop
                    bool isInThePathToRoot = false;
                    TreeNode<String> tmp = node;
                    while (tmp != null && !isInThePathToRoot) {
                        if (tmp.value.Equals(item))
                            isInThePathToRoot = true;
                        tmp = tmp.Parent;
                    }

                    if (!isInThePathToRoot)
                    {
                        TreeNode<String> _tmp = new TreeNode<String>(item);
                        _tmp.Parent = node;
                        fringe.Enqueue(_tmp);
                    }

                }
            }

            return null;
        }

        /*
            DFS, Depth First Search
            This algorithm visits the graph in depth, i.e. from each node it continues the visit until there are no more unvisited nodes.  
        */
        static public List<String> searchPath_DFS(Graph<String> graph)
        {
            Stack<TreeNode<String>> fringe = new Stack<TreeNode<string>>();
            TreeNode<String> tree = new TreeNode<String>(start);

            foreach (String item in graph.getNeighborhoods(start))
            {
                TreeNode<String> tmp = new TreeNode<String>(item);
                tmp.Parent = tree;
                fringe.Push(tmp);
            }

            Stack<TreeNode<String>> tmp_fringe = new Stack<TreeNode<String>>(fringe.Reverse());
            fringe.Clear();

            while (tmp_fringe.Count != 0)
                fringe.Push(tmp_fringe.Pop());

            while (fringe.Count != 0)
            {
                TreeNode<String> node = fringe.Pop();
                
                if(node.value.Equals(goal))
                    return buildPath(node);

                List<String> lst = graph.getNeighborhoods(node.value);
                lst.Reverse();

                foreach(String item in lst)
                {
                    //delete loop
                    bool isInThePathToRoot = false;
                    TreeNode<String> tmp = node;
                    while (tmp != null && !isInThePathToRoot)
                    {
                        if (tmp.value.Equals(item))
                            isInThePathToRoot = true;
                        tmp = tmp.Parent;
                    }

                    if (!isInThePathToRoot)
                    {
                        TreeNode<String> _tmp = new TreeNode<String>(item);
                        _tmp.Parent = node;
                        fringe.Push(_tmp);
                    }
                }

            }


            return null;
        }

        /*
            DFS, Depth First Search Recursive Mode
            This method is exposed, that is, it represents the method called from outside 
        */
        static public List<String> searchPath_DFS_Recursive(Graph<String> graph)
        {
            TreeNode<String> tree = new TreeNode<String>(goal);
            return DFS(graph, start, tree);
        }
        /*
            DFS, Depth First Search Recursive Mode
            Called from Depth First Search Recursive Mode
        */
        static public List<String> DFS(Graph<String> graph, String node, TreeNode<String> tree)
        {
            foreach (String item in graph.getNeighborhoods(node))
            {
                if (item == goal)
                {
                    TreeNode<String> _tmp = new TreeNode<String>(item);
                    _tmp.Parent = tree;
                    return buildPath(_tmp);
                }

                bool isInThePathToRoot = false;
                TreeNode<String> tmp = new TreeNode<string>();
                tmp = tree;
                while (tmp != null && !isInThePathToRoot)
                {
                    if (tmp.value.Equals(item))
                        isInThePathToRoot = true;
                    tmp = tmp.Parent;
                }

                if (!isInThePathToRoot)
                {
                    TreeNode<String> _tmp = new TreeNode<String>(item);
                    _tmp.Parent = tree;
                    List<String> path = DFS(graph, item, _tmp);
                    if (path != null)
                        return path;
                }
            }


            return null;
        }

        /*
            DFS, Depth First Search Limited
            It searches to a maximum depth x 
            Maximum x cities visited 
        */
        static public List<String> searchPath_DFS_Limited(Graph<String> graph)
        {
            int max_depth = 6;
            Stack<TreeNode<String>> fringe = new Stack<TreeNode<string>>();
            TreeNode<String> tree = new TreeNode<String>(start);

            foreach (String item in graph.getNeighborhoods(start))
            {
                TreeNode<String> tmp = new TreeNode<String>(item);
                tmp.Parent = tree;
                fringe.Push(tmp);
            }

            Stack<TreeNode<String>> tmp_fringe = new Stack<TreeNode<String>>(fringe.Reverse());
            fringe.Clear();

            while (tmp_fringe.Count != 0)
                fringe.Push(tmp_fringe.Pop());

            while (fringe.Count != 0)
            {
                TreeNode<String> node = fringe.Pop();
                if (getDepth(node) < max_depth) {
                    if (node.value.Equals(goal))
                        return buildPath(node);

                    List<String> lst = graph.getNeighborhoods(node.value);
                    lst.Reverse();

                    foreach (String item in lst)
                    {
                        //delete loop
                        bool isInThePathToRoot = false;
                        TreeNode<String> tmp = node;
                        while (tmp != null && !isInThePathToRoot)
                        {
                            if (tmp.value.Equals(item))
                                isInThePathToRoot = true;
                            tmp = tmp.Parent;
                        }

                        if (!isInThePathToRoot)
                        {
                            TreeNode<String> _tmp = new TreeNode<String>(item);
                            _tmp.Parent = node;
                            fringe.Push(_tmp);
                        }
                    }
                }

            }


            return null;
        }

        /*
            DFS, Depth First Search Limited Iterative
            It searches to a maximum depth x 
            Maximum x cities visited 
        */
        static public List<String> searchPath_DFS_Itertive_Limited(Graph<String> graph)
        {
            int max_depth = 6;
            int i = 0;
            bool find = false;
            while(i<max_depth && !find) {
                i++;
                Console.WriteLine("Searching with max depth="+i+"...");
                Stack<TreeNode<String>> fringe = new Stack<TreeNode<string>>();
                TreeNode<String> tree = new TreeNode<String>(start);

                foreach (String item in graph.getNeighborhoods(start))
                {
                    TreeNode<String> tmp = new TreeNode<String>(item);
                    tmp.Parent = tree;
                    fringe.Push(tmp);
                }

                Stack<TreeNode<String>> tmp_fringe = new Stack<TreeNode<String>>(fringe.Reverse());
                fringe.Clear();

                while (tmp_fringe.Count != 0)
                    fringe.Push(tmp_fringe.Pop());

                while (fringe.Count != 0)
                {
                    TreeNode<String> node = fringe.Pop();
                    if (getDepth(node) < i)
                    {
                        if (node.value.Equals(goal))
                            return buildPath(node);

                        List<String> lst = graph.getNeighborhoods(node.value);
                        lst.Reverse();

                        foreach (String item in lst)
                        {
                            //delete loop
                            bool isInThePathToRoot = false;
                            TreeNode<String> tmp = node;
                            while (tmp != null && !isInThePathToRoot)
                            {
                                if (tmp.value.Equals(item))
                                    isInThePathToRoot = true;
                                tmp = tmp.Parent;
                            }

                            if (!isInThePathToRoot)
                            {
                                TreeNode<String> _tmp = new TreeNode<String>(item);
                                _tmp.Parent = node;
                                fringe.Push(_tmp);
                            }
                        }
                    }
                }

            }


            return null;
        }

        /*
            UCS, Uniform Cost Search
            In the fringe it expands the node with the min cost (cost of the path from the start to the node)
        */
        static public List<String> searchPathUCS(Graph<String> graph)
        {
            List<TreeNode<String>> fringe = new List<TreeNode<string>>();
            TreeNode<String> tree = new TreeNode<String>(start);

            foreach (String item in graph.getNeighborhoods(start))
            {
                TreeNode<String> tmp = new TreeNode<String>(item);
                tmp.Parent = tree;
                tmp.cost = findCost(start, item);
                fringe.Add(tmp);
            }

            while (fringe.Count != 0)
            {
                int min_cost = 0;
                foreach (TreeNode<String> item in fringe)
                {
                    if (item.cost < fringe.ElementAt(min_cost).cost)
                        min_cost = fringe.IndexOf(item);
                }

                TreeNode<String> node = fringe.ElementAt(min_cost);
                fringe.RemoveAt(min_cost);

                if (node.value.Equals(goal))
                    return buildPath(node);

                foreach (String item in graph.getNeighborhoods(node.value))
                {
                    //delete loop
                    bool isInThePathToRoot = false;
                    TreeNode<String> tmp = node;
                    while (tmp != null && !isInThePathToRoot)
                    {
                        if (tmp.value.Equals(item))
                            isInThePathToRoot = true;
                        tmp = tmp.Parent;
                    }

                    if (!isInThePathToRoot)
                    {
                        TreeNode<String> _tmp = new TreeNode<String>(item);
                        _tmp.Parent = node;
                        _tmp.cost= findCost(node.value, item)+ _tmp.Parent.cost;
                        fringe.Add(_tmp);
                    }

                }
            }

            return null;
        }


        /*
            Greedy Search
            It expands the node with the min cost expressed in distance as crow flies to the goal
        */
        static public List<String> searchPath_Greedy(Graph<String> graph)
        {
            TreeNode<String> tree = new TreeNode<String>(start);
            
            List<String> visited = new List<string>();
            visited.Add(start);

            String min="";
            String node = start;
            int _min = int.MaxValue;

            while (_min == int.MaxValue) {
                foreach(String item in graph.getNeighborhoods(node))
                {
                    if(!visited.Contains(item))
                    {
                        if (item == goal)
                        {
                            visited.Add(goal);
                            return visited;
                        }

                        if (getdistanceToNaples(item) < _min) { 
                            min = item;
                            _min = getdistanceToNaples(item);
                            visited.Add(item);
                        }
                    }
                }
                
                if (_min == int.MaxValue)
                    return null;

                TreeNode<String> tmp = new TreeNode<String>(min);
                tmp.Parent = tree;
                node = min;
                _min = int.MaxValue;
            }
            return null;
        }

        /*
            A*
            It expands the node with the min heuristic value
            Heuristic value = distance as crow flies state-goal + cost of the path from the start to the node
        */
        static public List<String> searchPath_AStar(Graph<String> graph)
        {
            List<TreeNode<String>> fringe = new List<TreeNode<string>>();
            TreeNode<String> tree = new TreeNode<String>(start);

            foreach (String item in graph.getNeighborhoods(start))
            {
                TreeNode<String> tmp = new TreeNode<String>(item);
                tmp.Parent = tree;
                tmp.cost = findCost(start, item)+getdistanceToNaples(item);
                fringe.Add(tmp);
            }

            while (fringe.Count != 0)
            {
                int min_cost = 0;
                foreach (TreeNode<String> item in fringe)
                {
                    if ((item.cost)+getdistanceToNaples(item.value) < fringe.ElementAt(min_cost).cost+getdistanceToNaples(fringe.ElementAt(min_cost).value))
                        min_cost = fringe.IndexOf(item);
                }

                TreeNode<String> node = fringe.ElementAt(min_cost);
                fringe.RemoveAt(min_cost);

                if (node.value.Equals(goal))
                    return buildPath(node);

                foreach (String item in graph.getNeighborhoods(node.value))
                {
                    //delete loop
                    bool isInThePathToRoot = false;
                    TreeNode<String> tmp = node;
                    while (tmp != null && !isInThePathToRoot)
                    {
                        if (tmp.value.Equals(item))
                            isInThePathToRoot = true;
                        tmp = tmp.Parent;
                    }

                    if (!isInThePathToRoot)
                    {
                        TreeNode<String> _tmp = new TreeNode<String>(item);
                        _tmp.Parent = node;
                        _tmp.cost = findCost(node.value, item) + _tmp.Parent.cost;
                        fringe.Add(_tmp);
                    }

                }
            }

            return null;
        }


        /*
            return the path from start to goal expressed as list of string - name of city
        */
        static List<String> buildPath(TreeNode<String> goal)
        {
            List<String> tmp = new List<string>();
            TreeNode<String> node = goal;
            while (node != null) {
                tmp.Add(node.value);
                node = node.Parent;
            }

            tmp.Reverse();
            return tmp;
        }

        /*
            return the cost of a path
        */
        public static int getCost(List<String> path)
        {
            int cost = 0;
            String[] array = path.ToArray();

            for (int i = 0; i < path.Count-1; i++)
                cost += (distancecityToCity.Find(p =>
                (p.Item1.Equals(array[i]) && p.Item2.Equals(array[i + 1]))
                || (p.Item2.Equals(array[i]) && p.Item1.Equals(array[i + 1]))))
                .Item3;


            return cost;
        }

        /*
            return the cost from a city to other one
        */
        public static int findCost(string from, string to)
        {
            return (distancecityToCity.Find(p =>
                (p.Item1.Equals(from) && p.Item2.Equals(to))
                || (p.Item2.Equals(from) && p.Item1.Equals(to))))
                .Item3;
        }

        /*
            return the cost from a city to Naples
        */
        public static int getdistanceToNaples(string from)
        {
            return (distanceTNaples.Find(p => p.Item1.Equals(from))).Item2;
        }

        public static int getDepth(TreeNode<String> node)
        {
            TreeNode<String> tmp = node;
            int x = 0;
            while (node != null)
            {
                node = node.Parent;
                x = x + 1;
            }

            return x;
        }
    }
}
