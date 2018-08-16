using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsAndDataStructures
{
    public class BinaryTree
    {
        /*                X           - Root node
                        / | \___________
                       /  |             \
                      X   X -terminal    X  -Leaf
          Exactly one path from root to any node
         */
        
        Node _head = new Node { Value = null };
        int _count = 0;
        public bool Contains(int data)
        {
            return Contains(data, _head);
        }
        public bool Contains(int data, Node node)
        {
            if (node.Value == data)
            {
                return true;
            }
            else if (data < node.Value && node.LeftNode == null)
            {
                return false;
            }
            else if (data < node.Value && node.LeftNode != null)
            {
                return Contains(data, node.LeftNode);
            }
            else if (data >= node.Value && node.RightNode == null)
            {
                return false;
            }
            else 
            {
                return Contains(data, node.RightNode);
            }
        }

        public void Add(int data)
        {
            if (_head.Value == null)
            {
                _head.Value = data;
            }
            else
            {
                Insert(data, _head);
            }
            _count++;
        }
        public void Insert(int data, Node currNode)
        {
            if (data >= currNode.Value && currNode.RightNode != null)
            {
                Insert(data, currNode.RightNode);
            }
            else if (data >= currNode.Value)
            {
                Node insertNode = new Node { Value = data };
                currNode.RightNode = insertNode;
            }
            else if (data < currNode.Value && currNode.LeftNode != null)
            {
                Insert(data, currNode.LeftNode);
            }
            else if (data < currNode.Value)
            {
                Node insertNode = new Node { Value = data };
                currNode.LeftNode = insertNode;
            }
        }
        public void Remove(int data)
        {
            /* if the node does not exist, exit
               if the node exists and is a terminal (leaf node)
                    set the parents pointer to null
               if the node is a non-leaf node
                    find the child to replace the deleted node
                        if no right child
                            promote left child
                        if has a right child with no left child
                            promote right child
                            point parent to right child
                            point right child to old left child
                        if has a right child with a left child
                            promote the left-most child
            */
            if (_head.Value == data)
            {
                _head.Value = null;
                _head.RightNode = null;
                _head.LeftNode = null;
            }
            else if (data < _head.Value)
            {
                Remove(data, _head.LeftNode, _head);
            }
            else
            {
                Remove(data, _head.RightNode, _head);
            }
            _count--;
        }
        public void Remove(int data, Node node, Node parent)
        {
            if (data > node.Value && node.RightNode != null)
            {
                Remove(data, node.RightNode, node);
            }
            if (data < node.Value && node.LeftNode != null)
            {
                Remove(data, node.LeftNode, node);
            }
            if (data == node.Value)
            {
                //case 1
                if (node.LeftNode == null && node.RightNode == null)
                {
                    // set the parent to null
                    if (parent.LeftNode.Value == data)
                    {
                        parent.LeftNode = null;
                    }
                    else
                    {
                        parent.RightNode = null;
                    }
                }
                else if (node.RightNode == null)
                {
                    // promote left node
                    parent.LeftNode = node.LeftNode;
                }
                else if (node.RightNode.LeftNode == null)
                {
                    // repoint parent to node.rightnode
                    parent.RightNode = node.RightNode;
                    node.RightNode.LeftNode = node.LeftNode;
                }
                else if (node.RightNode.LeftNode != null)
                {
                    // set leftmost node
                    Node leftmostParent = Leftmost(node.RightNode);
                    node.Value = leftmostParent.LeftNode.Value;
                    leftmostParent.LeftNode = null;
                }
            }
        }
        public Node Leftmost(Node parent)
        {
            // Returns the parent of the leftmost node
            if (parent.LeftNode != null)
            {
                if (parent.LeftNode.LeftNode == null)
                {
                    return parent;
                }
                else
                {
                    return Leftmost(parent.LeftNode);
                }
            }
            else
            {
                throw new InvalidProgramException("No left node.");
            }
        }
        public string Print()
        {
            string print = "";
            if (_head.LeftNode != null)
            {
                print = Print(_head.LeftNode, print);
            }
            print += _head.Value.ToString();
            if (_head.RightNode != null)
            {
                print = Print(_head.RightNode, print);
            }
            return print;
        }
        public string Print(Node tree, string printString)
        {
            if (tree.LeftNode != null)
            {
                printString = Print(tree.LeftNode, printString);
            }
            printString += tree.Value.ToString();
            if (tree.RightNode != null)
            {
                printString = Print(tree.RightNode, printString);
            }

            return printString;
        }

        public string PrintWhile()
        {
            string output = "";

            System.Collections.Generic.Stack<Node> stack = new System.Collections.Generic.Stack<Node>();
            Node current = _head;
            Node popped = new Node();

            bool goLeftNext = true;
            stack.Push(current);

            while (stack.Count > 0)
            {
                if (goLeftNext)
                {
                    while (current.LeftNode != null)
                    {
                        stack.Push(current);
                        current = current.LeftNode;
                    }
                }

                output += current.Value;

                if (current.RightNode != null)
                {
                    current = current.RightNode;
                    goLeftNext = true;
                }
                else
                {
                    popped = stack.Pop();
                    current = popped;
                    goLeftNext = false;
                }
            }


            return output;
        }
    }
}
