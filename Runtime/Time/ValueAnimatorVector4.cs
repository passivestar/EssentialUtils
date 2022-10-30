using UnityEngine;

namespace EssentialUtils
{
    public class ValueAnimatorVector4 : ValueAnimator
    {
        public Vector4 ValueStart { get; set; }
        public Vector4 ValueEnd { get; set; }

        public Vector4 Value { get; private set; }

        protected override void AssignOutputValue()
        {
            var t = GetInterpolationFactor();
            Value = Vector4.LerpUnclamped(ValueStart, ValueEnd, t);
        }
    }
}