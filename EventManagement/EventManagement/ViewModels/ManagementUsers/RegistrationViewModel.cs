using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia.Platform.Storage;
using EventManagement.Models.Database;
using EventManagement.Models.Database.Queries;
using ReactiveUI;
using Tmds.DBus.Protocol;

namespace EventManagement.ViewModels.ManagementUsers
{
	public class RegistrationViewModel : ViewModelBase
	{
		Guid registrationId;

        List<Country>? countries;
        List<Direction>? directions;
        List<Event>? events;
		List<string> states, genders;

        Country? selectedCountry;
        Direction? selectedDirection;
        Event? selectedEvent;

        string selectedState, selectedGender;
        string password, rePassword, email, phone, fullName, message;

        bool isChecked;


        Bitmap? selectedImage;

        IStorageFile? selectedFile;
        public RegistrationViewModel() 
		{
            RegistrationId = Guid.NewGuid();
            States = new List<string>() 
            { 
                "Модератор",
                "Жюри"
            };
            Genders = new List<string>()
            {
                "Мужчина",
                "Женщина"
            };
            Countries = Get.AllCountry();
            Directions = Get.AllDirections();
            Events = Get.AllEvents();

            SelectedState = string.Empty;
            SelectedGender = string.Empty;
            SelectedDirection = null;
            SelectedEvent = null;
            SelectedCountry = null;
            SelectedImage = null;
            
        }

        public Guid RegistrationId { get => registrationId; set => this.RaiseAndSetIfChanged(ref registrationId, value); }

        //Статусы
        public List<string> States { get => states; set => this.RaiseAndSetIfChanged(ref states, value); }
        public string SelectedState { get => selectedState; set { this.RaiseAndSetIfChanged(ref selectedState, value); Message = string.Empty; }  }

        //Гендер
        public List<string> Genders { get => genders; set => this.RaiseAndSetIfChanged(ref genders, value); }
        public string SelectedGender { get => selectedGender; set { this.RaiseAndSetIfChanged(ref selectedGender, value); Message = string.Empty; }  }

        //Страны
        public List<Country>? Countries { get => countries; set => this.RaiseAndSetIfChanged(ref countries, value); }
        public Country? SelectedCountry { get => selectedCountry; set { this.RaiseAndSetIfChanged(ref selectedCountry, value); Message = string.Empty; }  }
        
        //Направления
        public List<Direction>? Directions { get => directions; set => this.RaiseAndSetIfChanged(ref directions, value); }
        public Direction? SelectedDirection { get => selectedDirection; set { this.RaiseAndSetIfChanged(ref selectedDirection, value); Message = string.Empty; }  }

        //Мероприятия
        public List<Event>? Events { get => events; set => this.RaiseAndSetIfChanged(ref events, value); }
        public Event? SelectedEvent { get => selectedEvent; set { this.RaiseAndSetIfChanged(ref selectedEvent, value); Message = string.Empty; }  }

        //Пароли
        public string Password 
        { 
            get => password; set
            {
                this.RaiseAndSetIfChanged(ref password, value);
                CheckPasswords();
                Message = string.Empty;
            } 
        }
        public string RePassword 
        { 
            get => rePassword; 
            set
            {                
                this.RaiseAndSetIfChanged(ref rePassword, value);
                CheckPasswords();
                Message = string.Empty;
            }
        }

        public string Email { get => email; set { this.RaiseAndSetIfChanged(ref email, value); Message = string.Empty; } }
        public string Phone { get => phone; set { this.RaiseAndSetIfChanged(ref phone, value); Message = string.Empty; } }
        public string FullName { get => fullName; set { this.RaiseAndSetIfChanged(ref fullName, value); Message = string.Empty; }  }

        public bool IsChecked { get => isChecked; set => this.RaiseAndSetIfChanged(ref isChecked, value); }
        public Bitmap? SelectedImage { get => selectedImage; set { this.RaiseAndSetIfChanged(ref selectedImage, value);  Message = string.Empty; }   }

        public IStorageFile? SelectedFile { get => selectedFile; set => selectedFile = value; }
        public string Message { get => message; set => this.RaiseAndSetIfChanged(ref message, value); }        
        string PathToImageFileAvares { get; set; }
        public void GoToUserView() => MainWindowViewModel.Navigation.NavigateToUserView();

        /// <summary>
        /// Проверка на валидность пароля
        /// </summary>
        /// <returns></returns>
        bool IsPasswordValid()
        {
            // Проверяем длину пароля
            if (Password.Length < 6)
                return false;

            // Проверяем наличие хотя бы одной заглавной буквы, строчной буквы, цифры и спецсимвола
            bool hasUpperCase = false;
            bool hasLowerCase = false;
            bool hasDigit = false;
            bool hasSpecialChar = false;

            foreach (char c in Password)
            {
                if (char.IsUpper(c)) hasUpperCase = true;
                if (char.IsLower(c)) hasLowerCase = true;
                if (char.IsDigit(c)) hasDigit = true;
                if (Regex.IsMatch(c.ToString(), @"[\W_]")) hasSpecialChar = true; // Спецсимволы
            }

            return hasUpperCase && hasLowerCase && hasDigit && hasSpecialChar;
        }

        bool CheckPasswords() => Password == RePassword;

        /// <summary>
        /// Проверка на корректность шаблона почты
        /// </summary>
        /// <returns></returns>
        bool IsEmailValid()
        {
            // Регулярное выражение для проверки email
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            return Regex.IsMatch(Email, emailPattern);
        }


        public void SaveData()
        {
            if (!string.IsNullOrEmpty(Message))
            {
                Message = string.Empty;
            }

            if (string.IsNullOrEmpty(SelectedState) || string.IsNullOrEmpty(SelectedGender) || string.IsNullOrEmpty(Password) ||
                string.IsNullOrEmpty(RePassword) || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Phone) || string.IsNullOrEmpty(FullName) ||
                SelectedEvent is null || SelectedDirection is null || SelectedCountry is null)
            {
                Message = "Не все обязательные поля заполнены";
                return;
            }
            else if (!CheckPasswords())
            {
                Message = "Пароли не совпадают";
                return;
            }
            else if (!IsPasswordValid())
            {
                Message = "Пароль не соответствует требованиям";
                return;
            }
            else if (!IsEmailValid())
            {
                Message = "Ввдено некорректное значение почты";
                return;
            }
            else
            {
                if (SelectedImage != null)
                {
                    SaveImage();
                }

                Guid genderId = SelectedGender switch
                {
                    "Мужчина" => Guid.Parse("db03eac4-7ce3-4b7e-b9af-1598ca047671"),
                    "Женщина" => Guid.Parse("ee090a9f-b6c5-483b-ba93-80b2921278a9"),
                };

                Guid stateId = SelectedState switch
                {
                    "Жюри" => Guid.Parse("254d1b08-f302-4efc-84f7-507ec8c98e3e"),
                    "Модератор" => Guid.Parse("e9bc062a-881d-4322-be71-756ade0d24cb")
                };

                User newUser = new User()
                {
                    FullName = FullName,
                    Id = RegistrationId,
                    CountryId = SelectedCountry.Id,
                    GenderId = genderId,
                    Password = Password,
                    Email = Email,
                    Phone = Phone,
                    ImagePath = PathToImageFileAvares,
                    StateId = stateId
                };

                if (!Insert.User(newUser))
                {
                    Message = "Произошла ошибка. Повторите попытку позже";
                    return;
                }
                else
                {
                    if (SelectedState == "Жюри")
                    {
                        if (Insert.Jury(new Jury()
                        {
                            Id = Guid.NewGuid(),
                            UserId = RegistrationId,
                            DirectionId = SelectedDirection.Id,
                        }))
                        {
                            ResetData();
                            Message = "Данные успешно добавлены";
                        }
                        else
                        {
                            Message = "Произошла ошибка. Повторите попытку позже";
                            return;
                        }
                    }
                    else
                    {
                        if (Insert.Moderator(new Moderator()
                        {
                            Id = Guid.NewGuid(),
                            UserId = RegistrationId,
                            DirectionId = SelectedDirection.Id,
                            ModeratorEventId = null
                        }))
                        {
                            ResetData();
                            Message = "Данные успешно добавлены";
                        }
                        else
                        {
                            Message = "Произошла ошибка. Повторите попытку позже";
                            return;
                        }
                    }
                }


            }
               
        }

        void ResetData()
        {
            RegistrationId = Guid.NewGuid();

            SelectedState = string.Empty;
            SelectedGender = string.Empty;
            FullName = string.Empty;
            Password = string.Empty;
            RePassword = string.Empty;
            Email = string.Empty;
            PathToImageFileAvares = string.Empty;

            SelectedDirection = null;
            SelectedEvent = null;
            SelectedCountry = null;
            SelectedImage = null;
            SelectedFile = null;

            IsChecked = false;

        }

        

        



        /// <summary>
        /// Выбор картинки
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public async Task SelectImageAsync()
        {
            try
            {
                if (Application.Current?.ApplicationLifetime is not IClassicDesktopStyleApplicationLifetime desktop ||
                desktop.MainWindow?.StorageProvider is not { } provider) throw new NullReferenceException("Отсутствует провайдер");

                var files = await provider.OpenFilePickerAsync(
                    new FilePickerOpenOptions()
                    {
                        Title = "Выберите изображение профиля",
                        AllowMultiple = false,
                        FileTypeFilter = [FilePickerFileTypes.ImageAll]
                    });

                if (files is null || files.Count == 0)
                    return;

                SelectedFile = files[0];

                Uri fileUri = SelectedFile.Path;
                string pathFile = fileUri.LocalPath;

                SelectedImage = new Bitmap(pathFile);
            }
            catch { }            
        }

        //Сохранение картинки в каталог конкретного пользователя
        async Task SaveImage()
        {
            string? projectRoot = Directory.GetParent(AppContext.BaseDirectory)?
                .Parent?.Parent?.Parent?.FullName;

            string pathToUserImages;
            if (SelectedState == "Жюри")
                pathToUserImages = "jury";
            else if (SelectedState == "Модератор")
                pathToUserImages = "moderators";
            else
            {
                return;
            }

            string path = Path.Combine(projectRoot, "Assets", $"{pathToUserImages}"); // Путь к папке 

            string fileName = SelectedFile.Name;
            
            string destinationPath = Path.Combine(path, fileName);

            //Сохраняем путь для картинки нового пользователя
            PathToImageFileAvares = Path.Combine(pathToUserImages, fileName);

            // Проверяем, существует ли уже такой файл, и меняем имя, если нужно
            int counter = 1;
            while (File.Exists(destinationPath))
            {
                string extension = Path.GetExtension(fileName);
                fileName = $"{fileName}_{counter}{extension}";
                destinationPath = Path.Combine(path, fileName);
                counter++;
            }

            // Копируем изображение в каталог модератора или жюри
            await using var sourceStream = await SelectedFile.OpenReadAsync();
            await using var destinationStream = File.Create(destinationPath);
            await sourceStream.CopyToAsync(destinationStream);
        }
    }
}