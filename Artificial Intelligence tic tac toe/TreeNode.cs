using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Artificial_Intelligence_tic_tac_toe
{
    public class TreeNode
    {
        public List<TreeNode> children = new List<TreeNode>();
        public TreeNode Parent;
        public int eval; //1 victory max, -1 victory min
        public int player; //1 max, -1 min
        public int[,] matrix = new int[3, 3];
        public String step;
        public int branching_f;
        public bool visited=false;
        public TreeNode(int[,] matrix)
        {
            this.Parent = null;
            this.matrix = matrix;

        }

        public TreeNode AddChild(TreeNode value)
        {
            value.Parent = this;
            children.Add(value);
            return value;
        }

        public List<TreeNode> getFrontier()
        {
            if (this.children.Count == 0)
            {
                List<TreeNode> _ls = new List<TreeNode>();
                _ls.Add(this);
                return _ls;
            }


            List<TreeNode> ls = new List<TreeNode>();
            foreach (TreeNode node in children)
            {
                List<TreeNode> ls_children = node.getFrontier();
                foreach (TreeNode _node in ls_children)
                    ls.Add(_node);
            }

            return ls;
        }

        public void setMatrix(int[,] matrix)
        {
            this.matrix = matrix;
        }

        public (String, int) getMinFromChildren()
        {
            String step = "";
            int min = int.MaxValue;
            foreach (TreeNode tree in this.children)
            {
                if (tree.eval < min) {
                    min = tree.eval;
                    step = tree.step;
                }
            }

            return (step, min); 
        }

        public (String, int) getMaxFromChildren()
        {
            String step="";
            int max = int.MinValue;
            foreach (TreeNode tree in this.children)
            {
                if (tree.eval > max) { 
                    max = tree.eval;
                    step = tree.step;
                }
            }
            return (step,max);
        }

        internal int evaluate()
        {
            int i = 0;
            int j = 0;

            //horizontal tris
            for (; i < 3; i++)
                    if (matrix[i, j] == matrix[i, j + 1] && matrix[i, j] == matrix[i, j + 2])
                        return matrix[i, j];

            //vertical tris
            i = 0;
            for (j=0; j < 3; j++)
                if (matrix[i, j] == matrix[i+1, j] && matrix[i, j] == matrix[i+2, j])
                    return matrix[i, j];

            //diagonal tris Left->
            if (matrix[0, 0] == matrix[1, 1] && matrix[0, 0] == matrix[2, 2])
                return matrix[1, 1];
            //diagonal tris Right->
            if (matrix[0, 2] == matrix[1, 1] && matrix[0, 2] == matrix[2, 0])
                return matrix[1, 1];

            //no winner
            return 0;
        }
    }


}
