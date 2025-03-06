using System;
using System.Collections.Generic;
using EventManagement.Models.Database;
using EventManagement.Models.Database.Queries;
using ReactiveUI;

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
        string password, rePassword, email, phone, fullName;
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
        }

        public Guid RegistrationId { get => registrationId; set => this.RaiseAndSetIfChanged(ref registrationId, value); }

        //Статусы
        public List<string> States { get => states; set => this.RaiseAndSetIfChanged(ref states, value); }
        public string SelectedState { get => selectedState; set => this.RaiseAndSetIfChanged(ref selectedState, value); }

        //Гендер
        public List<string> Genders { get => genders; set => this.RaiseAndSetIfChanged(ref genders, value); }
        public string SelectedGender { get => selectedGender; set => this.RaiseAndSetIfChanged(ref selectedGender, value); }

        //Страны
        public List<Country>? Countries { get => countries; set => this.RaiseAndSetIfChanged(ref countries, value); }
        public Country? SelectedCountry { get => selectedCountry; set => this.RaiseAndSetIfChanged(ref selectedCountry, value); }
        
        //Направления
        public List<Direction>? Directions { get => directions; set => this.RaiseAndSetIfChanged(ref directions, value); }
        public Direction? SelectedDirection { get => selectedDirection; set => this.RaiseAndSetIfChanged(ref selectedDirection, value); }

        //Мероприятия
        public List<Event>? Events { get => events; set => this.RaiseAndSetIfChanged(ref events, value); }
        public Event? SelectedEvent { get => selectedEvent; set => this.RaiseAndSetIfChanged(ref selectedEvent, value); }

        //Пароли
        public string Password { get => password; set => this.RaiseAndSetIfChanged(ref password, value); }
        public string RePassword { get => rePassword; set => this.RaiseAndSetIfChanged(ref rePassword, value); }

        public string Email { get => email; set => this.RaiseAndSetIfChanged(ref email, value); }
        public string Phone { get => phone; set => this.RaiseAndSetIfChanged(ref phone, value); }
        public string FullName { get => fullName; set => this.RaiseAndSetIfChanged(ref fullName, value); }

        public void GoToUserView() => MainWindowViewModel.Navigation.NavigateToUserView();
    }
}