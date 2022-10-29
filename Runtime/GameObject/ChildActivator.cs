using System;
using UnityEngine;

namespace EssentialUtils
{
    public class ChildActivator
    {
        public enum ActivationMethod
        {
            SetActive,
            SendMessage
        }

        public enum ActivationMode
        {
            Normal,
            Additive
        }

        public ActivationMethod activationMethod = ActivationMethod.SetActive;
        public ActivationMode activationMode = ActivationMode.Normal;

        public bool Loop { get; set; }

        public int InitialIndex { get; private set; }
        public int CurrentIndex { get; private set; }
        public GameObject GameObject { get; private set; }
        public Action OnCycle { get; set; }

        public ChildActivator(GameObject gameObject, int initialIndex = 0,
            bool loop = true, Action onCycle = null,
            ActivationMethod activationMethod = ActivationMethod.SetActive,
            ActivationMode activationMode = ActivationMode.Normal)
        {
            GameObject = gameObject;
            InitialIndex = initialIndex;
            Loop = loop;
            this.activationMethod = activationMethod;
            this.activationMode = activationMode;
            OnCycle = onCycle;

            // Initialize:
            CurrentIndex = InitialIndex;
            Clear();
            SetActive(GetCurrentObject(), true);
        }

        public void Next() => Process(false);
        public void Previous() => Process(true);

        void Process(bool previous)
        {
            if (activationMode == ActivationMode.Normal)
            {
                SetActive(GetCurrentObject(), false);
            }

            if (previous)
            {
                CurrentIndex = Loop
                    ? Math.Mod((int)CurrentIndex - 1, GameObject.transform.childCount)
                    : CurrentIndex--;
            }
            else
            {
                CurrentIndex = Loop
                    ? (CurrentIndex + 1) % GameObject.transform.childCount
                    : CurrentIndex++;
            }

            if (Loop && CurrentIndex == 0)
            {
                Clear();
                OnCycle?.Invoke();
            }

            SetActive(GetCurrentObject(), true);
        }

        GameObject GetCurrentObject()
        {
            return GameObject.transform.GetChild(CurrentIndex).gameObject;
        }

        void SetActive(GameObject gameObject, bool active)
        {
            if (activationMethod == ActivationMethod.SetActive)
            {
                gameObject.SetActive(active);
            }
            else
            {
                gameObject.SendMessage(active ? "Activate" : "Deactivate", SendMessageOptions.DontRequireReceiver);
            }
        }

        void Clear()
        {
            foreach (Transform child in GameObject.transform)
            {
                if (activationMethod == ActivationMethod.SetActive)
                {
                    child.gameObject.SetActive(false);
                }
                else
                {
                    child.gameObject.SendMessage("Deactivate", SendMessageOptions.DontRequireReceiver);
                }
            }
        }
    }
}