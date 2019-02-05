using FlexiMvvm;
using FlexiMvvm.Navigation;
using VacationsTracker.Core.Navigation;
using VacationsTracker.Core.Presentation.ViewModels;
using VacationsTracker.Core.Presentation.ViewModels.Create;
using VacationsTracker.Core.Presentation.ViewModels.Details;
using VacationsTracker.Core.Presentation.ViewModels.Home;
using VacationsTracker.Core.Presentation.ViewModels.Login;
using VacationsTracker.iOS.Views;
using VacationsTracker.iOS.Views.Home;
using VacationsTracker.iOS.Views.Login;

namespace VacationsTracker.iOS.Navigation
{
    public class NavigationService : NavigationServiceBase, INavigationService
    {
        public void NavigateToLogin(EntryViewModel fromViewModel)
        {
            var rootViewController = GetViewController<EntryViewModel, RootNavigationController>(fromViewModel);
            rootViewController.NotNull().PushViewController(new LoginViewController(), false);
        }

        public void NavigateToHome(LoginViewModel fromViewModel)
        {
            var loginViewController = GetViewController<LoginViewModel, LoginNavigationController>(fromViewModel);
            loginViewController.NotNull().PushViewController(new HomeViewController(),true);
        }

        public void NavigateToVacationDetails(HomeViewModel fromViewModel, VacationDetailsParameters parameters)
        {
            throw new System.NotImplementedException();
        }

        public void NavigateBackToHome(VacationDetailsViewModel fromViewModel)
        {
            throw new System.NotImplementedException();
        }

        public void NavigateToCreateVacation(HomeViewModel fromViewModel)
        {
            throw new System.NotImplementedException();
        }

        public void NavigateCreateBackToHome(VacationCreateViewModel fromViewModel)
        {
            throw new System.NotImplementedException();
        }
    }
}