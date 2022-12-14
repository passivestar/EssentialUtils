using System;

namespace EssentialUtils
{
    public class ToggleFlow
    {
        public bool IsEnabled { get; private set; }

        public event Action OnEnabled;
        public event Action OnDisabled;
        public event Action OnBecameEnabled;
        public event Action OnBecameDisabled;

        public ToggleFlow(Action onEnabled = null, Action onDisabled = null,
            Action onBecameEnabled = null, Action onBecameDisabled = null,
            bool startEnabled = false)
        {
            OnEnabled = onEnabled;
            OnDisabled = onDisabled;
            OnBecameEnabled = onBecameEnabled;
            OnBecameDisabled = onBecameDisabled;
        }

        public void Run()
        {
            if (IsEnabled)
            {
                OnEnabled?.Invoke();
            }
            else
            {
                OnDisabled?.Invoke();
            }
        }

        public void Enable()
        {
            if (IsEnabled) return;
            IsEnabled = true;
            OnBecameEnabled?.Invoke();
        }

        public void Disable()
        {
            if (!IsEnabled) return;
            IsEnabled = false;
            OnBecameDisabled?.Invoke();
        }

        public void Toggle()
        {
            IsEnabled = !IsEnabled;
            if (IsEnabled)
            {
                OnBecameEnabled?.Invoke();
            }
            else
            {
                OnBecameDisabled?.Invoke();
            }
        }
    }
}