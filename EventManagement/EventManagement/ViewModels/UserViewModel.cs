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
        bool isVisibleParticipants, isVisibleJury;
        
        public UserViewModel() 
		{
            User? authorizedUser = AuthorizedUser.UserInstance.Data;
            _AuthorizedUser = authorizedUser;

            PeriodDay = ProcessingDataForUser.DefiningPeriodDay();
            Gender = ProcessingDataForUser.DefiningGenderUser(authorizedUser);
            NameView = ProcessingDataForUser.DefiningStateUser(authorizedUser);

            if (_AuthorizedUser.State.Name == "Организатор")
            {
                IsVisibleParticipants = true;
                IsVisibleJury = true;
            }
            else if (_AuthorizedUser.State.Name == "Жюри" || _AuthorizedUser.State.Name == "Модератор")
            {
                IsVisibleJury = false;
                IsVisibleParticipants = true;
            }
            else
            {
                IsVisibleJury = false;
                IsVisibleParticipants = false;
            }
            
        }

        public User _AuthorizedUser { get => _authorizedUser; set => this.RaiseAndSetIfChanged(ref _authorizedUser, value); }
        public string PeriodDay { get => periodDay; set => this.RaiseAndSetIfChanged(ref periodDay, value); }
        public string Gender { get => gender; set => this.RaiseAndSetIfChanged(ref gender, value); }
        public string NameView { get => nameView; set => this.RaiseAndSetIfChanged(ref nameView, value); }
       
        public bool IsVisibleParticipants { get => isVisibleParticipants; set => this.RaiseAndSetIfChanged(ref isVisibleParticipants, value); }       
        public bool IsVisibleJury { get => isVisibleJury; set => this.RaiseAndSetIfChanged(ref isVisibleJury, value); }

        public void GoToMainView() => MainWindowViewModel.Navigation.NavigateToMainViewEvents();
        public void GoToProfileView() => MainWindowViewModel.Navigation.NavigateToProfileView();
    }
}