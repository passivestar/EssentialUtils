using System;
using UnityEngine;

namespace EssentialUtils
{
    public class TweenVector4 : Tween
    {
        public Vector4 ValueStart { get; set; }
        public Vector4 ValueEnd { get; set; }

        public Vector4 Value { get; private set; }

        public TweenVector4(float duration = 1f, bool loop = false, bool unscaledTime = false,
            AnimationCurve curve = null, AnimationCurve reverseCurve = null,
            Action onStarted = null, Action onStartedInReverse = null, Action onFinished = null,
            Action onFinishedInReverse = null, Action onUpdate = null,
            Vector4? valueStart = null, Vector4? valueEnd = null) : base(
                duration, loop, unscaledTime, curve, reverseCurve,
                onStarted, onStartedInReverse, onFinished,
                onFinishedInReverse, onUpdate
            )
            {
                ValueStart = valueStart ?? new Vector4(0, 0, 0, 0);
                ValueEnd = valueEnd ?? new Vector4(1f, 1f, 1f, 1f);
            }

        protected override void AssignOutputValue()
        {
            var t = GetInterpolationFactor();
            Value = Vector4.LerpUnclamped(ValueStart, ValueEnd, t);
        }
    }
}