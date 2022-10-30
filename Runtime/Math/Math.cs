using UnityEngine;

namespace EssentialUtils
{
    public class Math
    {
        public static float MapRange(float value, float valueMin, float valueMax, float min, float max)
        {
           var t = Mathf.InverseLerp(valueMin, valueMax, value);
            var val = Mathf.Lerp(min, max, t);
            return min <= max ? Mathf.Clamp(val, min, max) : Mathf.Clamp(val, max, min);
        }

        public static float MapRange(float value, float valueMin, float valueMax, float min, float max, AnimationCurve curve = null)
        {
            var t = Mathf.InverseLerp(valueMin, valueMax, value);
            if (curve != null)
            {
                t = curve.Evaluate(t);
            }
            var val = Mathf.Lerp(min, max, t);
            return min <= max ? Mathf.Clamp(val, min, max) : Mathf.Clamp(val, max, min);
        }

        public static Quaternion SnapRotationToNearestRightAngle(Quaternion rotation)
        {
            Vector3 closestToForward = SnapVectorToNearestAxis(rotation * Vector3.forward);
            Vector3 closestToUp = SnapVectorToNearestAxis(rotation * Vector3.up);
            return Quaternion.LookRotation(closestToForward, closestToUp);
        }

        public static Vector3 SnapVectorToNearestAxis(Vector3 direction)
        {
            var x = Mathf.Abs(direction.x);
            var y = Mathf.Abs(direction.y);
            var z = Mathf.Abs(direction.z);
            if (x > y && x > z)
            {
                return new Vector3(Mathf.Sign(direction.x), 0, 0);
            }
            else if (y > x && y > z)
            {
                return new Vector3(0, Mathf.Sign(direction.y), 0);
            }
            else
            {
                return new Vector3(0, 0, Mathf.Sign(direction.z));
            }
        }

        public static Vector3 ExtractEulersFromQuaternion(Quaternion q)
        {
            var eulers = q.eulerAngles;
            for (var i = 0; i < 3; ++i)
            {
                var angle = Mathf.Repeat(eulers[i], 360f);
                eulers[i] = angle > 180f ? angle - 360f : angle;
            }
            return eulers;
        }

        public static int Mod(int x, int m)
        {
            return (x % m + m) % m;
        }

        public static float Follow(float current, float target, ref float acceleration, ref float velocity,
            float accelerationMultiplier, float damping, AnimationCurve curve, float delta)
        {
            var diff = target - current;
            if (curve != null)
            {
                diff = curve.Evaluate(diff);
            }
            acceleration = diff * accelerationMultiplier;
            velocity += acceleration * delta;
            velocity = Mathf.Lerp(velocity, 0, damping * delta);
            return current + velocity * delta;
        }
    }
}