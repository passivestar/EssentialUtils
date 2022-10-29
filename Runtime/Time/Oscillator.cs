using System;
using UnityEngine;

namespace EssentialUtils
{
    public class Oscillator
    {
        public Action ActionRun { get; private set; }

        float elapsed;

        public Oscillator()
        {
            ActionRun = () => Run();
        }

        // TODO: Subscribe to update, no need to call manually

        public float Run(float amplitude = 1f, float frequency = 1f, float offset = 0f,
            float valueOffset = 0f, bool unscaledTime = false)
        {
            elapsed += unscaledTime ? Time.unscaledDeltaTime : Time.deltaTime;
            var valueNormalized = Mathf.Sin(elapsed * frequency * Mathf.PI + offset * Mathf.PI);
            return valueNormalized * amplitude + valueOffset;
        }
    }
}