using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

namespace EssentialUtils
{
    /*
        A wrapper class that allows completion state tracking
    */

    public class Coroutine : CustomYieldInstruction
    {
        public IEnumerator Enumerator { get; private set; }

        public bool IsFinished { get; private set; }

        Action onFinishedAction;

        public event Action onFinished
        {
            add
            {
                if (IsFinished)
                {
                    value?.Invoke();
                }
                else
                {
                    onFinishedAction += value;
                }
            }
            remove
            {
                onFinishedAction -= value;
            }
        }

        public override bool keepWaiting => !IsFinished;

        public Coroutine(IEnumerator enumerator = null)
        {
            if (enumerator != null)
            {
                Enumerator = enumerator;
            }
        }

        public void Finish()
        {
            IsFinished = true;
            onFinishedAction?.Invoke();
        }

        public static Coroutine Run(IEnumerator enumerator)
        {
            var coroutine = new Coroutine(enumerator);
            MonoBehaviourHelper.Instance.RunCoroutine(coroutine, () => coroutine.Finish());
            return coroutine;
        }

        public static Coroutine WaitForSeconds(float seconds)
        {
            return Run(WaitForSecondsCoroutine(seconds));
        }

        static IEnumerator WaitForSecondsCoroutine(float seconds)
        {
            yield return new WaitForSeconds(seconds);
        }

        public static Coroutine WaitForSecondsRealtime(float seconds)
        {
            return Run(WaitForSecondsRealtimeCoroutine(seconds));
        }

        static IEnumerator WaitForSecondsRealtimeCoroutine(float seconds)
        {
            yield return new WaitForSecondsRealtime(seconds);
        }

        public static Coroutine WhenAny(Coroutine[] coroutines)
        {
            return Run(WhenAnyCoroutine(coroutines));
        }

        static IEnumerator WhenAnyCoroutine(Coroutine[] coroutines)
        {
            while (coroutines.Any(coroutine => coroutine.IsFinished))
            {
                yield return null;
            }
        }

        public static Coroutine WhenAll(Coroutine[] coroutines)
        {
            return Run(WhenAllCoroutine(coroutines));
        }

        static IEnumerator WhenAllCoroutine(Coroutine[] coroutines)
        {
            while (coroutines.Any(coroutine => !coroutine.IsFinished))
            {
                yield return null;
            }
        }

        public static Coroutine WaitWhile(Func<bool> func)
        {
            return Run(WaitWhileCoroutine(func));
        }

        static IEnumerator WaitWhileCoroutine(Func<bool> func)
        {
            while (func.Invoke())
            {
                yield return null;
            }
        }

        public static Coroutine WaitUntil(Func<bool> func)
        {
            return Run(WaitUntilCoroutine(func));
        }

        static IEnumerator WaitUntilCoroutine(Func<bool> func)
        {
            while (!func.Invoke())
            {
                yield return null;
            }
        }

        public static Coroutine WaitForWebRequest(string url, string method)
        {
            return Run(WaitForWebRequestCoroutine(url, method));
        }

        static IEnumerator WaitForWebRequestCoroutine(string url, string method)
        {
            var request = new UnityWebRequest(url, method);
            request.downloadHandler = new DownloadHandlerBuffer();
            yield return request.SendWebRequest();
        }

        public static Coroutine WaitForUnityEvent<T>(UnityEvent<T> unityEvent)
        {
            return Run(WaitForUnityEventCoroutine(unityEvent));
        }

        static IEnumerator WaitForUnityEventCoroutine<T>(UnityEvent<T> unityEvent)
        {
            var coroutine = new Coroutine();
            var listener = new UnityAction<T>(_ => coroutine.Finish());
            unityEvent.AddListener(listener);
            yield return coroutine;
            unityEvent.RemoveListener(listener);
        }
    }
}