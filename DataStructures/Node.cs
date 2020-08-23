using System.Collections.Generic;

namespace DataStructures
{
    public class Node<T>
    {
        public T Value { get; }

        public Node(T value)
        {
            Value = value;
        }

        public override bool Equals(object? obj) =>
            obj is Node<T> comparisonNode
            && EqualityComparer<T>.Default.Equals(comparisonNode.Value, Value);

        public override int GetHashCode()
        {
            return System.HashCode.Combine(Value);
        }
    }
}