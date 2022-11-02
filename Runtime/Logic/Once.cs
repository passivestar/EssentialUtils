using System;

namespace EssentialUtils
{
    public class Once
    {
        public bool WasCalled { get; private set; }

        public event Action OnRun;

        public Once(Action onRun)
        {
            OnRun = onRun;
        }

        public void Reset() => WasCalled = false;

        public void Run()
        {
            if (WasCalled)
            {
                return;
            }
            WasCalled = true;
            OnRun();
        }
    }
}