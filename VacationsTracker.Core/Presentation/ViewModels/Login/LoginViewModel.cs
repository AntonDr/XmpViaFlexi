using System.Threading.Tasks;
using FlexiMvvm;
using FlexiMvvm.Commands;
using VacationsTracker.Core.Navigation;

namespace VacationsTracker.Core.Presentation.ViewModels.Login
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public LoginViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public ICommand LoginCommand => CommandProvider.GetForAsync(Login);


        private async Task Login()
        {
            // TODO login operation

            await Task.Delay(500);

            _navigationService.NavigateToHome(this);
        }
    }
}
