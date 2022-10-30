using UnityEngine;

namespace EssentialUtils
{
    public class ValueAnimatorQuaternion : ValueAnimator
    {
        public Quaternion ValueStart { get; set; }
        public Quaternion ValueEnd { get; set; }

        public Quaternion Value { get; private set; }

        protected override void AssignOutputValue()
        {
            var t = GetInterpolationFactor();
            Value = Quaternion.LerpUnclamped(ValueStart, ValueEnd, t);
        }
    }
}