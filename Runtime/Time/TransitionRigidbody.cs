using UnityEngine;

namespace EssentialUtils
{
    public class TransitionRigidbody
    {
        public float MovementSpeed { get; set; }
        public float RotationSpeed { get; set; }
        public bool AffectPosition { get; set; }
        public bool AffectRotation { get; set; }

        public TransitionRigidbody(float movementSpeed = 5f, float rotationSpeed = .1f,
            bool affectPosition = true, bool affectRotation = true)
        {
            MovementSpeed = movementSpeed;
            RotationSpeed = rotationSpeed;
            AffectPosition = affectPosition;
            AffectRotation = affectRotation;
        }

        public void Run(Rigidbody rigidbody, Vector3 newPosition, Quaternion newRotation)
        {
            if (AffectPosition)
            {
                var directionToNewPosition = newPosition - rigidbody.transform.position;
                rigidbody.velocity = directionToNewPosition * MovementSpeed;
            }

            if (AffectRotation)
            {
                var rotationDifference = newRotation * Quaternion.Inverse(rigidbody.transform.rotation);
                rigidbody.angularVelocity = rotationDifference.ExtractEulers() * RotationSpeed;
            }
        }
    }
}