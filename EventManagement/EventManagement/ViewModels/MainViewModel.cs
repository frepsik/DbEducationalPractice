using System.Collections.Generic;
using System.Linq;
using EventManagement.Models;
using EventManagement.Models.Database;
using EventManagement.Models.Database.Queries;
using ReactiveUI;

namespace EventManagement.ViewModels
{
	public class MainViewModel : ViewModelBase
	{
		List<Event>? events, eventsFixed;
		List<string> filterOptions;
		string selectedOption;
		bool _isVisibleBackButton, isVisibleButtonAuthorize;

        public MainViewModel()
		{
			//Проверяем есть ли пользователь в системе для отображения различных кнопок
			if (AuthorizedUser.UserInstance.Data != null)
			{
				IsVisibleButtonAuthorize = false;
				IsVisibleBackButton = true;
			}
			else
			{
                IsVisibleButtonAuthorize = true;
                IsVisibleBackButton = false;
            }
               

            Events = Get.AllEvents();
			if(Events!=null)
				EventsFixed = new List<Event>(Events);
			FilterOptions = new List<string>
			{
				"По дате",
				"По длительности",
				"Нет сортировки"
			};
			SelectedOption = "Нет сортировки";			
        }

		public List<Event>? Events { 
			get => events;
			set
			{
				this.RaiseAndSetIfChanged(ref events, value);
			} 
		}

        public List<string> FilterOptions { get => filterOptions; set => this.RaiseAndSetIfChanged(ref filterOptions, value); }
        public string SelectedOption 
		{ 
			get => selectedOption;
			set
			{
                this.RaiseAndSetIfChanged(ref selectedOption, value);
				OrderEventsBy();
            }
		}

        public List<Event>? EventsFixed { get => eventsFixed; set => eventsFixed = value; }
        public bool IsVisibleBackButton { get => _isVisibleBackButton; set => this.RaiseAndSetIfChanged(ref _isVisibleBackButton, value); }
        public bool IsVisibleButtonAuthorize { get => isVisibleButtonAuthorize; set => this.RaiseAndSetIfChanged(ref isVisibleButtonAuthorize, value); }

        public void GoToLogIn() => MainWindowViewModel.Navigation.NavigateToLogInView();
        public void GoToUserView() => MainWindowViewModel.Navigation.NavigateToUserView();

        void OrderEventsBy()
		{
			if (Events != null)
			{
                if (SelectedOption == "По дате")
                    Events = Events.OrderByDescending(p => p.DateEvent).ToList();
                else if (SelectedOption == "По длительности")
                    Events = Events.OrderByDescending(p => p.Days).ToList();
                else
                    Events = new List<Event>(EventsFixed);
            }			
        }
	}
}