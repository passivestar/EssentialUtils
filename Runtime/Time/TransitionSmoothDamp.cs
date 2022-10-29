using UnityEngine;

namespace EssentialUtils
{
    public class TransitionSmoothDampFloat : Transition
    {
        float currentValue;
        float currentVelocity;

        public void SetValue(float newValue) => currentValue = newValue;

        public float Evaluate(float newValue, float smoothTime = .5f, float maxSpeed = 1000f)
        {
            return currentValue = Mathf.SmoothDamp(currentValue, newValue, ref currentVelocity, smoothTime, maxSpeed);
        }
    }

    public class TransitionSmoothDampAngle : Transition
    {
        float currentValue;
        float currentVelocity;

        public void SetValue(float newValue) => currentValue = newValue;

        public float Evaluate(float newValue, float smoothTime = .5f, float maxSpeed = 1000f)
        {
            return currentValue = Mathf.SmoothDampAngle(currentValue, newValue, ref currentVelocity, smoothTime, maxSpeed);
        }
    }

    public class TransitionSmoothDampVector2 : Transition
    {
        Vector2 currentValue;
        Vector2 currentVelocity;

        public void SetValue(Vector2 newValue) => currentValue = newValue;

        public Vector2 Evaluate(Vector2 newValue, float smoothTime = .5f, float maxSpeed = 1000f)
        {
            return currentValue = Vector2.SmoothDamp(currentValue, newValue, ref currentVelocity, smoothTime, maxSpeed);
        }
    }

    public class TransitionSmoothDampVector3 : Transition
    {
        Vector3 currentValue;
        Vector3 currentVelocity;

        public void SetValue(Vector3 newValue) => currentValue = newValue;

        public Vector3 Evaluate(Vector3 newValue, float smoothTime = .5f, float maxSpeed = 1000f)
        {
            return currentValue = Vector3.SmoothDamp(currentValue, newValue, ref currentVelocity, smoothTime, maxSpeed);
        }
    }
}