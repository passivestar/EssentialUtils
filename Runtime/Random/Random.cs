using System.Linq;
using System.Collections.Generic;

namespace EssentialUtils
{
    public static class Random
    {
        readonly static System.Random random = new();

        public static bool Bool(float bias = .5f)
        {
            return UnityEngine.Random.value < bias;
        }

        public class ListRandom<T>
        {
            List<T> sourceList;
            List<T> list = new();

            readonly System.Random random = new();

            public ListRandom(List<T> list)
            {
                sourceList = list;
            }

            public T Next()
            {
                if (list.Count == 0)
                {
                    list = sourceList.ToList();
                }

                var index = random.Next(0, list.Count);
                var item = list[index];
                list.RemoveAt(index);
                return item;
            }
        }
    }
}