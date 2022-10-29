using UnityEngine;

namespace EssentialUtils
{
    public class ValueAnimatorVector3 : ValueAnimator
    {
        public Vector3 valueStart;
        public Vector3 valueEnd;

        public Vector3 Value { get; private set; }

        protected override void AssignOutputValue()
        {
            var t = GetInterpolationFactor();
            Value = Vector3.LerpUnclamped(valueStart, valueEnd, t);
        }
    }
}