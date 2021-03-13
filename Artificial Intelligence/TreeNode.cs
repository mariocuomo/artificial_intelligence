using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Artificial_Intelligence
{
        public class TreeNode<T>
        {
            public T value;
            private List<TreeNode<T>> children = new List<TreeNode<T>>();
            public TreeNode<T> Parent;

        public TreeNode()
        {
            
        }
        public TreeNode(T value){
                this.value = value;
                this.Parent = null;
            }

            public TreeNode<T> AddChild(T value){
                var node = new TreeNode<T>(value);
                node.Parent = this;
                children.Add(node);
                return node;
            }

            public TreeNode<T> AddChild(TreeNode<T> value)
            {
                value.Parent = this;
                children.Add(value);
                return value;
            }

        public List<TreeNode<T>> getFrontier(){
                if (this.children.Count == 0)
                {
                    List<TreeNode<T>> _ls = new List<TreeNode<T>>();
                    _ls.Add(this);
                    return _ls;
                }
                    

                List<TreeNode<T>> ls = new List<TreeNode<T>>();
                foreach (TreeNode<T> node in children){
                    List<TreeNode<T>> ls_children = node.getFrontier();
                    foreach (TreeNode<T> _node in ls_children)
                        ls.Add(_node);
                }

                return ls;
            }

    }
}
