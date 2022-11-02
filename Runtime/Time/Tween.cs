using System;
using UnityEngine;

namespace EssentialUtils
{
    public abstract class Tween : IDisposable
    {
        public float Duration { get; set; }
        public bool Loop { get; set; }
        public bool UnscaledTime { get; set; }
        public AnimationCurve Curve { get; set; }
        public AnimationCurve ReverseCurve { get; set; }

        public float Elapsed { get; private set; }
        public float ElapsedRatio { get; private set; }
        public bool Active { get; private set; }
        public bool PlayingInReverse { get; private set; }

        float remaining;
        public float Remaining
        {
            get => Mathf.Max(0, Duration - Elapsed);
            private set => remaining = value;
        }

        float remainingRatio;
        public float RemainingRatio
        {
            get => Mathf.Clamp01((Duration - Elapsed) / Duration);
            private set => remainingRatio = value;
        }

        public event Action OnStarted;
        public event Action OnStartedInReverse;
        public event Action OnFinished;
        public event Action OnFinishedInReverse;
        public event Action OnUpdate;

        AnimationCurve currentCurve;

        public Tween(float duration = 1f, bool loop = false, bool unscaledTime = false,
            AnimationCurve curve = null, AnimationCurve reverseCurve = null,
            Action onStarted = null, Action onStartedInReverse = null, Action onFinished = null,
            Action onFinishedInReverse = null, Action onUpdate = null)
        {
            Duration = duration;
            Loop = loop;
            UnscaledTime = unscaledTime;
            Curve = curve;
            ReverseCurve = reverseCurve;

            OnStarted = onStarted;
            OnStartedInReverse = onStartedInReverse;
            OnFinished = onFinished;
            OnFinishedInReverse = onFinishedInReverse;
            OnUpdate = onUpdate;

            MonoBehaviourHelper.Instance.onUpdate += Update;
        }

        public void Dispose()
        {
            MonoBehaviourHelper.Instance.onUpdate -= Update;
        }

        internal float GetInterpolationFactor()
        {
            return currentCurve != null ? currentCurve.Evaluate(ElapsedRatio) : ElapsedRatio;
        }

        protected virtual void AssignOutputValue() { }

        void Update() => Update(false);

        void Update(bool force = false)
        {
            if (!Active && !force)
            {
                return;
            }

            var delta = UnscaledTime ? Time.unscaledDeltaTime : Time.deltaTime;

            if (PlayingInReverse)
            {
                Elapsed -= delta;
                Elapsed = Mathf.Max(Elapsed, 0);
            }
            else
            {
                Elapsed += delta;
                Elapsed = Mathf.Min(Elapsed, Duration);
            }

            ElapsedRatio = Mathf.Clamp01(Elapsed / Duration);

            AssignOutputValue();
            OnUpdate?.Invoke();

            if (PlayingInReverse && Elapsed <= 0 || !PlayingInReverse && Elapsed >= Duration)
            {
                if (Loop)
                {
                    Elapsed = PlayingInReverse ? Duration : 0;
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
            if (ReverseCurve != null && inReverse)
            {
                currentCurve = ReverseCurve;
            }
            else if (Curve != null && !inReverse)
            {
                currentCurve = Curve;
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
            Elapsed = Duration;
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