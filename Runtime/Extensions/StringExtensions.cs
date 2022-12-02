using UnityEngine;

namespace EssentialUtils
{
    public static class StringExtensions
    {
        public static string SnakeToCamel(this string str)
        {
            var words = str.Split('_');
            var camel = words[0];
            for (var i = 1; i < words.Length; ++i)
            {
                camel += words[i].Substring(0, 1).ToUpper() + words[i].Substring(1);
            }
            return camel;
        }

        public static string CamelToSnake(this string str)
        {
            var snake = "";
            for (var i = 0; i < str.Length; ++i)
            {
                if (i > 0 && char.IsUpper(str[i]))
                {
                    snake += "_";
                }
                snake += char.ToLower(str[i]);
            }
            return snake;
        }
    }
}