using System;
using UnityEngine;

namespace EssentialUtils
{
    public class Throttle
    {
        public float Interval { get; set; }

        public event Action OnRun;

        float elapsed;
        float lastInvokeTime;

        public Throttle(Action onRun, float interval = 1f)
        {
            OnRun = onRun;
            Interval = interval;
        }

        public void Run(bool unscaledTime = false)
        {
            var delta = unscaledTime ? Time.unscaledDeltaTime : Time.deltaTime;
            elapsed += delta;

            if (elapsed - lastInvokeTime >= Interval)
            {
                lastInvokeTime = elapsed;
                OnRun();
            }
        }
    }
}