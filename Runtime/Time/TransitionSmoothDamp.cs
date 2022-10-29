using UnityEngine;

namespace EssentialUtils
{
    public class TransitionSmoothDampFloat : Transition
    {
        public float? CurrentValue { get; set; }
        public float TargetValue { get; set; }
        public float SmoothTime { get; set; }
        public float MaxSpeed { get; set; }

        float currentVelocity;

        public TransitionSmoothDampFloat(float? initialValue = null, float smoothTime = 1f,
            float maxSpeed = 1000f, bool unscaledTime = false)
        {
            CurrentValue = initialValue;
            SmoothTime = smoothTime;
            MaxSpeed = maxSpeed;
            UnscaledTime = unscaledTime;
        }

        public float Run(float? targetValue = null, float? smoothTime = null, float? maxSpeed = null, bool? unscaledTime = null)
        {
            if (targetValue != null) TargetValue = (float)targetValue;
            if (CurrentValue == null) CurrentValue = TargetValue;
            if (smoothTime != null) SmoothTime = (float)smoothTime;
            if (maxSpeed != null) MaxSpeed = (float)maxSpeed;
            if (unscaledTime != null) UnscaledTime = (bool)unscaledTime;

            CurrentValue = Mathf.SmoothDamp((float)CurrentValue, TargetValue, ref currentVelocity, SmoothTime, MaxSpeed, GetDelta());
            return (float)CurrentValue;
        }
    }

    public class TransitionSmoothDampAngle : Transition
    {
        public float? CurrentValue { get; set; }
        public float TargetValue { get; set; }
        public float SmoothTime { get; set; }
        public float MaxSpeed { get; set; }

        float currentVelocity;

        public TransitionSmoothDampAngle(float? initialValue = null, float smoothTime = 1f,
            float maxSpeed = 1000f, bool unscaledTime = false)
        {
            CurrentValue = initialValue;
            SmoothTime = smoothTime;
            MaxSpeed = maxSpeed;
            UnscaledTime = unscaledTime;
        }

        public float Run(float? targetValue = null, float? smoothTime = null, float? maxSpeed = null, bool? unscaledTime = null)
        {
            if (targetValue != null) TargetValue = (float)targetValue;
            if (CurrentValue == null) CurrentValue = TargetValue;
            if (smoothTime != null) SmoothTime = (float)smoothTime;
            if (maxSpeed != null) MaxSpeed = (float)maxSpeed;
            if (unscaledTime != null) UnscaledTime = (bool)unscaledTime;

            CurrentValue = Mathf.SmoothDampAngle((float)CurrentValue, TargetValue, ref currentVelocity, SmoothTime, MaxSpeed, GetDelta());
            return (float)CurrentValue;
        }
    }

    public class TransitionSmoothDampVector2 : Transition
    {
        public Vector2? CurrentValue { get; set; }
        public Vector2 TargetValue { get; set; }
        public float SmoothTime { get; set; }
        public float MaxSpeed { get; set; }

        Vector2 currentVelocity;

        public TransitionSmoothDampVector2(Vector2? initialValue = null, float smoothTime = 1f,
            float maxSpeed = 1000f, bool unscaledTime = false)
        {
            CurrentValue = initialValue;
            SmoothTime = smoothTime;
            MaxSpeed = maxSpeed;
            UnscaledTime = unscaledTime;
        }

        public Vector2 Run(Vector2? targetValue = null, float? smoothTime = null, float? maxSpeed = null, bool? unscaledTime = null)
        {
            if (targetValue != null) TargetValue = (Vector2)targetValue;
            if (CurrentValue == null) CurrentValue = TargetValue;
            if (smoothTime != null) SmoothTime = (float)smoothTime;
            if (maxSpeed != null) MaxSpeed = (float)maxSpeed;
            if (unscaledTime != null) UnscaledTime = (bool)unscaledTime;

            CurrentValue = Vector2.SmoothDamp((Vector2)CurrentValue, TargetValue, ref currentVelocity, SmoothTime, MaxSpeed, GetDelta());
            return (Vector2)CurrentValue;
        }
    }

    public class TransitionSmoothDampVector3 : Transition
    {
        public Vector3? CurrentValue { get; set; }
        public Vector3 TargetValue { get; set; }
        public float SmoothTime { get; set; }
        public float MaxSpeed { get; set; }

        Vector3 currentVelocity;

        public TransitionSmoothDampVector3(Vector3? initialValue = null, float smoothTime = 1f,
            float maxSpeed = 1000f, bool unscaledTime = false)
        {
            CurrentValue = initialValue;
            SmoothTime = smoothTime;
            MaxSpeed = maxSpeed;
            UnscaledTime = unscaledTime;
        }

        public Vector3 Run(Vector3? targetValue = null, float? smoothTime = null, float? maxSpeed = null, bool? unscaledTime = null)
        {
            if (targetValue != null) TargetValue = (Vector3)targetValue;
            if (CurrentValue == null) CurrentValue = TargetValue;
            if (smoothTime != null) SmoothTime = (float)smoothTime;
            if (maxSpeed != null) MaxSpeed = (float)maxSpeed;
            if (unscaledTime != null) UnscaledTime = (bool)unscaledTime;

            CurrentValue = Vector3.SmoothDamp((Vector3)CurrentValue, TargetValue, ref currentVelocity, SmoothTime, MaxSpeed, GetDelta());
            return (Vector3)CurrentValue;
        }
    }
}