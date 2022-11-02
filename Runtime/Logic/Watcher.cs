using System;

namespace EssentialUtils
{
    public class Watcher
    {
        public object LastValue { get; private set; }

        public event Action OnChanged;
        public event Action OnUnchanged;

        object previousValue = null;

        public Watcher(Action onChanged = null, Action onUnchanged = null)
        {
            OnChanged = onChanged;
            OnUnchanged = onUnchanged;
        }

        public bool Run(object value)
        {
            LastValue = value;
            var valueChanged = previousValue != null && !value.Equals(previousValue);
            previousValue = value;
            if (valueChanged)
            {
                OnChanged?.Invoke();
            }
            else
            {
                OnUnchanged?.Invoke();
            }
            return valueChanged;
        }
    }
}