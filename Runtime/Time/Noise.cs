using UnityEngine;

namespace EssentialUtils
{
    public static class Noise
    {
        const float ComponentOffset = 1111.1111f;

        static float GetNoise(
            float time,
            float amplitude,
            int octaves,
            float frequency,
            float persistence,
            float offset = 0f,
            bool positive = false)
        {
            float total = 0, amp = 1f, freq = 1f, maxValue = 0;
            for (int i = 0; i < octaves; i++)
            {
                var octaveOffset = Mathf.Sin(i) * 1000f;
                var val = time * frequency + (octaveOffset + offset) * frequency;
                var generatedValue = Mathf.PerlinNoise(val, val);
                if (!positive)
                {
                    generatedValue = 1f - generatedValue * 2f;
                }
                total += generatedValue * amp;
                amp *= persistence;
                freq *= frequency;
                maxValue += amp;
            }
            return total / maxValue * amplitude;
        }

        public static float GetFloat(float startingValue, float? time = null, float amplitude = 1f,
            int octaves = 1, float frequency = 1f, float persistence = 1f)
        {
            return startingValue + GetNoise(time ?? Time.time, amplitude, octaves, frequency, persistence);
        }

        public static Color GetColor(Color startingValue, float? time = null, float amplitude = 1f,
            int octaves = 1, float frequency = 1f, float persistence = 1f)
        {
            time = time ?? Time.time;
            return startingValue + new Color(
                GetNoise((float)time, amplitude, octaves, frequency, persistence, 0, true),
                GetNoise((float)time, amplitude, octaves, frequency, persistence, ComponentOffset, true),
                GetNoise((float)time, amplitude, octaves, frequency, persistence, ComponentOffset * 2, true)
            );
        }

        public static Vector2 GetVector2(Vector2 startingValue, float? time = null, float amplitude = 1f,
            int octaves = 1, float frequency = 1f, float persistence = 1f)
        {
            time = time ?? Time.time;
            return startingValue + new Vector2(
                GetNoise((float)time, amplitude, octaves, frequency, persistence),
                GetNoise((float)time, amplitude, octaves, frequency, persistence, ComponentOffset)
            );
        }

        public static Vector3 GetVector3(Vector3 startingValue, float? time = null, float amplitude = 1f,
            int octaves = 1, float frequency = 1f, float persistence = 1f)
        {
            time = time ?? Time.time;
            return startingValue + new Vector3(
                GetNoise((float)time, amplitude, octaves, frequency, persistence),
                GetNoise((float)time, amplitude, octaves, frequency, persistence, ComponentOffset),
                GetNoise((float)time, amplitude, octaves, frequency, persistence, ComponentOffset * 2)
            );
        }

        public static Vector4 GetVector4(Vector4 startingValue, float? time = null, float amplitude = 1f,
            int octaves = 1, float frequency = 1f, float persistence = 1f)
        {
            time = time ?? Time.time;
            return startingValue + new Vector4(
                GetNoise((float)time, amplitude, octaves, frequency, persistence),
                GetNoise((float)time, amplitude, octaves, frequency, persistence, ComponentOffset),
                GetNoise((float)time, amplitude, octaves, frequency, persistence, ComponentOffset * 2),
                GetNoise((float)time, amplitude, octaves, frequency, persistence, ComponentOffset * 3)
            );
        }

        public static Quaternion GetQuaternion(Quaternion startingValue, float? time = null, float amplitude = 1f,
            int octaves = 1, float frequency = 1f, float persistence = 1f)
        {
            time = time ?? Time.time;
            return startingValue * Quaternion.Euler(
                GetNoise((float)time, amplitude, octaves, frequency, persistence),
                GetNoise((float)time, amplitude, octaves, frequency, persistence, ComponentOffset),
                GetNoise((float)time, amplitude, octaves, frequency, persistence, ComponentOffset * 2)
            );
        }
    }
}