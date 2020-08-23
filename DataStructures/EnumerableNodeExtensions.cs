using System.Collections.Generic;

namespace DataStructures
{
    public static class EnumerableNodeExtensions
    {
        public static IEnumerable<Node<T>> EmptyIfNull<T>(this IEnumerable<Node<T>>? nodes) =>
            nodes ?? new List<Node<T>>();
    }
}
