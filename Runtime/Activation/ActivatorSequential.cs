using System;
using UnityEngine;

namespace EssentialUtils
{
    public class ActivatorSequential
    {
        public enum ActivationMode
        {
            Normal,
            Additive
        }

        public ActivationMethod activationMethod = ActivationMethod.SetActive;
        public ActivationMode activationMode = ActivationMode.Normal;

        public Action ActionNext { get; private set; }
        public Action ActionPrevious { get; private set; }

        public bool Loop { get; set; }

        public int InitialIndex { get; private set; }
        public int CurrentIndex { get; private set; }
        public GameObject GameObject { get; private set; }
        public event Action OnCycle;

        public ActivatorSequential(GameObject gameObject, int initialIndex = 0,
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
            GetCurrentObject().SetActive(true, activationMethod);

            ActionNext = () => Next();
            ActionPrevious = () => Previous();
        }

        public void Next() => Process(false);
        public void Previous() => Process(true);

        void Process(bool previous)
        {
            if (activationMode == ActivationMode.Normal)
            {
                GetCurrentObject().SetActive(false, activationMethod);
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
                if (activationMode == ActivationMode.Additive)
                {
                    Clear();
                }
                OnCycle?.Invoke();
            }

            GetCurrentObject().SetActive(true, activationMethod);
        }

        GameObject GetCurrentObject()
        {
            return GameObject.transform.GetChild(CurrentIndex).gameObject;
        }

        void Clear()
        {
            foreach (Transform child in GameObject.transform)
            {
                child.gameObject.SetActive(false, activationMethod);
            }
        }
    }
}