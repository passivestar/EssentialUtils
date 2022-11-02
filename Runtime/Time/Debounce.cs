using System;
using UnityEngine;

namespace EssentialUtils
{
    public class Debounce : IDisposable
    {
        public float Interval { get; set; }
        public bool UnscaledTime { get; set; }
        public event Action OnRun;

        float elapsed;
        float lastRunTime;
        bool active;

        public Debounce(Action onRun, float interval = 1f, bool unscaledTime = false)
        {
            Interval = interval;
            UnscaledTime = unscaledTime;
            OnRun = onRun;

            MonoBehaviourHelper.Instance.onUpdate += Update;
        }

        public void Dispose()
        {
            MonoBehaviourHelper.Instance.onUpdate -= Update;
        }

        void Update()
        {
            if (!active)
            {
                return;
            }

            var delta = UnscaledTime ? Time.unscaledDeltaTime : Time.deltaTime;
            elapsed += delta;

            if (elapsed - lastRunTime < Interval)
            {
                return;
            }

            active = false;
            OnRun();
        }

        public void Run()
        {
            lastRunTime = elapsed;
            active = true;
        }
    }
}