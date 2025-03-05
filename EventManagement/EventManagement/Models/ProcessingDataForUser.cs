using EventManagement.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Models
{
    internal class ProcessingDataForUser
    {
        /// <summary>
        /// Определение текущего периода времени
        /// </summary>
        /// <returns>Текущий период времени</returns>
        public static string DefiningPeriodDay()
        {
            int hour = DateTime.Now.Hour;
            int minute = DateTime.Now.Minute;

            if (hour < 11 || (hour == 11 && minute == 0))
                return "Доброе утро!";
            else if ((hour == 11 && minute >= 1) || hour < 18)
                return "Добрый день!";
            else
                return "Добрый вечер!";
        }

        public static string DefiningGenderUser(User user)
        {
            string gender = user.Gender.Name;
            if (gender == "м")
                return "Mrs";
            else
                return "Ms";
        }

        /// <summary>
        /// Вощврат названия страницы
        /// </summary>
        /// <param name="user">Авторизованный пользователь</param>
        /// <returns>Название окна</returns>
        public static string DefiningStateUser(User user)
        {
            string state = user.State.Name;
            switch (state)
            {
                case "Жюри":
                    return "Окно жюри";
                case "Модератор":
                    return "Окно модератора";
                case "Участник":
                    return "Окно участника";
                case "Организатор":
                    return "Окно организатора";
                default:
                    return "Окно неопределённого пользователя";
            }
        }
    }
}
