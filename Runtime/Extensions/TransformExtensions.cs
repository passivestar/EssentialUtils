using UnityEngine;

namespace EssentialUtils
{
    public static class TransformExtensions
    {
        public static void SetPositionX(this Transform transform, float value)
        {
            var position = transform.position;
            position.x = value;
            transform.position = position;
        }

        public static void SetPositionY(this Transform transform, float value)
        {
            var position = transform.position;
            position.y = value;
            transform.position = position;
        }

        public static void SetPositionZ(this Transform transform, float value)
        {
            var position = transform.position;
            position.z = value;
            transform.position = position;
        }

        public static void SetLocalPositionX(this Transform transform, float value)
        {
            var position = transform.localPosition;
            position.x = value;
            transform.localPosition = position;
        }

        public static void SetLocalPositionY(this Transform transform, float value)
        {
            var position = transform.localPosition;
            position.y = value;
            transform.localPosition = position;
        }

        public static void SetLocalPositionZ(this Transform transform, float value)
        {
            var position = transform.localPosition;
            position.z = value;
            transform.localPosition = position;
        }

        public static void SetRotationX(this Transform transform, float value)
        {
            var angles = transform.rotation.eulerAngles;
            transform.rotation = Quaternion.Euler(value, angles.y, angles.z);
        }

        public static void SetRotationY(this Transform transform, float value)
        {
            var angles = transform.rotation.eulerAngles;
            transform.rotation = Quaternion.Euler(angles.x, value, angles.z);
        }

        public static void SetRotationZ(this Transform transform, float value)
        {
            var angles = transform.rotation.eulerAngles;
            transform.rotation = Quaternion.Euler(angles.x, angles.y, value);
        }

        public static void SetLocalRotationX(this Transform transform, float value)
        {
            var angles = transform.localRotation.eulerAngles;
            transform.localRotation = Quaternion.Euler(value, angles.y, angles.z);
        }

        public static void SetLocalRotationY(this Transform transform, float value)
        {
            var angles = transform.localRotation.eulerAngles;
            transform.localRotation = Quaternion.Euler(angles.x, value, angles.z);
        }

        public static void SetLocalRotationZ(this Transform transform, float value)
        {
            var angles = transform.localRotation.eulerAngles;
            transform.localRotation = Quaternion.Euler(angles.x, angles.y, value);
        }

        public static void SetLocalScaleX(this Transform transform, float value)
        {
            var localScale = transform.localScale;
            localScale.x = value;
            transform.localScale = localScale;
        }

        public static void SetLocalScaleY(this Transform transform, float value)
        {
            var localScale = transform.localScale;
            localScale.y = value;
            transform.localScale = localScale;
        }

        public static void SetLocalScaleZ(this Transform transform, float value)
        {
            var localScale = transform.localScale;
            localScale.z = value;
            transform.localScale = localScale;
        }

        public static void SetUniformScale(this Transform transform, float value)
        {
            var localScale = transform.localScale;
            localScale.x = localScale.y = localScale.z = value;
            transform.localScale = localScale;
        }

        public static void Clear(this Transform transform)
        {
            foreach (Transform child in transform)
            {
                Object.Destroy(child.gameObject);
            }
        }
    }
}