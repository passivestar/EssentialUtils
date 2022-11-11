using UnityEngine;

namespace EssentialUtils
{
    public static class QuaternionExtensions
    {
        public static Vector3 ExtractEulers(this Quaternion q)
        {
            var eulers = q.eulerAngles;
            for (var i = 0; i < 3; ++i)
            {
                var angle = Mathf.Repeat(eulers[i], 360f);
                eulers[i] = angle > 180f ? angle - 360f : angle;
            }
            return eulers;
        }

        public static Quaternion SnapToNearestRightAngle(this Quaternion rotation)
        {
            var closestToForward = (rotation * Vector3.forward).SnapToNearestAxis();
            var closestToUp = (rotation * Vector3.up).SnapToNearestAxis();
            return Quaternion.LookRotation(closestToForward, closestToUp);
        }
    }
}