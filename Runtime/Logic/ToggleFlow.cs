using System;

namespace EssentialUtils
{
    public class ToggleFlow
    {
        public bool IsEnabled { get; private set; }

        public Action ActionRun { get; private set; }
        public Action ActionEnable { get; private set; }
        public Action ActionDisable { get; private set; }
        public Action ActionToggle { get; private set; }

        public Action OnEnabled { get; set; }
        public Action OnDisabled { get; set; }
        public Action OnBecameEnabled { get; set; }
        public Action OnBecameDisabled { get; set; }

        public ToggleFlow(Action onEnabled = null, Action onDisabled = null,
            Action onBecameEnabled = null, Action onBecameDisabled = null,
            bool startEnabled = false)
        {
            OnEnabled = onEnabled;
            OnDisabled = onDisabled;
            OnBecameEnabled = onBecameEnabled;
            OnBecameDisabled = onBecameDisabled;

            ActionRun = () => Run();
            ActionEnable = () => Enable();
            ActionDisable = () => Disable();
            ActionToggle = () => Toggle();
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