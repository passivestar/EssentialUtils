using System;

namespace EssentialUtils
{
    public class Once
    {
        public Action ActionRun { get; private set; }
        public Action ActionReset { get; private set; }

        public bool WasCalled { get; private set; }

        public event Action OnRun;

        public Once(Action onRun)
        {
            OnRun = onRun;
            ActionRun = () => Run();
            ActionReset = () => Reset();
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