using UnityEngine;

namespace EssentialUtils
{
    public abstract class Transition
    {
        public float GetDelta(bool unscaledTime)
        {
            return unscaledTime ? Time.unscaledDeltaTime : Time.deltaTime;
        }
    }
}