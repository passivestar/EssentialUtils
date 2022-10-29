using System.Collections;
using UnityEngine;

namespace EssentialUtils
{
    public class StackActivator
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

        public Stack Stack { get; set; } = new();

        public StackActivator(
            ActivationMethod activationMethod = ActivationMethod.SetActive,
            ActivationMode activationMode = ActivationMode.Normal
        )
        {
            this.activationMethod = activationMethod;
            this.activationMode = activationMode;
        }

        public void Push(GameObject gameObject)
        {
            if (activationMode == ActivationMode.Normal && Stack.Count > 0)
            {
                var topGameObject = Stack.Peek();
                SetActive((GameObject)topGameObject, false);
            }

            Stack.Push(gameObject);
            SetActive(gameObject, true);
        }

        public GameObject Pop()
        {
            if (Stack.Count > 0)
            {
                var gameObject = Stack.Pop();
                SetActive((GameObject)gameObject, false);
                if (Stack.Count > 0)
                {
                    SetActive((GameObject)Stack.Peek(), true);
                }
                return (GameObject)gameObject;
            }
            return null;
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

        public void Clear()
        {
            while (Stack.Count > 0)
            {
                var gameObject = Stack.Pop();
                SetActive((GameObject)gameObject, false);
            }
        }
    }
}