using System;
using UnityEngine;

namespace EssentialUtils
{
    public class TweenVector3 : Tween
    {
        public Vector3 ValueStart { get; set; }
        public Vector3 ValueEnd { get; set; }

        public Vector3 Value { get; private set; }

        public TweenVector3(float duration = 1f, bool loop = false, bool unscaledTime = false,
            AnimationCurve curve = null, AnimationCurve reverseCurve = null,
            Action onStarted = null, Action onStartedInReverse = null, Action onFinished = null,
            Action onFinishedInReverse = null, Action onUpdate = null,
            Vector3? valueStart = null, Vector3? valueEnd = null) : base(
                duration, loop, unscaledTime, curve, reverseCurve,
                onStarted, onStartedInReverse, onFinished,
                onFinishedInReverse, onUpdate
            )
            {
                ValueStart = valueStart ?? new Vector3(0, 0, 0);
                ValueEnd = valueEnd ?? new Vector3(1f, 1f, 1f);
            }

        protected override void AssignOutputValue()
        {
            var t = GetInterpolationFactor();
            Value = Vector3.LerpUnclamped(ValueStart, ValueEnd, t);
        }
    }
}