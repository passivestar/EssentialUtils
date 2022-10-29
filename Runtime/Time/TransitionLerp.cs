using UnityEngine;

namespace EssentialUtils
{
    public class TransitionLerpFloat : Transition
    {
        float currentValue;

        public void SetValue(float newValue) => currentValue = newValue;

        public float Run(float newValue, float speed = 1f, bool unscaledTime = false)
        {
            return currentValue = Mathf.Lerp(currentValue, newValue, speed * GetDelta(unscaledTime));
        }
    }

    public class TransitionLerpAngle : Transition
    {
        float currentValue;

        public void SetValue(float newValue) => currentValue = newValue;

        public float Run(float newValue, float speed = 1f, bool unscaledTime = false)
        {
            return currentValue = Mathf.LerpAngle(currentValue, newValue, speed * GetDelta(unscaledTime));
        }
    }

    public class TransitionLerpColor : Transition
    {
        Color currentValue;

        public void SetValue(Color newValue) => currentValue = newValue;

        public Color Run(Color newValue, float speed = 1f, bool unscaledTime = false)
        {
            return currentValue = Color.Lerp(currentValue, newValue, speed * GetDelta(unscaledTime));
        }
    }

    public class TransitionLerpVector2 : Transition
    {
        Vector2 currentValue;

        public void SetValue(Vector2 newValue) => currentValue = newValue;

        public Vector2 Run(Vector2 newValue, float speed = 1f, bool unscaledTime = false)
        {
            return currentValue = Vector2.Lerp(currentValue, newValue, speed * GetDelta(unscaledTime));
        }
    }

    public class TransitionLerpVector3 : Transition
    {
        Vector3 currentValue;

        public void SetValue(Vector3 newValue) => currentValue = newValue;

        public Vector3 Run(Vector3 newValue, float speed = 1f, bool unscaledTime = false)
        {
            return currentValue = Vector3.Lerp(currentValue, newValue, speed * GetDelta(unscaledTime));
        }
    }

    public class TransitionLerpVector4 : Transition
    {
        Vector4 currentValue;

        public void SetValue(Vector4 newValue) => currentValue = newValue;

        public Vector4 Run(Vector4 newValue, float speed = 1f, bool unscaledTime = false)
        {
            return currentValue = Vector4.Lerp(currentValue, newValue, speed * GetDelta(unscaledTime));
        }
    }

    public class TransitionSlerpQuaternion : Transition
    {
        Quaternion currentValue;

        public void SetValue(Quaternion newValue) => currentValue = newValue;

        public Quaternion Run(Quaternion newValue, float speed = 1f, bool unscaledTime = false)
        {
            return currentValue = Quaternion.Slerp(currentValue, newValue, speed * GetDelta(unscaledTime));
        }
    }

    public class TransitionLerpTransform : Transition
    {
        public bool affectPosition = true;
        public bool affectRotation = true;
        public bool affectScale = true;

        public Transform Run(Transform transform, Transform newValue, float speed = 1f, bool unscaledTime = false)
        {
            var factor = speed * GetDelta(unscaledTime);

            if (affectPosition)
                transform.position = Vector3.Lerp(transform.position, newValue.position, factor);

            if (affectRotation)
                transform.rotation = Quaternion.Slerp(transform.rotation, newValue.rotation, factor);

            if (affectScale)
                transform.localScale = Vector3.Lerp(transform.localScale, newValue.localScale, factor);

            return transform;
        }
    }
}