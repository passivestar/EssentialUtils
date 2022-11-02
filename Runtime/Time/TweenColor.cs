using System;
using UnityEngine;

namespace EssentialUtils
{
    public class TweenColor : Tween
    {
        public Color ValueStart { get; set; } = Color.black;
        public Color ValueEnd { get; set; } = Color.white;

        public Color Value { get; private set; }

        public TweenColor(float duration = 1f, bool loop = false, bool unscaledTime = false,
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
            Value = Color.LerpUnclamped(ValueStart, ValueEnd, t);
        }
    }
}