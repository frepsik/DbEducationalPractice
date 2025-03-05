using System;
using System.Collections.Generic;
using ReactiveUI;

namespace EventManagement.ViewModels
{
	public class MainViewModel : ViewModelBase
	{
		public MainViewModel() 
		{
			
		}

		public void GoToLogIn() => MainWindowViewModel.Navigation.NavigateToLogIn();
	}
}