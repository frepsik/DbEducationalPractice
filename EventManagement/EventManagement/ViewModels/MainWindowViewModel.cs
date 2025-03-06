using EventManagement.Models;
using EventManagement.Models.Database;
using EventManagement.ViewModels.ManagementUsers;
using ReactiveUI;

namespace EventManagement.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        ViewModelBase currentViewModel;
        static MainWindowViewModel navigation;
        public MainWindowViewModel()
        {
            Navigation = this;
            //Проверяем, сохранён ли пользователь в системе (авторизовывался ранее или нет)
            if (AuthorizedUser.UserInstance.LoadUser())
            {
                NavigateToUserView();
            }
            else
            {
                NavigateToMainViewEvents();
            }               
        }

        public ViewModelBase CurrentViewModel { get => currentViewModel; set => this.RaiseAndSetIfChanged(ref currentViewModel, value); }
        public static MainWindowViewModel Navigation { get => navigation; set => navigation = value; }

        //Навигационные методы
        public void NavigateToMainViewEvents() => CurrentViewModel = new MainViewModel();
        public void NavigateToLogInView() => CurrentViewModel = new LogInViewModel();
        public void NavigateToUserView() => CurrentViewModel = new UserViewModel();
        public void NavigateToProfileView() => CurrentViewModel = new ProfileViewModel();
        public void NavigateToEditProfileView() => CurrentViewModel = new EditProfileViewModel();
        public void NavigateToParticipantsView() => CurrentViewModel = new ParticipantsViewModel();
        public void NavigateToJuryView() => CurrentViewModel = new JuryViewModel();
        public void NavigateToRegistrationView() => CurrentViewModel = new RegistrationViewModel();
    }
}
