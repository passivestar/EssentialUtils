using System;

namespace EssentialUtils
{
    public class Watcher
    {
        public Action ActionRun { get; private set; }

        public object LastValue { get; private set; }

        public Action OnChanged { get; set; }
        public Action OnUnchanged { get; set; }

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