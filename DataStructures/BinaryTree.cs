using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures
{
    public class BinaryTree<T>
    {
        public Node<T> Root { get; }

        public BinaryTree<T>? Left { get; set; }

        public BinaryTree<T>? Right { get; set; }

        public BinaryTree(T rootValue)
        {
            Root = new Node<T>(rootValue);
        }

        /// <summary>
        /// Root, left, right
        /// </summary>
        public IEnumerable<Node<T>> PreOrderTraversal()
        {
            var (leftTraversal, rightTraversal) = TraverseLeftRight(t => t?.PreOrderTraversal());

            return leftTraversal
                .Prepend(Root)
                .Concat(rightTraversal);
        }

        /// <summary>
        /// Left, root, right
        /// </summary>
        public IEnumerable<Node<T>> InOrderTraversal()
        {
            var (leftTraversal, rightTraversal) = TraverseLeftRight(t => t?.InOrderTraversal());

            return leftTraversal
                .Append(Root)
                .Concat(rightTraversal);
        }

        /// <summary>
        /// Left, right, root
        /// </summary>
        public IEnumerable<Node<T>> PostOrderTraversal()
        {
            var (leftTraversal, rightTraversal) = TraverseLeftRight(t => t?.PostOrderTraversal());

            return leftTraversal
                .Concat(rightTraversal)
                .Append(Root);
        }

        /// <summary>
        /// Apply a traversal function across left and right subtrees.
        /// </summary>
        private (IEnumerable<Node<T>> left, IEnumerable<Node<T>> right) TraverseLeftRight(
            Func<BinaryTree<T>?, IEnumerable<Node<T>>?> traverse)
        {
            var leftTraversal = traverse(Left).EmptyIfNull();
            var rightTraversal = traverse(Right).EmptyIfNull();

            return (leftTraversal, rightTraversal);
        }
    }
}
