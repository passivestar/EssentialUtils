using UnityEngine;

namespace EssentialUtils
{
    public class Singleton<T> : MonoBehaviourWithGlobalInstance<T> where T : MonoBehaviour
    {
        protected virtual void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
                return;
            }
            instance = this as T;
        }
    }
}