using System;
using System.Collections.Generic;
using EventManagement.Models;
using EventManagement.Models.Database;
using EventManagement.Models.Database.Queries;
using ReactiveUI;

namespace EventManagement.ViewModels.ManagementUsers
{
    public class EditProfileViewModel : ViewModelBase
    {
        string email, password, phone, message;

        public EditProfileViewModel()
        {
            Email = AuthorizedUser.UserInstance.Data.Email;
            Password = AuthorizedUser.UserInstance.Data.Password;
            Phone = AuthorizedUser.UserInstance.Data.Phone;

            _Phone = Phone;
            _Password = Password;
            _Email = Email;
        }

        public string Email { get => email; set { this.RaiseAndSetIfChanged(ref email, value); Message = string.Empty; }  }
        public string Password { get => password; set { this.RaiseAndSetIfChanged(ref password, value); Message = string.Empty; } }
        public string Phone { get => phone; set { this.RaiseAndSetIfChanged(ref phone, value); Message = string.Empty; } }
        public string Message { get => message; set => this.RaiseAndSetIfChanged(ref message, value); }
        string _Phone { get; set; }
        string _Password { get; set; }
        string _Email { get; set; }       

        public void GoToProfileView() => MainWindowViewModel.Navigation.NavigateToProfileView();

        public void EditProfile()
        {
            if (!string.IsNullOrEmpty(Message))
            {
                Message = string.Empty;
            }
           
            if (!(Email == _Email && Password == _Password && Phone == _Phone))
            {
                if (!(string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(Phone)))
                {
                    User? person = AuthorizedUser.UserInstance.Data;
                    person.Phone = Phone;
                    person.Email = Email;
                    person.Password = Password;

                    _Phone = Phone;
                    _Email = Email;
                    _Password = Password;

                    AuthorizedUser.UserInstance.EditPersonalDataUser(person);
                    if (Update.DataUser(person))
                    {
                        Message = "Запись успешно обновлена";
                        return;
                    }
                    else
                    {
                        Message = "В ходе обновления данных произошла ошибка";
                        return;
                    }
                }
                else
                {
                    Message = "Одно из полей является пустым. Заполните и повторите попытку";
                    return;
                }
            }
            else
            {
                Message = "Данные не были обновлены. Повторите попытку после изменения";
                return;
            }            
        }
    }
}