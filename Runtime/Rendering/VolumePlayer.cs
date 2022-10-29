#if USE_SRP
using UnityEngine;
using UnityEngine.Rendering;

namespace EssentialUtils
{
    public class VolumePlayer : MonoBehaviour
    {
        public bool UnscaledTime { get; set; }

        bool active;
        bool reverse = true;
        float crossfadeDuration;
        float crossfadeElapsed;

        Volume volumeA;
        Volume volumeB;
        float volumeAWeight = 1f;
        float volumeBWeight = 1f;

        static VolumePlayer instance = null;

        public static VolumePlayer Instance
        {
            get
            {
                if (instance != null)
                {
                    return instance;
                }
                var gameObject = new GameObject();
                gameObject.name = "EssentialUtils_VolumePlayer";
                instance = gameObject.AddComponent<VolumePlayer>();
                DontDestroyOnLoad(gameObject);
                return instance;
            }
        }

        void Awake()
        {
            volumeA = gameObject.AddComponent<Volume>();
            volumeB = gameObject.AddComponent<Volume>();
            volumeA.weight = 0;
            volumeB.weight = 0;
        }

        void Update()
        {
            if (!active) return;

            var delta = UnscaledTime ? Time.unscaledDeltaTime : Time.deltaTime;

            if (reverse)
            {
                crossfadeElapsed -= delta;
                crossfadeElapsed = Mathf.Max(crossfadeElapsed, 0);
            }
            else
            {
                crossfadeElapsed += delta;
                crossfadeElapsed = Mathf.Min(crossfadeElapsed, crossfadeDuration);
            }

            var elapsedRatio = Mathf.Clamp01(crossfadeElapsed / crossfadeDuration);
            var remainingRatio = 1f - elapsedRatio;

            volumeA.weight = volumeAWeight * elapsedRatio;
            volumeB.weight = volumeBWeight * remainingRatio;

            if (reverse && crossfadeElapsed <= 0 || !reverse && crossfadeElapsed >= crossfadeDuration)
            {
                active = false;
            }
        }

        public void Set(VolumeProfile profile, float weight = 1f, float crossfadeTime = 3f)
        {
            reverse = !reverse;

            crossfadeDuration = crossfadeTime;

            Volume volume;
            if (reverse)
            {
                volume = volumeB;
                volumeBWeight = weight;
            }
            else
            {
                volume = volumeA;
                volumeAWeight = weight;
            }

            volume.profile = profile;

            if (crossfadeTime > 0)
            {
                active = true;
            }
            else
            {
                volume.weight = weight;
            }
        }

        public static void SetGlobal(VolumeProfile profile, float weight = 1f, float crossfadeTime = 3f)
        {
            Instance.Set(profile, weight, crossfadeTime);
        }
    }
}
#endif