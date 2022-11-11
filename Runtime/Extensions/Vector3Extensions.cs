using UnityEngine;

namespace EssentialUtils
{
    public static class Vector3Extensions
    {
        public static Vector2 ToVector2XY(this Vector3 vector)
        {
            return new(vector.x, vector.y);
        }

        public static Vector2 ToVector2XZ(this Vector3 vector)
        {
            return new(vector.x, vector.z);
        }

        public static Vector2 ToVector2YZ(this Vector3 vector)
        {
            return new(vector.y, vector.z);
        }

        public static void DrawRay(this Vector3 vector, Vector3 dir, Color color = new(), float duration = 1f)
        {
            Debug.DrawRay(vector, dir, color, duration);
        }
    }
}