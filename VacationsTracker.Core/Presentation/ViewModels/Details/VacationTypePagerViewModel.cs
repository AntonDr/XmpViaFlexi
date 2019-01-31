using FlexiMvvm;
using VacationsTracker.Core.Domain;
using VacationsTracker.Core.Navigation;

namespace VacationsTracker.Core.Presentation.ViewModels.Details
{
    public class VacationTypePagerViewModel : ViewModelBase<VacationTypePagerParameters>
    {
        private readonly INavigationService _navigationService;

        public VacationTypePagerViewModel(INavigationService navigationService)
        {
            this._navigationService = navigationService;
        }

        public VacationType VacationType { get; private set; }

        protected override void Initialize(VacationTypePagerParameters parameters)
        {
            base.Initialize(parameters);

            VacationType = parameters.NotNull().VacationType;
        }
    }
}