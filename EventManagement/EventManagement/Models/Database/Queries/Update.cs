using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Models.Database.Queries
{
    internal class Update
    {
        /// <summary>
        /// Запрос на обновление данных пользователя
        /// </summary>
        /// <param name="user">Объект пользователя</param>
        /// <returns>Успешно/неуспешно</returns>
        public static bool DataUser(User user)
        {
            bool isSaved = true;
            LocalFsServerContext db = new();
            User? loadRecord = null;
            try
            {
                loadRecord = db.Users
                    .FirstOrDefault(p => p.Id == user.Id);
                if (loadRecord != null)
                {
                    loadRecord.Email = user.Email;
                    loadRecord.Password = user.Password;
                    loadRecord.Phone = user.Phone;
                    _ = db.SaveChanges();
                }
                else
                {
                    throw new Exception("Не найдена запись");
                }

            }
            catch { isSaved = false; }
            return isSaved;
        }
    }
}
