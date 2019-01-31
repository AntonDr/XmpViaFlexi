using Android.Content;

using FlexiMvvm;
using FlexiMvvm.Navigation;
using FlexiMvvm.Views;

using VacationsTracker.Core.Navigation;
using VacationsTracker.Core.Presentation.ViewModels;
using VacationsTracker.Core.Presentation.ViewModels.Details;
using VacationsTracker.Core.Presentation.ViewModels.Home;
using VacationsTracker.Core.Presentation.ViewModels.Login;
using VacationsTracker.Droid.Views;
using VacationsTracker.Droid.Views.Details;
using VacationsTracker.Droid.Views.Home;
using VacationsTracker.Droid.Views.Login;

namespace VacationsTracker.Droid.Navigation
{
    public class NavigationService : NavigationServiceBase, INavigationService
    {
        public void NavigateToLogin(EntryViewModel fromViewModel)
        {
            var splashScreenActivity = GetActivity<EntryViewModel, SplashScreenActivity>(fromViewModel);
            var loginIntent = new Intent(splashScreenActivity, typeof(LoginActivity));
            splashScreenActivity.NotNull().StartActivity(loginIntent);
        }

        public void NavigateToHome(LoginViewModel fromViewModel)
        {
            var loginActivity = GetActivity<LoginViewModel, LoginActivity>(fromViewModel);
            var homeIntent = new Intent(loginActivity, typeof(HomeActivity));
            homeIntent.AddFlags(ActivityFlags.ClearTask | ActivityFlags.ClearTop | ActivityFlags.NewTask);
            loginActivity.NotNull().StartActivity(homeIntent);
        }

        public void NavigateToVacationDetails(HomeViewModel fromViewModel, VacationDetailsParameters parameters)
        {
            var homeActivity = GetActivity<HomeViewModel, HomeActivity>(fromViewModel);
            var detailsIntent = new Intent(homeActivity, typeof(VacationDetailsActivity));
            detailsIntent.PutViewModelParameters(parameters);
            homeActivity.NotNull().StartActivity(detailsIntent);
        }

        public void NavigateBackToHome(VacationDetailsViewModel fromViewModel)
        {
            var homeActivity = GetActivity<VacationDetailsViewModel, VacationDetailsActivity>(fromViewModel);
            homeActivity.NotNull().Finish();         
        }
    }
}