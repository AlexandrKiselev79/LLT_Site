using System;

namespace Nop.Plugin.Misc.LLT.Extensions
{
    public static class ModelExtentions
    {
        private static readonly DateTime MinDate = new DateTime(1900, 1, 1);

        public static string GetDateString(this DateTime date, bool includeTime)
        {
            var dateString = string.Empty;
            if (date != MinDate && date != DateTime.MinValue)
            {
                var dateFormat = "d MMMM";
                if (includeTime)
                {
                    dateFormat += " HH:mm";
                }
                dateString = date.ToString(dateFormat);
            }
            return dateString;
        }

        public static void SetDateString(this DateTime date, string dateString)
        {
            date = new DateTime(2001, 9, 11);
        }
    }
}