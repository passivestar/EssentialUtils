using System;
using UnityEngine;

namespace EssentialUtils
{
    public abstract class ValueAnimator : IDisposable
    {
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

        Action onStarted;
        Action onStartedInReverse;
        Action onFinished;
        Action onFinishedInReverse;
        Action onUpdate;

        AnimationCurve currentCurve;

        public ValueAnimator(float duration = 1f, bool loop = false, bool unscaledTime = false,
            AnimationCurve curve = null, AnimationCurve reverseCurve = null,
            Action onStarted = null, Action onStartedInReverse = null, Action onFinished = null,
            Action onFinishedInReverse = null, Action onUpdate = null)
        {
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

            onUpdate?.Invoke();

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
                    onFinishedInReverse?.Invoke();
                }
                else
                {
                    onFinished?.Invoke();
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
            onStarted?.Invoke();
        }

        public void PlayFromStart()
        {
            Elapsed = 0;
            Play();
            onStarted?.Invoke();
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
            onStartedInReverse?.Invoke();
        }

        public void ReverseFromEnd()
        {
            Elapsed = duration;
            Reverse();
            onStartedInReverse?.Invoke();
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

        public void SetTime()
        {
            AssignOutputValue();
            Update(true);
        }
    }
}