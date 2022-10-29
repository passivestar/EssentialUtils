using UnityEngine;

namespace EssentialUtils
{
    public class TransitionMoveTowardsFloat : Transition
    {
        public float? CurrentValue { get; set; }
        public float TargetValue { get; set; }
        public float Speed { get; set; }

        public TransitionMoveTowardsFloat(float? initialValue = null, float speed = 1f, bool unscaledTime = false)
        {
            CurrentValue = initialValue;
            Speed = speed;
            UnscaledTime = unscaledTime;
        }

        public float Run(float? targetValue = null, float? speed = null, bool? unscaledTime = null)
        {
            if (targetValue != null) TargetValue = (float)targetValue;
            if (CurrentValue == null) CurrentValue = TargetValue;
            if (speed != null) Speed = (float)speed;
            if (unscaledTime != null) UnscaledTime = (bool)unscaledTime;

            CurrentValue = Mathf.MoveTowards((float)CurrentValue, TargetValue, Speed * GetDelta());
            return (float)CurrentValue;
        }
    }

    public class TransitionMoveTowardsAngle : Transition
    {
        public float? CurrentValue { get; set; }
        public float TargetValue { get; set; }
        public float Speed { get; set; }

        public TransitionMoveTowardsAngle(float? initialValue = null, float speed = 1f, bool unscaledTime = false)
        {
            CurrentValue = initialValue;
            Speed = speed;
            UnscaledTime = unscaledTime;
        }

        public float Run(float? targetValue = null, float? speed = null, bool? unscaledTime = null)
        {
            if (targetValue != null) TargetValue = (float)targetValue;
            if (CurrentValue == null) CurrentValue = TargetValue;
            if (speed != null) Speed = (float)speed;
            if (unscaledTime != null) UnscaledTime = (bool)unscaledTime;

            CurrentValue = Mathf.MoveTowardsAngle((float)CurrentValue, TargetValue, Speed * GetDelta());
            return (float)CurrentValue;
        }
    }

    public class TransitionMoveTowardsVector2 : Transition
    {
        public Vector2? CurrentValue { get; set; }
        public Vector2 TargetValue { get; set; }
        public float Speed { get; set; }

        public TransitionMoveTowardsVector2(Vector2? initialValue = null, float speed = 1f, bool unscaledTime = false)
        {
            CurrentValue = initialValue;
            Speed = speed;
            UnscaledTime = unscaledTime;
        }

        public Vector2 Run(Vector2? targetValue = null, float? speed = null, bool? unscaledTime = null)
        {
            if (targetValue != null) TargetValue = (Vector2)targetValue;
            if (CurrentValue == null) CurrentValue = TargetValue;
            if (speed != null) Speed = (float)speed;
            if (unscaledTime != null) UnscaledTime = (bool)unscaledTime;

            CurrentValue = Vector2.MoveTowards((Vector2)CurrentValue, TargetValue, Speed * GetDelta());
            return (Vector2)CurrentValue;
        }
    }

    public class TransitionMoveTowardsVector3 : Transition
    {
        public Vector3? CurrentValue { get; set; }
        public Vector3 TargetValue { get; set; }
        public float Speed { get; set; }

        public TransitionMoveTowardsVector3(Vector3? initialValue = null, float speed = 1f, bool unscaledTime = false)
        {
            CurrentValue = initialValue;
            Speed = speed;
            UnscaledTime = unscaledTime;
        }

        public Vector3 Run(Vector3? targetValue = null, float? speed = null, bool? unscaledTime = null)
        {
            if (targetValue != null) TargetValue = (Vector3)targetValue;
            if (CurrentValue == null) CurrentValue = TargetValue;
            if (speed != null) Speed = (float)speed;
            if (unscaledTime != null) UnscaledTime = (bool)unscaledTime;

            CurrentValue = Vector3.MoveTowards((Vector3)CurrentValue, TargetValue, Speed * GetDelta());
            return (Vector3)CurrentValue;
        }
    }

    public class TransitionMoveTowardsVector4 : Transition
    {
        public Vector4? CurrentValue { get; set; }
        public Vector4 TargetValue { get; set; }
        public float Speed { get; set; }

        public TransitionMoveTowardsVector4(Vector4? initialValue = null, float speed = 1f, bool unscaledTime = false)
        {
            CurrentValue = initialValue;
            Speed = speed;
            UnscaledTime = unscaledTime;
        }

        public Vector4 Run(Vector4? targetValue = null, float? speed = null, bool? unscaledTime = null)
        {
            if (targetValue != null) TargetValue = (Vector4)targetValue;
            if (CurrentValue == null) CurrentValue = TargetValue;
            if (speed != null) Speed = (float)speed;
            if (unscaledTime != null) UnscaledTime = (bool)unscaledTime;

            CurrentValue = Vector4.MoveTowards((Vector4)CurrentValue, TargetValue, Speed * GetDelta());
            return (Vector4)CurrentValue;
        }
    }

    public class TransitionMoveTowardsQuaternion : Transition
    {
        public Quaternion? CurrentValue { get; set; }
        public Quaternion TargetValue { get; set; }
        public float Speed { get; set; }

        public TransitionMoveTowardsQuaternion(Quaternion? initialValue = null, float speed = 1f, bool unscaledTime = false)
        {
            CurrentValue = initialValue;
            Speed = speed;
            UnscaledTime = unscaledTime;
        }

        public Quaternion Run(Quaternion? targetValue = null, float? speed = null, bool? unscaledTime = null)
        {
            if (targetValue != null) TargetValue = (Quaternion)targetValue;
            if (CurrentValue == null) CurrentValue = TargetValue;
            if (speed != null) Speed = (float)speed;
            if (unscaledTime != null) UnscaledTime = (bool)unscaledTime;

            CurrentValue = Quaternion.RotateTowards((Quaternion)CurrentValue, TargetValue, Speed * GetDelta());
            return (Quaternion)CurrentValue;
        }
    }

    public class TransitionMoveTowardsTransform : Transition
    {
        public Transform CurrentValue { get; set; }
        public Transform TargetValue { get; set; }
        public float Speed { get; set; }

        public bool AffectPosition { get; set; }
        public bool AffectRotation { get; set; }
        public bool AffectScale { get; set; }

        public TransitionMoveTowardsTransform(Transform initialValue, float speed = 1f, bool unscaledTime = false,
            bool affectPosition = true, bool affectRotation = true, bool affectScale = true)
        {
            CurrentValue = initialValue;
            Speed = speed;
            UnscaledTime = unscaledTime;

            AffectPosition = affectPosition;
            AffectRotation = affectRotation;
            AffectScale = affectScale;
        }

        public Transform Run(Transform targetValue = null, float? speed = null, bool? unscaledTime = null)
        {
            if (TargetValue == null)
            {
                return CurrentValue;
            }

            if (targetValue != null) TargetValue = targetValue;
            if (speed != null) Speed = (float)speed;
            if (unscaledTime != null) UnscaledTime = (bool)unscaledTime;

            var factor = Speed * GetDelta();

            if (AffectPosition)
            {
                CurrentValue.position = Vector3.MoveTowards(CurrentValue.position, TargetValue.position, factor);
            }

            if (AffectRotation)
            {
                CurrentValue.rotation = Quaternion.RotateTowards(CurrentValue.rotation, TargetValue.rotation, factor);
            }

            if (AffectScale)
            {
                CurrentValue.localScale = Vector3.MoveTowards(CurrentValue.localScale, TargetValue.localScale, factor);
            }

            return CurrentValue;
        }
    }
}