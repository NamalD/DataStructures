using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.Tests
{
    public class Tests
    {
        [Test]
        public void PreOrderTraversal()
        {
            var tree = new BinaryTree<int>(1)
            {
                Left = new BinaryTree<int>(2)
                {
                    Left = new BinaryTree<int>(3)
                },
                Right = new BinaryTree<int>(4)
                {
                    Left = new BinaryTree<int>(5),
                    Right = new BinaryTree<int>(6)
                }
            };

            var expected = OrderedNodes(6);

            tree.PreOrderTraversal().Should().ContainInOrder(expected);
        }


        [Test]
        public void InOrderTraversal()
        {
            var tree = new BinaryTree<int>(4)
            {
                Left = new BinaryTree<int>(2)
                {
                    Left = new BinaryTree<int>(1),
                    Right = new BinaryTree<int>(3)
                },
                Right = new BinaryTree<int>(5)
                {
                    Right = new BinaryTree<int>(7)
                    {
                        Left = new BinaryTree<int>(6)
                    }
                }
            };

            var expected = OrderedNodes(7);

            tree.InOrderTraversal().Should().ContainInOrder(expected);
        }

        [Test]
        public void PostOrderTraversal()
        {
            var tree = new BinaryTree<int>(8)
            {
                Left = new BinaryTree<int>(3)
                {
                    Left = new BinaryTree<int>(1),
                    Right = new BinaryTree<int>(2)
                },
                Right = new BinaryTree<int>(7)
                {
                    Right = new BinaryTree<int>(6)
                    {
                        Right = new BinaryTree<int>(5)
                        {
                            Left = new BinaryTree<int>(4)
                        }
                    }
                }
            };

            var expected = OrderedNodes(8);

            tree.PostOrderTraversal().Should().ContainInOrder(expected);
        }

        private static IEnumerable<Node<int>> OrderedNodes(int count)
        {
            return Enumerable.Range(1, count).Select(i => new Node<int>(i));
        }
    }
}