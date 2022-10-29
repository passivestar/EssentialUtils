using UnityEngine;

namespace EssentialUtils
{
    public class TransitionMoveTowardsFloat : Transition
    {
        float currentValue;

        public void SetValue(float newValue) => currentValue = newValue;

        public float Run(float newValue, float speed = 1f, bool unscaledTime = false)
        {
            return currentValue = Mathf.MoveTowards(currentValue, newValue, speed * GetDelta(unscaledTime));
        }
    }

    public class TransitionMoveTowardsAngle : Transition
    {
        float currentValue;

        public void SetValue(float newValue) => currentValue = newValue;

        public float Run(float newValue, float speed = 1f, bool unscaledTime = false)
        {
            return currentValue = Mathf.MoveTowardsAngle(currentValue, newValue, speed * GetDelta(unscaledTime));
        }
    }

    public class TransitionMoveTowardsVector2 : Transition
    {
        Vector2 currentValue;

        public void SetValue(Vector2 newValue) => currentValue = newValue;

        public Vector2 Run(Vector2 newValue, float speed = 1f, bool unscaledTime = false)
        {
            return currentValue = Vector2.MoveTowards(currentValue, newValue, speed * GetDelta(unscaledTime));
        }
    }

    public class TransitionMoveTowardsVector3 : Transition
    {
        Vector3 currentValue;

        public void SetValue(Vector3 newValue) => currentValue = newValue;

        public Vector3 Run(Vector3 newValue, float speed = 1f, bool unscaledTime = false)
        {
            return currentValue = Vector3.MoveTowards(currentValue, newValue, speed * GetDelta(unscaledTime));
        }
    }

    public class TransitionMoveTowardsVector4 : Transition
    {
        Vector4 currentValue;

        public void SetValue(Vector4 newValue) => currentValue = newValue;

        public Vector4 Run(Vector4 newValue, float speed = 1f, bool unscaledTime = false)
        {
            return currentValue = Vector4.MoveTowards(currentValue, newValue, speed * GetDelta(unscaledTime));
        }
    }

    public class TransitionMoveTowardsQuaternion : Transition
    {
        Quaternion currentValue;

        public void SetValue(Quaternion newValue) => currentValue = newValue;

        public Quaternion Run(Quaternion newValue, float speed = 1f, bool unscaledTime = false)
        {
            return currentValue = Quaternion.RotateTowards(currentValue, newValue, speed * GetDelta(unscaledTime));
        }
    }

    public class TransitionMoveTowardsTransform : Transition
    {
        public bool affectPosition = true;
        public bool affectRotation = true;
        public bool affectScale = true;

        public Transform Run(Transform transform, Transform newValue, float speed = 1f, bool unscaledTime = false)
        {
            var factor = speed * GetDelta(unscaledTime);

            if (affectPosition)
                transform.position = Vector3.MoveTowards(transform.position, newValue.position, factor);

            if (affectRotation)
                transform.rotation = Quaternion.RotateTowards(transform.rotation, newValue.rotation, factor * Mathf.Rad2Deg);

            if (affectScale)
                transform.localScale = Vector3.MoveTowards(transform.localScale, newValue.localScale, factor);

            return transform;
        }
    }
}