using System;

namespace SmatSchool.WebAPI.Helpers
{
    public static class DateTimeExtensions
    {
        public static int GetCurrenteAge(this DateTime dateTime)
        {
            var currentDate = DateTime.UtcNow;
            int age = currentDate.Year - dateTime.Year;

            if(currentDate < dateTime.AddYears(age))
                age--;

            return age;
        }
    }
}