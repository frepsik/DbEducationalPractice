using System;
using System.Collections.Generic;
using EventManagement.Models.Database;
using EventManagement.Models.Database.Queries;
using ReactiveUI;

namespace EventManagement.ViewModels.ManagementUsers
{
	public class ParticipantsViewModel : ViewModelBase
	{
		List<User>? participants;
		public ParticipantsViewModel() 
		{
			Participants = Get.UsersByState("Участник");			
        }

        public List<User>? Participants { get => participants; set => this.RaiseAndSetIfChanged(ref participants, value); }

		public void GoToUserView() => MainWindowViewModel.Navigation.NavigateToUserView();
    }
}