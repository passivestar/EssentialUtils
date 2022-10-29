using UnityEngine;

namespace EssentialUtils
{
    public class TransitionLerpFloat : Transition
    {
        public float CurrentValue { get; set; }
        public float TargetValue { get; set; }
        public float Speed { get; set; }

        public TransitionLerpFloat(float initialValue = 0f, float speed = 1f, bool unscaledTime = false)
        {
            CurrentValue = initialValue;
            Speed = speed;
            UnscaledTime = unscaledTime;
        }

        public float Run(float? targetValue = null, float? speed = null, bool? unscaledTime = null)
        {
            if (targetValue != null) TargetValue = (float)targetValue;
            if (speed != null) Speed = (float)speed;
            if (unscaledTime != null) UnscaledTime = (bool)unscaledTime;

            return CurrentValue = Mathf.Lerp(CurrentValue, TargetValue, Speed * GetDelta());
        }
    }

    public class TransitionLerpAngle : Transition
    {
        public float CurrentValue { get; set; }
        public float TargetValue { get; set; }
        public float Speed { get; set; }

        public TransitionLerpAngle(float initialValue = 0f, float speed = 1f, bool unscaledTime = false)
        {
            CurrentValue = initialValue;
            Speed = speed;
            UnscaledTime = unscaledTime;
        }

        public float Run(float? targetValue = null, float? speed = null, bool? unscaledTime = null)
        {
            if (targetValue != null) TargetValue = (float)targetValue;
            if (speed != null) Speed = (float)speed;
            if (unscaledTime != null) UnscaledTime = (bool)unscaledTime;

            return CurrentValue = Mathf.LerpAngle(CurrentValue, TargetValue, Speed * GetDelta());
        }
    }

    public class TransitionLerpColor : Transition
    {
        public Color CurrentValue { get; set; }
        public Color TargetValue { get; set; }
        public float Speed { get; set; }

        public TransitionLerpColor(Color initialValue = new Color(), float speed = 1f, bool unscaledTime = false)
        {
            CurrentValue = initialValue;
            Speed = speed;
            UnscaledTime = unscaledTime;
        }

        public Color Run(Color? targetValue = null, float? speed = null, bool? unscaledTime = null)
        {
            if (targetValue != null) TargetValue = (Color)targetValue;
            if (speed != null) Speed = (float)speed;
            if (unscaledTime != null) UnscaledTime = (bool)unscaledTime;

            return CurrentValue = Color.Lerp(CurrentValue, TargetValue, Speed * GetDelta());
        }
    }

    public class TransitionLerpVector2 : Transition
    {
        public Vector2 CurrentValue { get; set; }
        public Vector2 TargetValue { get; set; }
        public float Speed { get; set; }

        public TransitionLerpVector2(Vector2 initialValue = new Vector2(), float speed = 1f, bool unscaledTime = false)
        {
            CurrentValue = initialValue;
            Speed = speed;
            UnscaledTime = unscaledTime;
        }

        public Vector2 Run(Vector2? targetValue = null, float? speed = null, bool? unscaledTime = null)
        {
            if (targetValue != null) TargetValue = (Vector2)targetValue;
            if (speed != null) Speed = (float)speed;
            if (unscaledTime != null) UnscaledTime = (bool)unscaledTime;

            return CurrentValue = Vector2.Lerp(CurrentValue, TargetValue, Speed * GetDelta());
        }
    }

    public class TransitionLerpVector3 : Transition
    {
        public Vector3 CurrentValue { get; set; }
        public Vector3 TargetValue { get; set; }
        public float Speed { get; set; }

        public TransitionLerpVector3(Vector3 initialValue = new Vector3(), float speed = 1f, bool unscaledTime = false)
        {
            CurrentValue = initialValue;
            Speed = speed;
            UnscaledTime = unscaledTime;
        }

        public Vector3 Run(Vector3? targetValue = null, float? speed = null, bool? unscaledTime = null)
        {
            if (targetValue != null) TargetValue = (Vector3)targetValue;
            if (speed != null) Speed = (float)speed;
            if (unscaledTime != null) UnscaledTime = (bool)unscaledTime;

            return CurrentValue = Vector3.Lerp(CurrentValue, TargetValue, Speed * GetDelta());
        }
    }

    public class TransitionLerpVector4 : Transition
    {
        public Vector4 CurrentValue { get; set; }
        public Vector4 TargetValue { get; set; }
        public float Speed { get; set; }

        public TransitionLerpVector4(Vector4 initialValue = new Vector4(), float speed = 1f, bool unscaledTime = false)
        {
            CurrentValue = initialValue;
            Speed = speed;
            UnscaledTime = unscaledTime;
        }

        public Vector4 Run(Vector4? targetValue = null, float? speed = null, bool? unscaledTime = null)
        {
            if (targetValue != null) TargetValue = (Vector4)targetValue;
            if (speed != null) Speed = (float)speed;
            if (unscaledTime != null) UnscaledTime = (bool)unscaledTime;

            return CurrentValue = Vector4.Lerp(CurrentValue, TargetValue, Speed * GetDelta());
        }
    }

    public class TransitionLerpQuaternion : Transition
    {
        public Quaternion CurrentValue { get; set; }
        public Quaternion TargetValue { get; set; }
        public float Speed { get; set; }

        public TransitionLerpQuaternion(Quaternion initialValue = new Quaternion(), float speed = 1f, bool unscaledTime = false)
        {
            CurrentValue = initialValue;
            Speed = speed;
            UnscaledTime = unscaledTime;
        }

        public Quaternion Run(Quaternion? targetValue = null, float? speed = null, bool? unscaledTime = null)
        {
            if (targetValue != null) TargetValue = (Quaternion)targetValue;
            if (speed != null) Speed = (float)speed;
            if (unscaledTime != null) UnscaledTime = (bool)unscaledTime;

            return CurrentValue = Quaternion.Slerp(CurrentValue, TargetValue, Speed * GetDelta());
        }
    }

    public class TransitionLerpTransform : Transition
    {
        public Transform CurrentValue { get; set; }
        public Transform TargetValue { get; set; }
        public float Speed { get; set; }

        public bool AffectPosition { get; set; }
        public bool AffectRotation { get; set; }
        public bool AffectScale { get; set; }

        public TransitionLerpTransform(Transform initialValue, float speed = 1f, bool unscaledTime = false,
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
                CurrentValue.position = Vector3.Lerp(CurrentValue.position, TargetValue.position, factor);
            }

            if (AffectRotation)
            {
                CurrentValue.rotation = Quaternion.Slerp(CurrentValue.rotation, TargetValue.rotation, factor);
            }

            if (AffectScale)
            {
                CurrentValue.localScale = Vector3.Lerp(CurrentValue.localScale, TargetValue.localScale, factor);
            }

            return CurrentValue;
        }
    }
}