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
        }

        public ViewModelBase CurrentViewModel { get => currentViewModel; set => this.RaiseAndSetIfChanged(ref currentViewModel, value); }
        public static MainWindowViewModel Navigation { get => navigation; set => navigation = value; }


    }
}
