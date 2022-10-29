using System;
using System.Collections;
using UnityEngine;

namespace EssentialUtils
{
    public class Buffer : IDisposable
    {
        public Action ActionRun { get; private set; }
        public Action ActionReset { get; private set; }

        public int MaxCount { get; set; }
        public float MaxTime { get; set; }
        public bool UnscaledTime { get; set; }
        public int Count => Queue.Count;

        public Action OnFull { get; set; }

        Queue Queue { get; } = new();
        Queue QueueTimeSamples { get; } = new();
        float elapsed;
        float lastTime;

        public Buffer(int maxCount = int.MaxValue, float maxTime = 0, bool unscaledTime = false, Action onFull = null)
        {
            MaxCount = maxCount;
            MaxTime = maxTime;
            UnscaledTime = unscaledTime;
            OnFull = onFull;

            ActionRun = () => Run();
            ActionReset = () => Reset();

            MonoBehaviourHelper.Instance.onUpdate += Update;
        }

        public void Dispose()
        {
            MonoBehaviourHelper.Instance.onUpdate -= Update;
        }

        void Update()
        {
            elapsed += Time.time - lastTime;
            lastTime = UnscaledTime ? Time.unscaledTime : Time.time;

            if (MaxTime > 0)
            {
                // Remove outdated samples from the queue
                while (QueueTimeSamples.Count > 0 && elapsed - (float)QueueTimeSamples.Peek() > MaxTime)
                {
                    Queue.Dequeue();
                    QueueTimeSamples.Dequeue();
                }
            }
        }

        public void Run(object value = null)
        {
            Queue.Enqueue(value);
            QueueTimeSamples.Enqueue(elapsed);

            if (Queue.Count > MaxCount)
            {
                Queue.Dequeue();
                QueueTimeSamples.Dequeue();
            }
            else if (Queue.Count == MaxCount)
            {
                OnFull?.Invoke();
            }
        }

        public void Reset()
        {
            Queue.Clear();
            QueueTimeSamples.Clear();
            elapsed = 0;
            lastTime = UnscaledTime ? Time.unscaledTime : Time.time;
        }
    }
}