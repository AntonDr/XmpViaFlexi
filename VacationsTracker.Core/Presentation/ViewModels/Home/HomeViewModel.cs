using FlexiMvvm;
using FlexiMvvm.Collections;
using FlexiMvvm.Commands;
using System;
using System.Linq;
using System.Threading.Tasks;
using VacationsTracker.Core.DataAccess;
using VacationsTracker.Core.Navigation;
using VacationsTracker.Core.Presentation.ViewModels.VacationDetails;

namespace VacationsTracker.Core.Presentation.ViewModels.Home
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IVacationsRepository _vacationsRepository;
        private DateTime _refreshedDateTime = DateTime.Now;

        public HomeViewModel(
            INavigationService navigationService,
            IVacationsRepository vacationsRepository)
        {
            _navigationService = navigationService;
            _vacationsRepository = vacationsRepository;
        }

        public RangeObservableCollection<VacationCellViewModel> Vacations { get; } = new RangeObservableCollection<VacationCellViewModel>();

        public DateTime RefreshedDateTime
        {
            get => _refreshedDateTime;
            set => Set(ref _refreshedDateTime, value);
        }

        public ICommand<VacationCellViewModel> VacationSelectedCommand => CommandProvider.Get<VacationCellViewModel>(VacationSelected);

        private void VacationSelected(VacationCellViewModel vacationCellViewModel)
        {
            _navigationService.NavigateToVacationDetails(this, new VacationDetailsParameters { VacationId = vacationCellViewModel.VacationId });
        }

        protected override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            var vacations = await _vacationsRepository.GetVacationsAsync();

            var list = vacations.ToList();

            if (list.Count != 0)
            {
                list.LastOrDefault().SeparatorVisible = false;
            }

            Vacations.AddRange(list);
        }
    }
}
