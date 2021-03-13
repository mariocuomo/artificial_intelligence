using System;
using System.Collections.Generic;
using System.Text;

namespace Artificial_Intelligence
{
    static class Service
    {
        static public List<(String, String, int)> ListGraph()
        {
            List<(String, String, int)> tmp = new List<(String, String, int)>
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

            return tmp;
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

            while (fringe.Count != 0)
            {
                TreeNode<String> node = fringe.Pop();
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
                        fringe.Push(_tmp);
                    }

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

        
    }
}
