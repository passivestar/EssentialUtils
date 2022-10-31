using System;
using UnityEngine;

namespace EssentialUtils
{
    public class ValueAnimatorFloat : ValueAnimator
    {
        public float ValueStart { get; set; } = 0f;
        public float ValueEnd { get; set; } = 1f;

        public float Value { get; private set; }

        public ValueAnimatorFloat(float duration = 1f, bool loop = false, bool unscaledTime = false,
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
            Value = Mathf.LerpUnclamped(ValueStart, ValueEnd, t);
        }
    }
}