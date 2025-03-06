using System;
using System.Collections.Generic;
using EventManagement.Models;
using EventManagement.Models.Database;
using ReactiveUI;

namespace EventManagement.ViewModels.ManagementUsers
{
	public class ProfileViewModel : ViewModelBase
	{
		User user;
		string email, password, phone, gender; 
		public ProfileViewModel() 
		{
			User = AuthorizedUser.UserInstance.Data;
        }

        public User User { get => user; set => this.RaiseAndSetIfChanged(ref user, value); }        

        public void GoToUserView()=> MainWindowViewModel.Navigation.NavigateToUserView();
		public void GoExitProfile()
		{
			AuthorizedUser.UserInstance.DeleteUser();
            MainWindowViewModel.Navigation.NavigateToMainViewEvents();
        }

		public void GoToEditProfileView() => MainWindowViewModel.Navigation.NavigateToEditProfileView();
    }
}