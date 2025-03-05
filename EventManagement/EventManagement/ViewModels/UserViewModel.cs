using System;
using System.Collections.Generic;
using EventManagement.Models;
using EventManagement.Models.Database;
using ReactiveUI;

namespace EventManagement.ViewModels
{
	public class UserViewModel : ViewModelBase
	{
		User _authorizedUser;
        string gender, periodDay, nameView;
        bool isVisible;
        
        public UserViewModel(User authorizedUser) 
		{
            AuthorizedUser = authorizedUser;
            PeriodDay = ProcessingDataForUser.DefiningPeriodDay();
            Gender = ProcessingDataForUser.DefiningGenderUser(authorizedUser);
            NameView = ProcessingDataForUser.DefiningStateUser(authorizedUser);
            if(AuthorizedUser.State.Name == "Организатор")
                IsVisible = true;
            else IsVisible = false;
        }

        public User AuthorizedUser { get => _authorizedUser; set => this.RaiseAndSetIfChanged(ref _authorizedUser, value); }
        public string PeriodDay { get => periodDay; set => this.RaiseAndSetIfChanged(ref periodDay, value); }
        public string Gender { get => gender; set => this.RaiseAndSetIfChanged(ref gender, value); }
        public string NameView { get => nameView; set => this.RaiseAndSetIfChanged(ref nameView, value); }
        public bool IsVisible { get => isVisible; set => this.RaiseAndSetIfChanged(ref isVisible, value); }
    }
}