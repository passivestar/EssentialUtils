using System;
using UnityEngine;

namespace EssentialUtils
{
    public static class FloatExtensions
    {
        public static float MapRange(this float value, float valueMin, float valueMax, float min, float max)
        {
            var t = Mathf.InverseLerp(valueMin, valueMax, value);
            var val = Mathf.Lerp(min, max, t);
            return min <= max ? Mathf.Clamp(val, min, max) : Mathf.Clamp(val, max, min);
        }

        public static float MapRange(this float value, float valueMin, float valueMax, float min, float max, AnimationCurve curve = null)
        {
            var t = Mathf.InverseLerp(valueMin, valueMax, value);
            if (curve != null)
            {
                t = curve.Evaluate(t);
            }
            var val = Mathf.Lerp(min, max, t);
            return min <= max ? Mathf.Clamp(val, min, max) : Mathf.Clamp(val, max, min);
        }

        public static float Follow(this float current, float target, ref float acceleration, ref float velocity,
            float accelerationMultiplier, float damping, AnimationCurve curve, float delta)
        {
            var diff = target - current;
            if (curve != null)
            {
                diff = curve.Evaluate(diff);
            }
            acceleration = diff * accelerationMultiplier;
            velocity += acceleration * delta;
            velocity = Mathf.Lerp(velocity, 0, damping * delta);
            return current + velocity * delta;
        }

        public static string FormatTime(this float time, string format = "m\\:ss\\.fff")
        {
            var timeSpan = new TimeSpan((long)(time * TimeSpan.TicksPerSecond));
            return timeSpan.ToString(format);
        }

        public static float RoundToGrid(this float value, float grid)
        {
            return Mathf.Round(value / grid) * grid;
        }

        public static float FloorToGrid(this float value, float grid)
        {
            return Mathf.Floor(value / grid) * grid;
        }

        public static float CeilToGrid(this float value, float grid)
        {
            return Mathf.Ceil(value / grid) * grid;
        }
    }
}