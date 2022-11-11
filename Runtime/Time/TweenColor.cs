using System;
using UnityEngine;

namespace EssentialUtils
{
    public class TweenColor : Tween
    {
        public Color ValueStart { get; set; }
        public Color ValueEnd { get; set; }

        public Color Value { get; private set; }

        public TweenColor(float duration = 1f, bool loop = false, bool unscaledTime = false,
            AnimationCurve curve = null, AnimationCurve reverseCurve = null,
            Action onStarted = null, Action onStartedInReverse = null, Action onFinished = null,
            Action onFinishedInReverse = null, Action onUpdate = null,
            Color? valueStart = null, Color? valueEnd = null) : base(
                duration, loop, unscaledTime, curve, reverseCurve,
                onStarted, onStartedInReverse, onFinished,
                onFinishedInReverse, onUpdate
            )
            {
                ValueStart = valueStart ?? new Color(0, 0, 0);
                ValueEnd = valueEnd ?? new Color(1f, 1f, 1f);
            }

        protected override void AssignOutputValue()
        {
            var t = GetInterpolationFactor();
            Value = Color.LerpUnclamped(ValueStart, ValueEnd, t);
        }
    }
}