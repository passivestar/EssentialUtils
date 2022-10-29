using System;

namespace EssentialUtils
{
    public class Once
    {
        public Action ActionRun { get; private set; }
        public bool WasCalled { get; private set; }

        public Action OnRun { get; set; }

        public Once(Action onRun)
        {
            OnRun = onRun;
            ActionRun = () => Run();
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