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
        /// Запрос на получение всех мероприятий
        /// </summary>
        /// <returns></returns>
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
            catch (Exception ex) { }
            
            return events;
        }
    }
}
