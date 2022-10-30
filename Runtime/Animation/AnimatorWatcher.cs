using System;
using System.Collections.Generic;
using UnityEngine;

namespace EssentialUtils
{
    public class AnimatorWatcher : MonoBehaviour
    {
        public class ClipEvents
        {
            public Action OnClipStarted;
            public Action OnClipEnded;
        }

        public Dictionary<string, ClipEvents> clips = new();

        Animator animator;

        void Awake()
        {
            animator = GetComponent<Animator>();

            foreach (var clip in animator.runtimeAnimatorController.animationClips)
            {
                var animationStartEvent = new AnimationEvent();
                animationStartEvent.time = 0;
                animationStartEvent.functionName = "ClipStart";
                animationStartEvent.stringParameter = clip.name;

                var animationEndEvent = new AnimationEvent();
                animationEndEvent.time = clip.length;
                animationEndEvent.functionName = "ClipEnd";
                animationEndEvent.stringParameter = clip.name;

                clips.Add(clip.name, new());

                clip.AddEvent(animationStartEvent);
                clip.AddEvent(animationEndEvent);
            }
        }

        public ClipEvents GetClipEvents(string name)
        {
            return clips.GetValueOrDefault(name);
        }

        public void ClipStart(string name)
        {
            if (clips.TryGetValue(name, out var clipEvents))
            {
                clipEvents.OnClipStarted?.Invoke();
            }
        }

        public void ClipEnd(string name)
        {
            if (clips.TryGetValue(name, out var clipEvents))
            {
                clipEvents.OnClipEnded?.Invoke();
            }
        }
    }
}