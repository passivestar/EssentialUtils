using UnityEngine;

namespace EssentialUtils
{
    public static class StringExtensions
    {
        public static string SnakeToCamel(this string str)
        {
            return string.Concat(str.Split('_').Select(word => word.Substring(0, 1).ToUpper() + word.Substring(1)));
        }

        public static string CamelToSnake(this string str)
        {
            return string.Concat(str.Select((c, i) => i > 0 && char.IsUpper(c) ? "_" + c : c.ToString())).ToLower();
        }

        public static string PathStart(this string path)
        {
            return path[0..(path.LastIndexOf('.') + 1)];
        }

        public static string PathEnd(this string path)
        {
            return path[(path.LastIndexOf('.') + 1)..];
        }
    }
}