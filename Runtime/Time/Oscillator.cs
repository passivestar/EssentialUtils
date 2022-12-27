using UnityEngine;

namespace EssentialUtils
{
    public class Oscillator
    {
        public float Amplitude { get; set; }
        public float Frequency { get; set; }
        public float Offset { get; set; }
        public float ValueOffset { get; set; }
        public bool UnscaledTime { get; set; }

        public float Value { get; private set; }

        float elapsed;

        public Oscillator(float amplitude = 1f, float frequency = 1f, float offset = 0f,
            float valueOffset = 0f, bool unscaledTime = false)
        {
            Amplitude = amplitude;
            Frequency = frequency;
            Offset = offset;
            ValueOffset = valueOffset;
            UnscaledTime = unscaledTime;

            MonoBehaviourHelper.Instance.onUpdate += Update;
        }

        public void Dispose()
        {
            MonoBehaviourHelper.Instance.onUpdate -= Update;
        }

        public void Update()
        {
            elapsed += UnscaledTime ? Time.unscaledDeltaTime : Time.deltaTime;
            var valueNormalized = Mathf.Sin(elapsed * Frequency * Mathf.PI + Offset * Mathf.PI);
            Value = valueNormalized * Amplitude + ValueOffset;
        }
    }
}