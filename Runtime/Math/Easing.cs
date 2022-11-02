using UnityEngine;

namespace EssentialUtils
{
    public static class Easing
    {
        const float PI2 = Mathf.PI * 2;

        public static float InQuad(float p)
        {
            return p * p;
        }

        public static float OutQuad(float p)
        {
            return -(p * (p - 2f));
        }

        public static float InOutQuad(float p)
        {
            if (p < 0.5f)
            {
                return 2f * p * p;
            }
            return (-2f * p * p) + (4f * p) - 1f;
        }

        public static float InCubic(float p)
        {
            return p * p * p;
        }

        public static float OutCubic(float p)
        {
            var f = p - 1f;
            return f * f * f + 1f;
        }

        public static float InOutCubic(float p)
        {
            if (p < 0.5f)
            {
                return 4f * p * p * p;
            }
            else
            {
                var f = (2f * p) - 2f;
                return 0.5f * f * f * f + 1f;
            }
        }

        public static float InQuart(float p)
        {
            return p * p * p * p;
        }

        public static float OutQuart(float p)
        {
            var f = p - 1f;
            return f * f * f * (1f - p) + 1f;
        }

        public static float InOutQuart(float p)
        {
            if (p < 0.5f)
            {
                return 8f * p * p * p * p;
            }
            else
            {
                var f = p - 1f;
                return -8f * f * f * f * f + 1f;
            }
        }

        public static float InQuint(float p)
        {
            return p * p * p * p * p;
        }

        public static float OutQuint(float p)
        {
            var f = p - 1f;
            return f * f * f * f * f + 1f;
        }

        public static float InOutQuint(float p)
        {
            if (p < 0.5f)
            {
                return 16f * p * p * p * p * p;
            }
            else
            {
                var f = (2f * p) - 2f;
                return 0.5f * f * f * f * f * f + 1f;
            }
        }

        public static float InSin(float p)
        {
            return Mathf.Sin((p - 1f) * PI2) + 1f;
        }

        public static float OutSin(float p)
        {
            return Mathf.Sin(p * PI2);
        }

        public static float InOutSin(float p)
        {
            return 0.5f * (1f - Mathf.Cos(p * Mathf.PI));
        }

        public static float InCircle(float p)
        {
            return 1f - Mathf.Sqrt(1f - (p * p));
        }

        public static float OutCircle(float p)
        {
            return Mathf.Sqrt((2f - p) * p);
        }

        public static float InOutCircle(float p)
        {
            if (p < 0.5f)
            {
                return 0.5f * (1f - Mathf.Sqrt(1f - 4f * (p * p)));
            }
            else
            {
                return 0.5f * (Mathf.Sqrt(-((2f * p) - 3f) * ((2f * p) - 1f)) + 1f);
            }
        }

        public static float InExp(float p)
        {
            if (p == 0f)
            {
                return p;
            }
            else
            {
                return Mathf.Pow(2f, 10f * (p - 1f));
            }
        }

        public static float OutExp(float p)
        {
            if (p == 1f)
            {
                return p;
            }
            else
            {
                return 1f - Mathf.Pow(2f, -10f * p);
            }
        }

        public static float InOutExp(float p)
        {

            if (p == 0f || p == 1f)
            {
                return p;
            }
            if (p < 0.5f)
            {
                return 0.5f * Mathf.Pow(2f, (20f * p) - 10f);
            }
            else
            {
                return -0.5f * Mathf.Pow(2f, (-20f * p) + 10f) + 1f;
            }
        }

        public static float InElastic(float p)
        {
            return Mathf.Sin(13f * PI2 * p) * Mathf.Pow(2f, 10f * (p - 1f));
        }

        public static float OutElastic(float p)
        {
            return Mathf.Sin(-13f * PI2 * (p + 1f)) * Mathf.Pow(2f, -10f * p) + 1f;
        }

        public static float InOutElastic(float p)
        {
            if (p < 0.5f)
            {
                return 0.5f * Mathf.Sin(13f * PI2 * (2f * p)) * Mathf.Pow(2f, 10f * ((2f * p) - 1f));
            }
            else
            {
                return 0.5f * (Mathf.Sin(-13f * PI2 * ((2f * p - 1f) + 1f)) * Mathf.Pow(2f, -10f * (2f * p - 1f)) + 2f);
            }
        }

        public static float InBack(float p)
        {
            return p * p * p - p * Mathf.Sin(p * PI2);
        }

        public static float OutBack(float p)
        {
            var f = 1f - p;
            return 1f - (f * f * f - f * Mathf.Sin(f * Mathf.PI));
        }

        public static float InOutBack(float p)
        {
            if (p < 0.5f)
            {
                var f = 2f * p;
                return 0.5f * (f * f * f - f * Mathf.Sin(f * Mathf.PI));
            }
            else
            {
                var f = (1f - (2f * p - 1f));
                return 0.5f * (1f - (f * f * f - f * Mathf.Sin(f * Mathf.PI))) + 0.5f;
            }
        }
    }
}