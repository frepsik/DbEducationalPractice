using System;
using System.Collections.Generic;
using EventManagement.Models.Database;
using EventManagement.Models.Database.Queries;
using ReactiveUI;

namespace EventManagement.ViewModels.ManagementUsers
{
	public class JuryViewModel : ViewModelBase
	{
		List<Jury>? jury;
		public JuryViewModel() 
		{
			Jury = Get.AllJury();           
        }

        public List<Jury>? Jury { get => jury; set => this.RaiseAndSetIfChanged(ref jury, value); }

        public void GoToUserView() => MainWindowViewModel.Navigation.NavigateToUserView();
		
    }
}