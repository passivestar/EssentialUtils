using UnityEngine;

namespace EssentialUtils
{
    public class MonoBehaviourWithGlobalInstance<T> : MonoBehaviour where T : MonoBehaviour
    {
        protected static T instance = null;

        public static T Instance
        {
            get
            {
                if (instance != null)
                {
                    return instance;
                }
                var gameObject = new GameObject();
                gameObject.name = $"EssentialUtils_{typeof(T).Name}";
                instance = gameObject.AddComponent<T>();
                DontDestroyOnLoad(gameObject);
                return instance;
            }
        }
    }
}