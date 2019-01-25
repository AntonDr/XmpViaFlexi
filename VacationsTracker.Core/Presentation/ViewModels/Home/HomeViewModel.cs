using System.Collections.ObjectModel;
using System.Threading.Tasks;
using FlexiMvvm;
using FlexiMvvm.Collections;
using VacationsTracker.Core.DataAccess;
using VacationsTracker.Core.Navigation;

namespace VacationsTracker.Core.Presentation.ViewModels.Home
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IVacationsRepository _vacationsRepository;

        public HomeViewModel(
            INavigationService navigationService,
            IVacationsRepository vacationsRepository)
        {
            _navigationService = navigationService;
            _vacationsRepository = vacationsRepository;
        }

        public RangeObservableCollection<VacationCellViewModel> Vacations { get; } = new RangeObservableCollection<VacationCellViewModel>();

        protected override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            var vacations = await _vacationsRepository.GetVacationsAsync();

            Vacations.AddRange(vacations);
        }
    }
}
