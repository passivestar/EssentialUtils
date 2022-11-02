using System;
using System.Collections.Generic;
using UnityEngine;

namespace EssentialUtils
{
    public class Events : MonoBehaviour
    {
        static Events instance = null;

        public static Events Instance
        {
            get
            {
                if (instance != null)
                {
                    return instance;
                }
                var gameObject = new GameObject();
                gameObject.name = "EssentialUtils_Events";
                instance = gameObject.AddComponent<Events>();
                DontDestroyOnLoad(gameObject);
                return instance;
            }
        }

        Dictionary<string, List<Action>> actionsByEventName = new();
        Dictionary<MonoBehaviour, List<Action>> actionsByMonoBehaviour = new();

        void Awake()
        {
            foreach (var mb in FindObjectsOfType<MonoBehaviour>(true))
            {
                RegisterMonoBehaviour(mb);
            }
        }

        void OnDestroy()
        {
            foreach (var mb in FindObjectsOfType<MonoBehaviour>(true))
            {
                UnregisterMonoBehaviour(mb);
            }
        }

        public void RegisterMonoBehaviour(MonoBehaviour mb)
        {
            var methods = mb.GetType().GetMethods();
            foreach (var method in methods)
            {
                var attributes = Attribute.GetCustomAttributes(method, typeof(EventListenerAttribute));
                foreach (EventListenerAttribute attribute in attributes)
                {
                    if (attribute == null)
                    {
                        continue;
                    }

                    Action action = () => method?.Invoke(mb, null);

                    if (!actionsByMonoBehaviour.ContainsKey(mb))
                    {
                        actionsByMonoBehaviour[mb] = new();
                    }

                    var actions = actionsByMonoBehaviour[mb];

                    if (!actions.Contains(action))
                    {
                        actions.Add(action);
                    }

                    On(attribute.EventName ?? method.Name, action);
                }
            }
        }

        public void UnregisterMonoBehaviour(MonoBehaviour mb)
        {
            var methods = mb.GetType().GetMethods();
            foreach (var method in methods)
            {
                var attributes = Attribute.GetCustomAttributes(method, typeof(EventListenerAttribute));
                foreach (EventListenerAttribute attribute in attributes)
                {
                    if (attribute == null)
                    {
                        continue;
                    }

                    var actions = actionsByMonoBehaviour[mb];
                    if (actions != null)
                    {
                        foreach (var action in actions)
                        {
                            Off(attribute.EventName ?? method.Name, action);
                        }
                        actionsByMonoBehaviour.Remove(mb);
                    }
                }
            }
        }

        public void On(string eventName, Action action)
        {
            if (!actionsByEventName.ContainsKey(eventName))
            {
                actionsByEventName[eventName] = new();
            }

            var actions = actionsByEventName[eventName];

            if (!actions.Contains(action))
            {
                actions.Add(action);
            }
        }

        public void Off(string eventName, Action action)
        {
            actionsByEventName[eventName].Remove(action);
        }

        public void Emit(string eventName)
        {
            if (actionsByEventName.ContainsKey(eventName))
            {
                foreach (var listener in actionsByEventName[eventName])
                {
                    listener?.Invoke();
                }
            }
        }
    }
}