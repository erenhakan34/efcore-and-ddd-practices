using System;

namespace Infrastructure.Utils
{
    public static class DateTimeUtils
    {
        public static bool IsNotDefaultDate(DateTime value)
        {
            return !value.Equals(default(DateTime));
        }
    }
}
