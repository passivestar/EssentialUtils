using System;
using UnityEngine;

namespace EssentialUtils
{
    public abstract class ValueAnimator : IDisposable
    {
        public Action ActionPlay { get; private set; }
        public Action ActionPlayFromStart { get; private set; }
        public Action ActionReverse{ get; private set; }
        public Action ActionReverseFromEnd { get; private set; }
        public Action ActionStop { get; private set; }
        public Action ActionToggleDirection { get; private set; }
        public Action ActionTogglePlayState { get; private set; }

        public float Elapsed { get; private set; }
        public float ElapsedRatio { get; private set; }
        public bool Active { get; private set; }
        public bool PlayingInReverse { get; private set; }

        float remaining;
        public float Remaining
        {
            get => Mathf.Max(0, duration - Elapsed);
            private set => remaining = value;
        }

        float remainingRatio;
        public float RemainingRatio
        {
            get => Mathf.Clamp01((duration - Elapsed) / duration);
            private set => remainingRatio = value;
        }

        float duration;
        bool loop;
        bool unscaledTime;
        AnimationCurve curve;
        AnimationCurve reverseCurve;

        public Action OnStarted;
        public Action OnStartedInReverse;
        public Action OnFinished;
        public Action OnFinishedInReverse;
        public Action OnUpdate;

        AnimationCurve currentCurve;

        public ValueAnimator(float duration = 1f, bool loop = false, bool unscaledTime = false,
            AnimationCurve curve = null, AnimationCurve reverseCurve = null,
            Action onStarted = null, Action onStartedInReverse = null, Action onFinished = null,
            Action onFinishedInReverse = null, Action onUpdate = null)
        {
            OnStarted = onStarted;
            OnStartedInReverse = onStartedInReverse;
            OnFinished = onFinished;
            OnFinishedInReverse = onFinishedInReverse;
            OnUpdate = onUpdate;

            ActionPlay = () => Play();
            ActionPlayFromStart = () => PlayFromStart();
            ActionReverse = () => Reverse();
            ActionReverseFromEnd = () => ReverseFromEnd();
            ActionStop = () => Stop();
            ActionToggleDirection = () => ToggleDirection();
            ActionTogglePlayState = () => TogglePlayState();

            MonoBehaviourHelper.Instance.onUpdate += Update;
        }

        public void Dispose()
        {
            MonoBehaviourHelper.Instance.onUpdate -= Update;
        }

        internal float GetInterpolationFactor()
        {
            return curve != null ? curve.Evaluate(ElapsedRatio) : ElapsedRatio;
        }

        protected virtual void AssignOutputValue() { }

        void Update() => Update(false);

        void Update(bool force = false)
        {
            if (!Active && !force)
            {
                return;
            }

            var delta = unscaledTime ? Time.unscaledDeltaTime : Time.deltaTime;

            if (PlayingInReverse)
            {
                Elapsed -= delta;
                Elapsed = Mathf.Max(Elapsed, 0);
            }
            else
            {
                Elapsed += delta;
                Elapsed = Mathf.Min(Elapsed, duration);
            }

            ElapsedRatio = Mathf.Clamp01(Elapsed / duration);

            OnUpdate?.Invoke();

            if (PlayingInReverse && Elapsed <= 0 || !PlayingInReverse && Elapsed >= duration)
            {
                if (loop)
                {
                    Elapsed = PlayingInReverse ? duration : 0;
                }
                else
                {
                    Active = false;
                }

                if (PlayingInReverse)
                {
                    OnFinishedInReverse?.Invoke();
                }
                else
                {
                    OnFinished?.Invoke();
                }
            }
        }

        void StartPlaying(bool inReverse)
        {
            if (reverseCurve != null && inReverse)
            {
                currentCurve = reverseCurve;
            }
            else if (curve != null && !inReverse)
            {
                currentCurve = curve;
            }

            PlayingInReverse = inReverse;
            Active = true;
            AssignOutputValue();
        }

        public void Play()
        {
            if (Active && PlayingInReverse)
            {
                PlayingInReverse = false;
            }
            else
            {
                StartPlaying(false);
            }
            OnStarted?.Invoke();
        }

        public void PlayFromStart()
        {
            Elapsed = 0;
            Play();
            OnStarted?.Invoke();
        }

        public void Reverse()
        {
            if (Active && !PlayingInReverse)
            {
                PlayingInReverse = true;
            }
            else
            {
                StartPlaying(true);
            }
            OnStartedInReverse?.Invoke();
        }

        public void ReverseFromEnd()
        {
            Elapsed = duration;
            Reverse();
            OnStartedInReverse?.Invoke();
        }

        public void Stop()
        {
            Active = false;
        }

        public void ToggleDirection()
        {
            PlayingInReverse = !PlayingInReverse;
        }

        public void TogglePlayState()
        {
            if (Active)
            {
                Stop();
            }
            else if (PlayingInReverse)
            {
                Reverse();
            }
            else
            {
                Play();
            }
        }

        public void SetTime(float time)
        {
            Elapsed = time;
            AssignOutputValue();
            Update(true);
        }
    }
}