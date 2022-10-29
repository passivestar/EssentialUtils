using System;

namespace EssentialUtils
{
    public static class String
    {
        public static string FormatTime(float time, string format = "m\\:ss\\.fff")
        {
            var timeSpan = new TimeSpan((long)(time * TimeSpan.TicksPerSecond));
            return timeSpan.ToString(format);
        }
    }
}