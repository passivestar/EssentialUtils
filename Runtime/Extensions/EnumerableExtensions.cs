using System;
using System.Collections.Generic;

namespace EssentialUtils
{
    public static class EnumerableExtensions
    {
        public static Tuple<List<T>, List<T>> Partition<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            var listA = new List<T>();
            var listB = new List<T>();
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    listA.Add(item);
                }
                else
                {
                    listB.Add(item);
                }
            }
            return new Tuple<List<T>, List<T>>(listA, listB);
        }
    }
}