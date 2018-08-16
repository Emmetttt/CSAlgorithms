using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsAndDataStructures
{
    public class AVLTree
    {
        // Self balancing tree
        // Smaller values on left, equal or larger on right
        // Search and enumeration identicle to binary tree
        // Insertion and deletion differ and balance the tree
        // Unbalanced binary tree can become a linked list, O(n) search performance
        //      example, insert 1, 2, 3, 4 becomes 1 - 2 - 3 - 4
        // Search speed is primary goal O(log n) search performance
        // rules:
        //      Height of left and right must differe by at most 1
        // Balancing:
        //      Done using node rotation
        //      Rotation occurs at the insertion and deletion points
        //      Rotation changes the structure of the tree within constraints of binary tree

        public AVLNode _head = new AVLNode();
        public int _count = 0;
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
        public void Insert(int data, AVLNode currNode)
        {
            if (data >= currNode.Value && currNode.RightNode != null)
            {
                Insert(data, currNode.RightNode);
            }
            else if (data >= currNode.Value)
            {
                AVLNode insertNode = new AVLNode { Value = data };
                currNode.RightNode = insertNode;
                Balance(currNode);
            }
            else if (data < currNode.Value && currNode.LeftNode != null)
            {
                Insert(data, currNode.LeftNode);
            }
            else if (data < currNode.Value)
            {
                AVLNode insertNode = new AVLNode { Value = data };
                currNode.LeftNode = insertNode;
                Balance(currNode);
            }
        }
        public void Delete(int data)
        {
        }
        public void Balance(AVLNode node)
        {
            // If right child is left heavy, Left-Right rotation
            if (node.State.Equals("RightHeavy"))
            {
                if (node.LeftNode.RightNode != null && node.LeftNode.BalanceFactor > 0)
                {
                    LeftRightRotation(node);
                }
                else
                {
                    LeftRotation(node);
                }
            }
            else if (node.State.Equals("LeftHeavy"))
            {
                if (node.LeftNode != null && node.LeftNode.BalanceFactor < 0)
                {
                    RightLeftRotation(node);
                }
                else
                {
                    RightRotation(node);
                }
            }
            if (node.Parent != null)
            {
                Balance(node.Parent);
            }
        }
        private void RightRotation(AVLNode node)
        {
            AVLNode childptr = node.LeftNode;
            node.LeftNode = null;
            childptr.RightNode.Parent = node;
            node.Parent = childptr;
        }
        private void LeftRotation(AVLNode node)
        {
            AVLNode childptr = node.RightNode;
            node.RightNode = null;
            if (childptr.LeftNode != null)
            {
                childptr.LeftNode.Parent = node;
            }
            node.Parent = childptr;
            childptr.LeftNode = node;
            if (childptr.Parent != null)
            {
                childptr.Parent.LeftNode = childptr;
            }
        }
        private void RightLeftRotation(AVLNode node)
        {
            RightRotation(node.RightNode);
            LeftRotation(node);
        }
        private void LeftRightRotation(AVLNode node)
        {
            LeftRotation(node.LeftNode);
            RightRotation(node);
        }
        public bool Contains(int data)
        {
            return Contains(data, _head);
        }
        public bool Contains(int data, AVLNode node)
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
        public string Print(AVLNode tree, string printString)
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

            System.Collections.Generic.Stack<AVLNode> stack = new System.Collections.Generic.Stack<AVLNode>();
            AVLNode current = _head;
            AVLNode popped = new AVLNode();

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
