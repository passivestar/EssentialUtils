using UnityEngine;

namespace EssentialUtils
{
    public class ValueAnimatorVector2 : ValueAnimator
    {
        public Vector2 ValueStart { get; set; }
        public Vector2 ValueEnd { get; set; }

        public Vector2 Value { get; private set; }

        protected override void AssignOutputValue()
        {
            var t = GetInterpolationFactor();
            Value = Vector2.LerpUnclamped(ValueStart, ValueStart, t);
        }
    }
}