using System;
using System.Collections;
using UnityEngine;

namespace EssentialUtils
{
    /*
        A helper class to make use of MonoBehaviour events
        and methods like StartCoroutine. Can be used globally to hook into
        update events or added to game objects to listen to their
        collision events
    */

    public class MonoBehaviourHelper : MonoBehaviourWithGlobalInstance<MonoBehaviourHelper>
    {
        public event Action onAwake, onStart, onUpdate, onFixedUpdate, onLateUpdate, onEnable, onDisable,
            onGUI, onDrawGizmos, onDrawGizmosSelected;

        public event Action<Collision> onCollisionEnter, onCollisionExit, onCollisionStay;
        public event Action<Collider> onTriggerEnter, onTriggerExit, onTriggerStay;

        public static MonoBehaviourHelper OnGameObject(GameObject gameObject)
        {
            var component = gameObject.GetComponent<MonoBehaviourHelper>();
            if (component != null)
            {
                return component;
            }
            return gameObject.AddComponent<MonoBehaviourHelper>();
        }

        void Awake() => onAwake?.Invoke();
        void Start() => onStart?.Invoke();
        void Update() => onUpdate?.Invoke();
        void FixedUpdate() => onFixedUpdate?.Invoke();
        void LateUpdate() => onLateUpdate?.Invoke();
        void OnEnable() => onEnable?.Invoke();
        void OnDisable() => onDisable?.Invoke();
        void OnGUI() => onGUI?.Invoke();

        void OnDrawGizmos() => onDrawGizmos?.Invoke();
        void OnDrawGizmosSelected() => onDrawGizmosSelected?.Invoke();

        void OnCollisionEnter(Collision collision) => onCollisionEnter?.Invoke(collision);
        void OnCollisionExit(Collision collision) => onCollisionExit?.Invoke(collision);
        void OnCollisionStay(Collision collision) => onCollisionStay?.Invoke(collision);

        void OnTriggerEnter(Collider collider) => onTriggerEnter?.Invoke(collider);
        void OnTriggerExit(Collider collider) => onTriggerExit?.Invoke(collider);
        void OnTriggerStay(Collider collider) => onTriggerStay?.Invoke(collider);

        public void RunCoroutine(Coroutine coroutine, Action onFinished = null)
        {
            StartCoroutine(RunCoroutineCoroutine(coroutine.Enumerator, onFinished));
        }

        IEnumerator RunCoroutineCoroutine(IEnumerator coroutine, Action onFinished = null)
        {
            yield return coroutine;
            onFinished?.Invoke();
        }
    }
}