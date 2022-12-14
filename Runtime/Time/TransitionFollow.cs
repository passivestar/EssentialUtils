using UnityEngine;

namespace EssentialUtils
{
    /*
        Follow behavior with acceleration to allow overshooting
    */

    public class TransitionFollowFloat : Transition
    {
        public float? CurrentValue { get; set; }
        public float TargetValue { get; set; }
        public float AccelerationMultiplier { get; set; }
        public float Damping { get; set; }
        public AnimationCurve AccelerationCurve { get; set; }

        float currentVelocity;
        float currentAcceleration;

        public TransitionFollowFloat(float? initialValue = null, float initialVelocity = 0f,
            float accelerationMultiplier = 1f, AnimationCurve accelerationCurve = null,
            float damping = 10f, bool unscaledTime = false)
        {
            CurrentValue = initialValue;
            currentVelocity = initialVelocity;
            AccelerationMultiplier = accelerationMultiplier;
            AccelerationCurve = accelerationCurve;
            Damping = damping;
            UnscaledTime = unscaledTime;
        }

        public float Run(float? targetValue = null, float? accelerationMultiplier = null, bool? unscaledTime = null)
        {
            if (targetValue != null) TargetValue = (float)targetValue;
            if (CurrentValue == null) CurrentValue = TargetValue;
            if (accelerationMultiplier != null) AccelerationMultiplier = (float)accelerationMultiplier;
            if (unscaledTime != null) UnscaledTime = (bool)unscaledTime;

            CurrentValue = ((float) CurrentValue).Follow(TargetValue, ref currentAcceleration, ref currentVelocity,
                AccelerationMultiplier, Damping, AccelerationCurve, GetDelta());
            return (float)CurrentValue;
        }
    }

    public class TransitionFollowVector2 : Transition
    {
        public Vector2? CurrentValue { get; set; }
        public Vector2 TargetValue { get; set; }
        public float AccelerationMultiplier { get; set; }
        public float Damping { get; set; }
        public AnimationCurve AccelerationCurve { get; set; }

        Vector2 currentVelocity;
        Vector2 currentAcceleration;

        public TransitionFollowVector2(Vector2? initialValue = null, Vector2 initialVelocity = new(),
            float accelerationMultiplier = 1f, AnimationCurve accelerationCurve = null,
            float damping = 10f, bool unscaledTime = false)
        {
            CurrentValue = initialValue;
            currentVelocity = initialVelocity;
            AccelerationMultiplier = accelerationMultiplier;
            AccelerationCurve = accelerationCurve;
            Damping = damping;
            UnscaledTime = unscaledTime;
        }

        public Vector2 Run(Vector2? targetValue = null, float? accelerationMultiplier = null, bool? unscaledTime = null)
        {
            if (targetValue != null) TargetValue = (Vector2)targetValue;
            if (CurrentValue == null) CurrentValue = TargetValue;
            if (accelerationMultiplier != null) AccelerationMultiplier = (float)accelerationMultiplier;
            if (unscaledTime != null) UnscaledTime = (bool)unscaledTime;

            CurrentValue = new(
                (((Vector2)CurrentValue).x).Follow(TargetValue.x, ref currentAcceleration.x, ref currentVelocity.x,
                    AccelerationMultiplier, Damping, AccelerationCurve, GetDelta()),
                (((Vector2)CurrentValue).y).Follow(TargetValue.y, ref currentAcceleration.y, ref currentVelocity.y,
                    AccelerationMultiplier, Damping, AccelerationCurve, GetDelta())
            );

            return (Vector2)CurrentValue;
        }
    }

    public class TransitionFollowVector3 : Transition
    {
        public Vector3? CurrentValue { get; set; }
        public Vector3 TargetValue { get; set; }
        public float AccelerationMultiplier { get; set; }
        public float Damping { get; set; }
        public AnimationCurve AccelerationCurve { get; set; }

        Vector3 currentVelocity;
        Vector3 currentAcceleration;

        public TransitionFollowVector3(Vector3? initialValue = null, Vector3 initialVelocity = new(),
            float accelerationMultiplier = 1f, AnimationCurve accelerationCurve = null,
            float damping = 10f, bool unscaledTime = false)
        {
            CurrentValue = initialValue;
            currentVelocity = initialVelocity;
            AccelerationMultiplier = accelerationMultiplier;
            AccelerationCurve = accelerationCurve;
            Damping = damping;
            UnscaledTime = unscaledTime;
        }

        public Vector3 Run(Vector3? targetValue = null, float? accelerationMultiplier = null, bool? unscaledTime = null)
        {
            if (targetValue != null) TargetValue = (Vector3)targetValue;
            if (CurrentValue == null) CurrentValue = TargetValue;
            if (accelerationMultiplier != null) AccelerationMultiplier = (float)accelerationMultiplier;
            if (unscaledTime != null) UnscaledTime = (bool)unscaledTime;

            CurrentValue = new(
                (((Vector3)CurrentValue).x).Follow(TargetValue.x, ref currentAcceleration.x, ref currentVelocity.x,
                    AccelerationMultiplier, Damping, AccelerationCurve, GetDelta()),
                (((Vector3)CurrentValue).y).Follow(TargetValue.y, ref currentAcceleration.y, ref currentVelocity.y,
                    AccelerationMultiplier, Damping, AccelerationCurve, GetDelta()),
                (((Vector3)CurrentValue).y).Follow(TargetValue.y, ref currentAcceleration.y, ref currentVelocity.y,
                    AccelerationMultiplier, Damping, AccelerationCurve, GetDelta())
            );

            return (Vector3)CurrentValue;
        }
    }
}