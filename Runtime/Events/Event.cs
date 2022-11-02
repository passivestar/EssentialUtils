using UnityEngine;

namespace EssentialUtils
{
    /*
        Add this to a new object if it's instantiated at runtime
    */

    public class Event : MonoBehaviour
    {
        void Awake() => Events.Instance.RegisterMonoBehaviour(this);
        void OnDestroy() => Events.Instance.UnregisterMonoBehaviour(this);
    }
}