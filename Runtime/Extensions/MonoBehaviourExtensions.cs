using System;
using UnityEngine;

namespace EssentialUtils
{
    public static class MonoBehaviourExtensions
    { 
        public static void OnStart(this MonoBehaviour monoBehaviour, Action action)
        {
            MonoBehaviourHelper.OnGameObject(monoBehaviour.gameObject).onStart += action;
        }

        public static void OnUpdate(this MonoBehaviour monoBehaviour, Action action)
        {
            MonoBehaviourHelper.OnGameObject(monoBehaviour.gameObject).onUpdate += action;
        }

        public static void OnFixedUpdate(this MonoBehaviour monoBehaviour, Action action)
        {
            MonoBehaviourHelper.OnGameObject(monoBehaviour.gameObject).onFixedUpdate += action;
        }

        public static void OnLateUpdate(this MonoBehaviour monoBehaviour, Action action)
        {
            MonoBehaviourHelper.OnGameObject(monoBehaviour.gameObject).onLateUpdate += action;
        }

        public static void OnEnable(this MonoBehaviour monoBehaviour, Action action)
        {
            MonoBehaviourHelper.OnGameObject(monoBehaviour.gameObject).onEnable += action;
        }

        public static void OnDisable(this MonoBehaviour monoBehaviour, Action action)
        {
            MonoBehaviourHelper.OnGameObject(monoBehaviour.gameObject).onDisable += action;
        }

        public static void OnGUI(this MonoBehaviour monoBehaviour, Action action)
        {
            MonoBehaviourHelper.OnGameObject(monoBehaviour.gameObject).onGUI += action;
        }

        public static void OnDrawGizmos(this MonoBehaviour monoBehaviour, Action action)
        {
            MonoBehaviourHelper.OnGameObject(monoBehaviour.gameObject).onDrawGizmos += action;
        }

        public static void OnDrawGizmosSelected(this MonoBehaviour monoBehaviour, Action action)
        {
            MonoBehaviourHelper.OnGameObject(monoBehaviour.gameObject).onDrawGizmosSelected += action;
        }

        public static void OnCollisionEnter(this MonoBehaviour monoBehaviour, Action<Collision> action)
        {
            MonoBehaviourHelper.OnGameObject(monoBehaviour.gameObject).onCollisionEnter += action;
        }

        public static void OnCollisionExit(this MonoBehaviour monoBehaviour, Action<Collision> action)
        {
            MonoBehaviourHelper.OnGameObject(monoBehaviour.gameObject).onCollisionExit += action;
        }

        public static void OnCollisionStay(this MonoBehaviour monoBehaviour, Action<Collision> action)
        {
            MonoBehaviourHelper.OnGameObject(monoBehaviour.gameObject).onCollisionStay += action;
        }

        public static void OnTriggerEnter(this MonoBehaviour monoBehaviour, Action<Collider> action)
        {
            MonoBehaviourHelper.OnGameObject(monoBehaviour.gameObject).onTriggerEnter += action;
        }

        public static void OnTriggerExit(this MonoBehaviour monoBehaviour, Action<Collider> action)
        {
            MonoBehaviourHelper.OnGameObject(monoBehaviour.gameObject).onTriggerExit += action;
        }

        public static void OnTriggerStay(this MonoBehaviour monoBehaviour, Action<Collider> action)
        {
            MonoBehaviourHelper.OnGameObject(monoBehaviour.gameObject).onTriggerStay += action;
        }
    }
}