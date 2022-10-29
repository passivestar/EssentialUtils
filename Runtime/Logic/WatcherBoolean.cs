using System;
using UnityEngine;

namespace EssentialUtils
{
    public class WatcherBoolean
    {
        public Action ActionRun { get; private set; }

        public bool LastValue { get; private set; }

        public Action OnChanged { get; set; }
        public Action OnUnchanged { get; set; }
        public Action OnBecameTrue { get; set; }
        public Action OnBecameFalse { get; set; }

        bool? previousValue = null;

        public WatcherBoolean(Action onChanged = null, Action onUnchanged = null,
            Action onBecameTrue = null, Action onBecameFalse = null)
        {
            OnChanged = onChanged;
            OnUnchanged = onUnchanged;
            OnBecameTrue = onBecameTrue;
            OnBecameFalse = onBecameFalse;
        }

        public bool Run(bool value)
        {
            LastValue = value;
            var valueChanged = previousValue != null && value != previousValue;
            previousValue = value;
            if (valueChanged)
            {
                OnChanged?.Invoke();
                if (value)
                {
                    OnBecameTrue?.Invoke();
                }
                else
                {
                    OnBecameFalse?.Invoke();
                }
            }
            else
            {
                OnUnchanged?.Invoke();
            }
            return valueChanged;
        }
    }
}