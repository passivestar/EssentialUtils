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

        public static Vector3 SnapToNearestAxis(this Vector3 direction)
        {
            var x = Mathf.Abs(direction.x);
            var y = Mathf.Abs(direction.y);
            var z = Mathf.Abs(direction.z);
            if (x > y && x > z)
            {
                return new(Mathf.Sign(direction.x), 0, 0);
            }
            else if (y > x && y > z)
            {
                return new(0, Mathf.Sign(direction.y), 0);
            }
            else
            {
                return new(0, 0, Mathf.Sign(direction.z));
            }
        }
    }
}