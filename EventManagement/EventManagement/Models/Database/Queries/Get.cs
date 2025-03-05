﻿using Microsoft.EntityFrameworkCore;
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
                    .ToList();
            }
            catch { }

            return users;
        }
    }
}
