using UnityEngine;

namespace EssentialUtils
{
    public class StickToWorldPosition : MonoBehaviour
    {
        [SerializeField] Transform target;
        [SerializeField] Camera targetCamera;
        [SerializeField] Vector3 worldPositionOffset;
        [SerializeField] bool showOffScreen;
        [SerializeField] float offScreenMargin = .1f;

        void Start()
        {
            if (targetCamera == null)
            {
                targetCamera = Camera.main;
            }
        }

        void Update()
        {
            var targetPosition = target.position + worldPositionOffset;
            var viewportPoint = targetCamera.WorldToViewportPoint(targetPosition);

            if (viewportPoint.z < 0)
            {
                viewportPoint.x = viewportPoint.x < 0.5 ? 2 : -1;
                viewportPoint.y = 1 - viewportPoint.y;
            }

            if (showOffScreen)
            {
                viewportPoint.x = Mathf.Clamp(viewportPoint.x, offScreenMargin, 1f - offScreenMargin);
                viewportPoint.y = Mathf.Clamp(viewportPoint.y, offScreenMargin, 1f - offScreenMargin);

                // Will stick to the vertical center of the screen when offscreen
                viewportPoint.y = viewportPoint.z.MapRange(0f, 10f, .5f, viewportPoint.y);
            }

            transform.position = new(viewportPoint.x * Screen.width, viewportPoint.y * Screen.height, 0f);
        }
    }
}