using System;
using System.Collections;
using UnityEngine;

namespace EssentialUtils
{
    public class Timer
    {
        public Action ActionStart { get; private set; }
        public Action ActionStop { get; private set; }
        public Action ActionPause { get; private set; }
        public Action ActionResume { get; private set; }

        public float Duration { get; set; }
        public bool Loop { get; set; }
        public bool UnscaledTime { get; set; }

        public event Action OnStarted;
        public event Action OnStopped;
        public event Action OnPaused;
        public event Action OnResumed;
        public event Action OnFinished;
        public event Action OnUpdate;

        public float Elapsed { get; private set; }
        public float ElapsedRatio { get; private set; }
        public bool Active { get; private set; }

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

        public Timer(float duration = 1f, bool loop = false, bool unscaledTime = false,
            Action onStarted = null, Action onStopped = null, Action onPaused = null,
            Action onResumed = null, Action onFinished = null, Action onUpdate = null)
        {
            Duration = duration;
            Loop = loop;
            UnscaledTime = unscaledTime;
            OnStarted = onStarted;
            OnStopped = onStopped;
            OnPaused = onPaused;
            OnResumed = onResumed;
            OnFinished = onFinished;
            OnUpdate = onUpdate;

            ActionStart = () => Start();
            ActionStop = () => Stop();
            ActionPause = () => Pause();
            ActionResume = () => Resume();

            MonoBehaviourHelper.Instance.onUpdate += Update;
        }

        public void Dispose()
        {
            MonoBehaviourHelper.Instance.onUpdate -= Update;
        }

        void Update()
        {
            if (!Active)
            {
                return;
            }

            var delta = UnscaledTime ? Time.unscaledDeltaTime : Time.deltaTime;

            Elapsed += delta;
            Elapsed = Mathf.Min(Elapsed, Duration);

            ElapsedRatio = Mathf.Clamp01(Elapsed / Duration);

            OnUpdate?.Invoke();

            if (Elapsed >= Duration)
            {
                if (Loop)
                {
                    Elapsed = 0;
                }
                else
                {
                    Active = false;
                }

                OnFinished?.Invoke();
            }
        }

        public void Start()
        {
            Active = true;
            Elapsed = 0;
            OnStarted?.Invoke();
        }

        public void Stop()
        {
            Active = false;
            Elapsed = 0;
            OnStopped?.Invoke();
        }

        public void Pause()
        {
            Active = false;
            OnPaused?.Invoke();
        }

        public void Resume()
        {
            Active = true;
            OnResumed?.Invoke();
        }
    }
}