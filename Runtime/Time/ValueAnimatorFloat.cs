using UnityEngine;

namespace EssentialUtils
{
    public class ValueAnimatorFloat : ValueAnimator
    {
        public float valueStart;
        public float valueEnd;

        public float Value { get; private set; }

        protected override void AssignOutputValue()
        {
            var t = GetInterpolationFactor();
            Value = Mathf.LerpUnclamped(valueStart, valueEnd, t);
        }
    }
}