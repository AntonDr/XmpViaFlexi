using VacationsTracker.Core.Presentation.ViewModels;
using VacationsTracker.Core.Presentation.ViewModels.Create;
using VacationsTracker.Core.Presentation.ViewModels.Details;
using VacationsTracker.Core.Presentation.ViewModels.Home;
using VacationsTracker.Core.Presentation.ViewModels.Login;

namespace VacationsTracker.Core.Navigation
{
    public interface INavigationService
    {
        void NavigateToLogin(EntryViewModel fromViewModel);

        void NavigateToHome(LoginViewModel fromViewModel);

        void NavigateToVacationDetails(HomeViewModel fromViewModel, VacationDetailsParameters parameters);

        void NavigateBackToHome(VacationDetailsViewModel fromViewModel);

        void NavigateToCreateVacation(HomeViewModel fromViewModel);

        void NavigateCreateBackToHome(VacationCreateViewModel fromViewModel);
    }
}
