using System;
using System.Collections.Generic;
using UnityEngine;

namespace EssentialUtils
{
    /*
        If you're using "SetActive" activation method you can use
        "OnEnable" and "OnDisable" on child objects to do things
        on entering/leaving state
    */

    public class ActivatorState
    {
        public ActivationMethod activationMethod = ActivationMethod.SetActive;

        public string InitialState { get; private set; }
        public string CurrentState { get; private set; }
        public GameObject GameObject { get; private set; }

        public event Action OnStateChange;

        Dictionary<string, GameObject> states = new();

        public ActivatorState(GameObject gameObject, string initialState = null,
            ActivationMethod activationMethod = ActivationMethod.SetActive,
            Action onStateChange = null)
        {
            GameObject = gameObject;
            this.activationMethod = activationMethod;
            OnStateChange = onStateChange;

            // Initialize:
            CurrentState = InitialState;
            GetCurrentObject().SetActive(true, activationMethod);
        }

        GameObject GetCurrentObject()
        {
            if (states.TryGetValue(CurrentState, out var gameObject))
            {
                return gameObject;
            }

            gameObject = GameObject.transform.Find(CurrentState)?.gameObject;
            if (gameObject == null)
            {
                Debug.LogError("Could not find GameObject with name " + CurrentState);
            }
            return gameObject;
        }

        void SetState(string state)
        {
            GetCurrentObject().SetActive(false, activationMethod);
            CurrentState = state;
            GetCurrentObject().SetActive(true, activationMethod);
        }
    }
}