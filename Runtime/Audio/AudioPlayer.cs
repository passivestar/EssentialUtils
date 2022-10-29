using UnityEngine;

namespace EssentialUtils
{
    public class AudioPlayer : MonoBehaviour
    {
        public bool UnscaledTime { get; set; }

        bool active;
        bool reverse = true;
        float crossfadeDuration;
        float crossfadeElapsed;

        AudioSource sourceA;
        AudioSource sourceB;
        float sourceAVolume = 1f;
        float sourceBVolume = 1f;

        static AudioPlayer instance = null;

        public static AudioPlayer Instance
        {
            get
            {
                if (instance != null)
                {
                    return instance;
                }
                var gameObject = new GameObject();
                gameObject.name = "EssentialUtils_AudioPlayer";
                instance = gameObject.AddComponent<AudioPlayer>();
                DontDestroyOnLoad(gameObject);
                return instance;
            }
        }

        void Awake()
        {
            sourceA = gameObject.AddComponent<AudioSource>();
            sourceB = gameObject.AddComponent<AudioSource>();
            sourceA.volume = 0;
            sourceB.volume = 0;
        }

        void Update()
        {
            if (!active)
            {
                return;
            }

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

            sourceA.volume = sourceAVolume * elapsedRatio;
            sourceB.volume = sourceBVolume * remainingRatio;

            if (reverse && crossfadeElapsed <= 0)
            {
                sourceA.Stop();
                active = false;
            }
            else if (!reverse && crossfadeElapsed >= crossfadeDuration)
            {
                sourceB.Stop();
                active = false;
            }
        }

        public void Play(AudioClip clip, float volume = 1f, float pitchMin = .9f, float pitchMax = 1.1f,
            float crossfadeTime = 3f, bool loop = true) 
        {
            reverse = !reverse;

            crossfadeDuration = crossfadeTime;

            AudioSource source;
            if (reverse)
            {
                source = sourceB;
                sourceBVolume = volume;
            }
            else
            {
                source = sourceA;
                sourceAVolume = volume;
            }

            source.clip = clip;
            source.pitch = UnityEngine.Random.Range(pitchMin, pitchMax);
            source.loop = loop;

            source.Play();

            if (crossfadeTime > 0)
            {
                active = true;
            }
            else
            {
                source.volume = volume;
                (reverse ? sourceA : sourceB).Stop();
            }
        }

        public void PlayOneShot(AudioClip clip, float volume, float pitchMin = .9f, float pitchMax = 1.1f)
        {
            sourceA.volume = volume;
            sourceA.pitch = UnityEngine.Random.Range(pitchMin, pitchMax);
            sourceA.PlayOneShot(clip);
        }

        public static void PlayGlobal(AudioClip clip, float volume, float pitchMin = .9f, float pitchMax = 1.1f,
            float crossfadeTime = 3f, bool loop = false)
        {
            Instance.Play(clip, volume, pitchMin, pitchMax, crossfadeTime, loop);
        }

        public static void PlayAtPointGlobal(AudioClip clip, float volume, float pitchMin = .9f, float pitchMax = 1.1f,
            float distanceMin = 1f, float distanceMax = 10f, Vector3 point = new Vector3())
        {
            var gameObject = new GameObject();
            gameObject.name = "EssentialUtils_AudioPlayerAtPoint";
            var source = gameObject.AddComponent<AudioSource>();
            gameObject.transform.position = point;
            source.spatialBlend = 1f;
            var pitch = UnityEngine.Random.Range(pitchMin, pitchMax);
            source.pitch = pitch;
            source.minDistance = distanceMin;
            source.maxDistance = distanceMax;
            source.PlayOneShot(clip, volume);
            Destroy(gameObject, clip.length / pitch);
        }

        public static void PlayOneShotGlobal(AudioClip clip, float volume, float pitchMin = .9f, float pitchMax = 1.1f)
        {
            Instance.PlayOneShot(clip, volume, pitchMin, pitchMax);
        }
    }
}