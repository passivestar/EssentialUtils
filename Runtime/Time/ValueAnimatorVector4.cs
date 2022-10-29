using UnityEngine;

namespace EssentialUtils
{
    public class ValueAnimatorVector4 : ValueAnimator
    {
        public Vector4 valueStart;
        public Vector4 valueEnd;

        public Vector4 Value { get; private set; }

        protected override void AssignOutputValue()
        {
            var t = GetInterpolationFactor();
            Value = Vector4.LerpUnclamped(valueStart, valueEnd, t);
        }
    }
}