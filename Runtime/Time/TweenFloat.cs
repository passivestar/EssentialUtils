using System;
using UnityEngine;

namespace EssentialUtils
{
    public class TweenFloat : Tween
    {
        public float ValueStart { get; set; }
        public float ValueEnd { get; set; }

        public float Value { get; private set; }

        public TweenFloat(float duration = 1f, bool loop = false, bool unscaledTime = false,
            AnimationCurve curve = null, AnimationCurve reverseCurve = null,
            Action onStarted = null, Action onStartedInReverse = null, Action onFinished = null,
            Action onFinishedInReverse = null, Action onUpdate = null,
            float? valueStart = null, float? valueEnd = null) : base(
                duration, loop, unscaledTime, curve, reverseCurve,
                onStarted, onStartedInReverse, onFinished,
                onFinishedInReverse, onUpdate
            )
            {
                ValueStart = valueStart ?? 0f;
                ValueEnd = valueEnd ?? 1f;
            }

        protected override void AssignOutputValue()
        {
            var t = GetInterpolationFactor();
            Value = Mathf.LerpUnclamped(ValueStart, ValueEnd, t);
        }
    }
}