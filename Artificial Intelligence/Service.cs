﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artificial_Intelligence
{
    static class Service
    {
        static List<(String, String, int)> distancecityToCity = new List<(String, String, int)>
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
        
        static List<(String, int)> distanceTNaples = new List<(String, int)>
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



        static public List<(String, String, int)> ListGraph()
        {
            return distancecityToCity;
        }

        static public List<String> searchPath_BFS(Graph<String> graph)
        {
            //Start from Milan to Naples
            String start = "Milano";
            String goal = "Napoli";

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

        static public List<String> searchPath_DFS(Graph<String> graph)
        {
            //Start from Milan to Naples
            String start = "Milano";
            String goal = "Napoli";

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
                
                if(node.value.Equals("Napoli"))
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


        static public List<String> searchPath_DFS_Recursive(Graph<String> graph)
        {
            TreeNode<String> tree = new TreeNode<String>("Milano");
            return DFS(graph, "Milano", tree);
        }

        static public List<String> searchPathUCS(Graph<String> graph)
        {
            //Start from Milan to Naples
            String start = "Milano";
            String goal = "Napoli";


            List<TreeNode<String>> fringe = new List<TreeNode<string>>();
            TreeNode<String> tree = new TreeNode<String>(start);

            foreach (String item in graph.getNeighborhoods(start))
            {
                TreeNode<String> tmp = new TreeNode<String>(item);
                tmp.Parent = tree;
                tmp.cost = findCost("Milano", item);
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

        static public List<String> searchPath_Greedy(Graph<String> graph)
        {
            //Start from Milan to Naples
            String start = "Milano";
            String goal = "Napoli";

            TreeNode<String> tree = new TreeNode<String>(start);
            
            List<String> visited = new List<string>();
            visited.Add("Milano");

            String min="";
            String node = start;
            int _min = int.MaxValue;

            while (_min == int.MaxValue) {
                foreach(String item in graph.getNeighborhoods(node))
                {
                    if(!visited.Contains(item))
                    {
                        if (item == "Napoli")
                        {
                            visited.Add("Napoli");
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

        static public List<String> searchPath_AStar(Graph<String> graph)
        {
            //Start from Milan to Naples
            String start = "Milano";
            String goal = "Napoli";


            List<TreeNode<String>> fringe = new List<TreeNode<string>>();
            TreeNode<String> tree = new TreeNode<String>(start);

            foreach (String item in graph.getNeighborhoods(start))
            {
                TreeNode<String> tmp = new TreeNode<String>(item);
                tmp.Parent = tree;
                tmp.cost = findCost("Milano", item)+getdistanceToNaples(item);
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

        static public List<String> DFS(Graph<String> graph, String node, TreeNode<String> tree)
        {
            foreach (String item in graph.getNeighborhoods(node))
            {
                if (item == "Napoli")
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

        /*return the cost of a path*/
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

        /*return the cost from a city to other one*/
        public static int findCost(string from, string to)
        {
            return (distancecityToCity.Find(p =>
                (p.Item1.Equals(from) && p.Item2.Equals(to))
                || (p.Item2.Equals(from) && p.Item1.Equals(to))))
                .Item3;
        }

        /*return the cost from a city to Naples*/
        public static int getdistanceToNaples(string from)
        {
            return (distanceTNaples.Find(p => p.Item1.Equals(from))).Item2;
        }
    }
}
