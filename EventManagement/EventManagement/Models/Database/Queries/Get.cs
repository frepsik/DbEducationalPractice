using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
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


        /// <summary>
        /// Запрос на получение определённого списка пользователей по статусу пользователя
        /// </summary>
        /// <param name="state">Статус пользователя</param>
        /// <returns>Список пользователей с конкретным статусом</returns>
        public static List<User>? UsersByState(string state)
        {
            LocalFsServerContext db = new();
            List<User>? users = null;
            try
            {
                users = db.Users
                    .Include(p => p.Gender)
                    .Include(p => p.State)
                    .Include(p => p.Country)
                    .Where(p=>p.State.Name == state)
                    .ToList();
                   
            }
            catch { }
            return users;
        }

        /// <summary>
        /// Запрос на олучение списка жури
        /// </summary>
        /// <returns></returns>
        public static List<Jury>? AllJury()
        {
            LocalFsServerContext db = new();
            List<Jury>? jury = null;
            try
            {
                jury = db.Juries
                    .Include(p => p.User)
                        .ThenInclude(p => p.Country)
                     .Include(p => p.User)
                        .ThenInclude(p=>p.Gender)
                    .Include(p => p.Direction)
                    .ToList();

            }
            catch { }
            return jury;
        }

        /// <summary>
        /// Запрос на получение всех стран
        /// </summary>
        /// <returns></returns>
        public static List<Country>? AllCountry()
        {
            LocalFsServerContext db = new();
            List<Country>? countries = null;
            try
            {
                countries = db.Countries.ToList();
            }
            catch { }

            return countries;
        }

        /// <summary>
        /// Запрос на получение всех направлений для жюри и модератора
        /// </summary>
        /// <returns></returns>
        public static List<Direction>? AllDirections()
        {
            LocalFsServerContext db = new();
            List<Direction>? directions = null;
            try
            {
                directions = db.Directions.ToList();
            }
            catch { }

            return directions;
        }
    }
}
