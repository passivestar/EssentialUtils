using System;
using System.Collections.Generic;
using UnityEngine;

namespace EssentialUtils
{
    public class ObjectsInTrigger : IDisposable
    {
        // TODO: Allow changing target after instance is created
        public GameObject GameObject { get; private set; }
        public List<GameObject> GameObjects { get; private set; } = new();
        public List<Collider> Colliders { get; private set; } = new();
        public int Count => GameObjects.Count;

        public ObjectsInTrigger(GameObject gameObject)
        {
            GameObject = gameObject;
            MonoBehaviourHelper.OnGameObject(GameObject).onTriggerEnter += Enter;
            MonoBehaviourHelper.OnGameObject(GameObject).onTriggerExit += Exit;
        }

        public void Dispose()
        {
            MonoBehaviourHelper.OnGameObject(GameObject).onTriggerEnter -= Enter;
            MonoBehaviourHelper.OnGameObject(GameObject).onTriggerExit -= Exit;
        }

        public void Enter(Collider collider)
        {
            Colliders.Add(collider);
            GameObjects.Add(collider.gameObject);
        }

        public void Exit(Collider collider)
        {
            Colliders.Remove(collider);
            GameObjects.Remove(collider.gameObject);
        }
    }
}