using UnityEngine;

namespace EssentialUtils
{
    public static class GameObjectExtensions
    {
        public static void SetActive(this GameObject gameObject, bool active, ActivationMethod activationMethod = ActivationMethod.SetActive)
        {
            switch (activationMethod)
            {
                case ActivationMethod.SetActive:
                    gameObject.SetActive(active);
                    break;
                case ActivationMethod.IActivatable:
                    if (gameObject.TryGetComponent<IActivatable>(out var activatable))
                    {
                        if (active)
                        {
                            gameObject.SetActive(true);
                            activatable.Activate();
                        }
                        else
                        {
                            activatable.Deactivate();
                        }
                    }
                    else
                    {
                        gameObject.SetActive(active);
                    }
                    break;
                case ActivationMethod.SendMessage:
                    if (active)
                    {
                        gameObject.SetActive(true);
                        gameObject.SendMessage("Activate", SendMessageOptions.DontRequireReceiver);
                    }
                    else
                    {
                        gameObject.SendMessage("Deactivate", SendMessageOptions.DontRequireReceiver);
                    }
                    break;
            }
        }

        public static void Terminate(this GameObject gameObject)
        {
            if (gameObject.TryGetComponent<ITerminatable>(out var terminatable))
            {
                terminatable.Terminate().onFinished += () =>
                {
                    Object.Destroy(gameObject);
                };
            }
            else
            {
                Object.Destroy(gameObject);
            }
        }
    }
}