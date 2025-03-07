using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Models.Database.Queries
{
    internal class Insert
    {
        /// <summary>
        /// Запрос на добавление нового пользователя в систему
        /// </summary>
        /// <param name="user">Объект пользователя</param>
        /// <returns>Успешно/неуспешно</returns>
        public static bool User(User user)
        {
            LocalFsServerContext db = new();
            bool isSaved = true;

            try
            {
                _ = db.Users.Add(user);
                _ = db.SaveChanges();
            }
            catch { isSaved = false; }

            return isSaved;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="moderator">Объект модератора</param>
        /// <returns>Успешно/неуспешно</returns>
        public static bool Moderator(Moderator moderator)
        {
            LocalFsServerContext db = new();
            bool isSaved = true;

            try
            {
                _ = db.Moderators.Add(moderator);
                _ = db.SaveChanges();
            }
            catch { isSaved = false; }

            return isSaved;
        }


        /// <summary>
        /// Запрос на добавление нового жури
        /// </summary>
        /// <param name="jury">Объект жури</param>
        /// <returns>Успешно/неуспешно</returns>
        public static bool Jury(Jury jury)
        {
            LocalFsServerContext db = new();
            bool isSaved = true;

            try
            {
                _ = db.Juries.Add(jury);
                _ = db.SaveChanges();
            }
            catch { isSaved = false; }

            return isSaved;
        }
    }
}
