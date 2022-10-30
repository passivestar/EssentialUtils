using System;
using UnityEngine;

namespace EssentialUtils
{
    public class VisibilityWatcher : IDisposable
    {
        public float MaxDistance { get; set; }
        public LayerMask LayerMask { get; set; } = ~0;

        public GameObject GameObject { get; private set; }
        public GameObject CameraGameObject { get; private set; }

        public bool IsClose { get; private set; }
        public bool IsVisible { get; private set; }
        public float CurrentDistance { get; private set; }

        public event Action OnBecameVisible;
        public event Action OnBecameInvisible;
        public event Action OnBecameClose;
        public event Action OnBecameDistant;

        bool wasClose;
        bool wasVisible;

        public VisibilityWatcher(GameObject gameObject, GameObject cameraGameObject = null, float maxDistance = 5f)
        {
            GameObject = gameObject;
            CameraGameObject = cameraGameObject ?? Camera.main.gameObject;
            MaxDistance = maxDistance;

            MonoBehaviourHelper.Instance.onUpdate += Update;
        }

        public void Dispose()
        {
            MonoBehaviourHelper.Instance.onUpdate -= Update;
        }

        bool RayCast()
        {
            var cameraPosition = CameraGameObject.transform.position;
            var objectPosition = GameObject.transform.position;

            if (Physics.Raycast(cameraPosition, objectPosition - cameraPosition,
                out var hit, Mathf.Infinity, LayerMask, QueryTriggerInteraction.Collide))
            {
                if (hit.collider.gameObject == GameObject)
                {
                    return true;
                }
            }

            return false;
        }

        void Update()
        {
            CurrentDistance = Vector3.Distance(GameObject.transform.position, CameraGameObject.transform.position);
            IsClose = CurrentDistance < MaxDistance;
            IsVisible = RayCast();

            if (IsClose && !wasClose)
            {
                OnBecameClose?.Invoke();
                wasClose = IsClose;
            }
            else if (!IsClose && wasClose)
            {
                OnBecameDistant?.Invoke();
                wasClose = IsClose;
            }

            if (IsVisible && !wasVisible)
            {
                OnBecameVisible?.Invoke();
                wasVisible = IsVisible;
            }
            else if (!IsVisible && wasVisible)
            {
                OnBecameInvisible?.Invoke();
                wasVisible = IsVisible;
            }
        }
    }
}