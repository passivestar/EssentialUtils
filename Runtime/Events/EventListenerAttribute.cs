using System;

namespace EssentialUtils
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class EventListenerAttribute : Attribute
    {
        public string EventName { get; private set; }

        public EventListenerAttribute(string eventName = null)
        {
            EventName = eventName;
        }
    }
}