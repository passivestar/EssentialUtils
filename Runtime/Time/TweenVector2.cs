using System;
using UnityEngine;

namespace EssentialUtils
{
    public class TweenVector2 : Tween
    {
        public Vector2 ValueStart { get; set; }
        public Vector2 ValueEnd { get; set; }

        public Vector2 Value { get; private set; }

        public TweenVector2(float duration = 1f, bool loop = false, bool unscaledTime = false,
            AnimationCurve curve = null, AnimationCurve reverseCurve = null,
            Action onStarted = null, Action onStartedInReverse = null, Action onFinished = null,
            Action onFinishedInReverse = null, Action onUpdate = null) : base(
                duration, loop, unscaledTime, curve, reverseCurve,
                onStarted, onStartedInReverse, onFinished,
                onFinishedInReverse, onUpdate
            ) { }

        protected override void AssignOutputValue()
        {
            var t = GetInterpolationFactor();
            Value = Vector2.LerpUnclamped(ValueStart, ValueStart, t);
        }
    }
}