using System.Collections.Generic;
using UnityEngine;

namespace EssentialUtils
{
    public class StackActivator
    {
        public enum ActivationMode
        {
            Normal,
            Additive
        }

        public ActivationMethod activationMethod = ActivationMethod.SetActive;
        public ActivationMode activationMode = ActivationMode.Normal;

        public Stack<GameObject> Stack { get; set; } = new();

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
                topGameObject.SetActive(false, activationMethod);
            }

            Stack.Push(gameObject);
            gameObject.SetActive(true, activationMethod);
        }

        public GameObject Pop()
        {
            if (Stack.Count > 0)
            {
                var gameObject = Stack.Pop();
                gameObject.SetActive(false, activationMethod);
                if (Stack.Count > 0)
                {
                    Stack.Peek().SetActive(true, activationMethod);
                }
                return gameObject;
            }
            return null;
        }

        public void Clear()
        {
            while (Stack.Count > 0)
            {
                var gameObject = Stack.Pop();
                gameObject.SetActive(false, activationMethod);
            }
        }
    }
}