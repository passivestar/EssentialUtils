using System;
using UnityEngine;

namespace EssentialUtils
{
    public class TweenQuaternion :Tween
    {
        public Quaternion ValueStart { get; set; }
        public Quaternion ValueEnd { get; set; }

        public Quaternion Value { get; private set; }

        public TweenQuaternion(float duration = 1f, bool loop = false, bool unscaledTime = false,
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
            Value = Quaternion.LerpUnclamped(ValueStart, ValueEnd, t);
        }
    }
}