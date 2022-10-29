using UnityEngine;

namespace EssentialUtils
{
    public class ValueAnimatorQuaternion : ValueAnimator
    {
        public Quaternion valueStart;
        public Quaternion valueEnd;

        public Quaternion Value { get; private set; }

        protected override void AssignOutputValue()
        {
            var t = GetInterpolationFactor();
            Value = Quaternion.LerpUnclamped(valueStart, valueEnd, t);
        }
    }
}