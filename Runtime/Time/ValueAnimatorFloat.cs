using UnityEngine;

namespace EssentialUtils
{
    public class ValueAnimatorFloat : ValueAnimator
    {
        public float ValueStart { get; set; }
        public float ValueEnd { get; set; }

        public float Value { get; private set; }

        protected override void AssignOutputValue()
        {
            var t = GetInterpolationFactor();
            Value = Mathf.LerpUnclamped(ValueStart, ValueEnd, t);
        }
    }
}