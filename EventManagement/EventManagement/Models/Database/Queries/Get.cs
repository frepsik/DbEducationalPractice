using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Models.Database.Queries
{
    internal class Get
    {
        /// <summary>
        /// Запрос на получение всех мероприятий и соответтсвующих им городам
        /// </summary>
        /// <returns>Список всех мероприятий</returns>
        public static List<Event>? AllEvents()
        {
            LocalFsServerContext db = new();
            List<Event>? events = null;
            try
            {
                events = db.Events
                    .Include(p=>p.City)
                    .ToList();
            }
            catch { }
            
            return events;
        }

        /// <summary>
        /// Запрос на получение всех пользователей и сопутствующей информации
        /// </summary>
        /// <returns>Список всех пользователей</returns>
        public static List<User>? AllUsers()
        {
            LocalFsServerContext db = new();
            List<User>? users = null;
            try
            {
                users = db.Users
                    .Include(p=>p.Gender)
                    .Include(p=>p.State)
                    .Include(p => p.Country)
                    .ToList();
            }
            catch { }

            return users;
        }

        /// <summary>
        /// Запрос на получение пользователя по токену
        /// </summary>
        /// <param name="token">Токен пользователя</param>
        /// <returns></returns>
        public static User? UserByToken(string token)
        {
            LocalFsServerContext db = new();
            User? user = null;
            try
            {
                user = db.Users
                    .Include(p => p.Gender)
                    .Include(p => p.State)
                    .Include(p => p.Country)
                    .FirstOrDefault(p => p.Id.ToString() == token);
            }
            catch { }
            return user;
        }
    }
}
