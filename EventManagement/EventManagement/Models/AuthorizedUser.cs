using EventManagement.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Models
{
    /// <summary>
    /// singleton класс, содержащий экземпляр пользователя
    /// </summary>
    internal class AuthorizedUser
    {
        //Запись означает, вызвать, когда это будет нужно, Lazy - ленивый, ну или когда понадобится
        static Lazy<AuthorizedUser> _userInstance = new(() => new AuthorizedUser()); //В скобках инструкция описана, когда вызовут, необходимо создать такой объект

        //Данное свойство возвращает объект, _userInstance.Value (В нём содержится AuthorizedUser)
        internal static AuthorizedUser UserInstance => _userInstance.Value; //Запись аналогичная Get, только сокращённая
        public User? Data { get; private set; }

        public void EditPersonalDataUser(User user)
        {
            Data = new User() 
            {
                Id = user.Id,
                FullName = user.FullName,
                GenderId = user.GenderId,
                StateId = user.StateId,
                Email = user.Email,
                Birthday = user.Birthday,
                CountryId = user.CountryId,
                Phone = user.Phone,
                Password = user.Password,
                ImagePath = user.ImagePath,
                Country = user.Country,
                Events = user.Events,
                Gender = user.Gender,
                Jury = user.Jury,
                Moderator = user.Moderator,
                State = user.State
            };
            if (Data.Gender.Name == "м")
                Data.Gender.Name = "Мужской";
            else
                Data.Gender.Name = "Женский";
        }
        public void DeleteUser() => Data = null;
    }
}
