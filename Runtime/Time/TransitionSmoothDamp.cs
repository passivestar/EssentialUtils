using UnityEngine;

namespace EssentialUtils
{
    public class TransitionSmoothDampFloat : Transition
    {
        public float CurrentValue { get; set; }
        public float TargetValue { get; set; }
        public float SmoothTime { get; set; }
        public float MaxSpeed { get; set; }

        float currentVelocity;

        public TransitionSmoothDampFloat(float initialValue = 0f, float smoothTime = 1f,
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
            if (smoothTime != null) SmoothTime = (float)smoothTime;
            if (maxSpeed != null) MaxSpeed = (float)maxSpeed;
            if (unscaledTime != null) UnscaledTime = (bool)unscaledTime;

            return CurrentValue = Mathf.SmoothDamp(CurrentValue, TargetValue, ref currentVelocity, SmoothTime, MaxSpeed, GetDelta());
        }
    }

    public class TransitionSmoothDampAngle : Transition
    {
        public float CurrentValue { get; set; }
        public float TargetValue { get; set; }
        public float SmoothTime { get; set; }
        public float MaxSpeed { get; set; }

        float currentVelocity;

        public TransitionSmoothDampAngle(float initialValue = 0f, float smoothTime = 1f,
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
            if (smoothTime != null) SmoothTime = (float)smoothTime;
            if (maxSpeed != null) MaxSpeed = (float)maxSpeed;
            if (unscaledTime != null) UnscaledTime = (bool)unscaledTime;

            return CurrentValue = Mathf.SmoothDampAngle(CurrentValue, TargetValue, ref currentVelocity, SmoothTime, MaxSpeed, GetDelta());
        }
    }

    public class TransitionSmoothDampVector2 : Transition
    {
        public Vector2 CurrentValue { get; set; }
        public Vector2 TargetValue { get; set; }
        public float SmoothTime { get; set; }
        public float MaxSpeed { get; set; }

        Vector2 currentVelocity;

        public TransitionSmoothDampVector2(Vector2 initialValue = new Vector2(), float smoothTime = 1f,
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
            if (smoothTime != null) SmoothTime = (float)smoothTime;
            if (maxSpeed != null) MaxSpeed = (float)maxSpeed;
            if (unscaledTime != null) UnscaledTime = (bool)unscaledTime;

            return CurrentValue = Vector2.SmoothDamp(CurrentValue, TargetValue, ref currentVelocity, SmoothTime, MaxSpeed, GetDelta());
        }
    }

    public class TransitionSmoothDampVector3 : Transition
    {
        public Vector3 CurrentValue { get; set; }
        public Vector3 TargetValue { get; set; }
        public float SmoothTime { get; set; }
        public float MaxSpeed { get; set; }

        Vector3 currentVelocity;

        public TransitionSmoothDampVector3(Vector3 initialValue = new Vector3(), float smoothTime = 1f,
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
            if (smoothTime != null) SmoothTime = (float)smoothTime;
            if (maxSpeed != null) MaxSpeed = (float)maxSpeed;
            if (unscaledTime != null) UnscaledTime = (bool)unscaledTime;

            return CurrentValue = Vector3.SmoothDamp(CurrentValue, TargetValue, ref currentVelocity, SmoothTime, MaxSpeed, GetDelta());
        }
    }
}