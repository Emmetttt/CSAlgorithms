using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsAndDataStructures
{
    public class Node
    {
        public int? Value { get; set; }
        public Node LeftNode { get; set; }
        public Node RightNode { get; set; }
    }
    public class AVLNode
    {
        public int? Value { get; set; }
        private AVLNode _leftnode;
        public AVLNode LeftNode
        {
            get
            {
                return _leftnode;
            }
            internal set
            {
                _leftnode = value;
                if (_leftnode != null)
                {
                    _leftnode.Parent = this;
                }
            }
        }
        private AVLNode _rightnode;
        public AVLNode RightNode
        {
            get
            {
                return _rightnode;
            }
            internal set
            {
                _rightnode = value;
                if (_rightnode != null)
                {
                    _rightnode.Parent = this;
                }
            }
        }
        public AVLNode Parent { get; internal set; }
        private int _leftHeight
        {
            get
            {
                return MaxChildHeight(LeftNode);
            }
        }
        private int _rightHeight
        {
            get
            {
                return MaxChildHeight(RightNode);
            }
        }
        private int MaxChildHeight(AVLNode node)
        {
            if (node != null)
            {
                return 1 + Math.Max(MaxChildHeight(node.LeftNode), MaxChildHeight(node.RightNode));
            }

            return 0;
        }
        internal int BalanceFactor
        {
            get
            {
                return _rightHeight - _leftHeight;
            }
        }
        internal string State
        {
            get
            {
                if (BalanceFactor > 1)
                {
                    return "LeftHeavy";
                }
                if (BalanceFactor < -1)
                {
                    return "RightHeavy";
                }
                else
                {
                    return "Balanced";
                }
            }
        }
    }
}
