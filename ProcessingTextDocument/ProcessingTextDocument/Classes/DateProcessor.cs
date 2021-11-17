using System;

namespace ProcessingTextDocument
{
    /// <summary>
    /// Класс для опреаций преобразований дат
    /// </summary>
    public class ClassDateTimeHelper
    {
        /// <summary>
        /// Метод для получения следующего рабочего дня
        /// </summary>
        /// <returns> Экземпляр DateTime </returns>
        public static DateTime GetNextWorkingDay()
        {
            var tommorowDate = DateTime.Now.AddDays(1D);
            switch (tommorowDate.DayOfWeek)
            {
                //СУББОТА
                case DayOfWeek.Saturday:
                    return tommorowDate.AddDays(2);
                //ВОСКРЕСЕНЬЕ
                case DayOfWeek.Sunday:
                    return tommorowDate.AddDays(1);
                default:
                    return tommorowDate;
            }
        }
    }
}
