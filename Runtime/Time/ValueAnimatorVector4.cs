using System;
using UnityEngine;

namespace EssentialUtils
{
    public class ValueAnimatorVector4 : ValueAnimator
    {
        public Vector4 ValueStart { get; set; }
        public Vector4 ValueEnd { get; set; }

        public Vector4 Value { get; private set; }

        public ValueAnimatorVector4(float duration = 1f, bool loop = false, bool unscaledTime = false,
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
            Value = Vector4.LerpUnclamped(ValueStart, ValueEnd, t);
        }
    }
}