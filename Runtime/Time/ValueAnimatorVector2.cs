using UnityEngine;

namespace EssentialUtils
{
    public class ValueAnimatorVector2 : ValueAnimator
    {
        public Vector2 valueStart;
        public Vector2 valueEnd;

        public Vector2 Value { get; private set; }

        protected override void AssignOutputValue()
        {
            var t = GetInterpolationFactor();
            Value = Vector2.LerpUnclamped(valueStart, valueEnd, t);
        }
    }
}