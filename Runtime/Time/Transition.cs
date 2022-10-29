using UnityEngine;

namespace EssentialUtils
{
    public abstract class Transition
    {
        public bool UnscaledTime { get; set; }

        public float GetDelta()
        {
            return UnscaledTime ? Time.unscaledDeltaTime : Time.deltaTime;
        }
    }
}