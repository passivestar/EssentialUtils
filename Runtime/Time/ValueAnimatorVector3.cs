using UnityEngine;

namespace EssentialUtils
{
    public class ValueAnimatorVector3 : ValueAnimator
    {
        public Vector3 ValueStart { get; set; }
        public Vector3 ValueEnd { get; set; }

        public Vector3 Value { get; private set; }

        protected override void AssignOutputValue()
        {
            var t = GetInterpolationFactor();
            Value = Vector3.LerpUnclamped(ValueStart, ValueEnd, t);
        }
    }
}