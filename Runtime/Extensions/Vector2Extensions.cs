using UnityEngine;

namespace EssentialUtils
{
    public static class Vector2Extensions
    {
        public static Vector3 ToVector3XZ (this Vector2 vector)
        {
            return new(vector.x, 0, vector.y);
        }

        public static Vector3 ToVector3XY (this Vector2 vector)
        {
            return new(vector.x, vector.y, 0);
        }

        public static Vector3 ToVector3YZ(this Vector2 vector)
        {
            return new(0, vector.x, vector.y);
        }
    }
}