using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using FlexiMvvm;
using FlexiMvvm.Collections;
using FlexiMvvm.Commands;
using VacationsTracker.Core.DataAccess;
using VacationsTracker.Core.Domain;
using VacationsTracker.Core.Navigation;
using VacationsTracker.Core.Presentation.ViewModels.Details;
using ICommand = FlexiMvvm.Commands.ICommand;

namespace VacationsTracker.Core.Presentation.ViewModels.Home
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IVacationsRepository _vacationsRepository;
        private DateTime _refreshedDateTime = DateTime.Now;
        private bool _isRefreshing;

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

        public bool IsRefreshing
        {
            get => _isRefreshing;
            set => Set(ref _isRefreshing, value);
        }

        public ICommand<VacationCellViewModel> VacationSelectedCommand => CommandProvider.Get<VacationCellViewModel>(VacationSelected);

        public ICommand VacationCreatedCommand => CommandProvider.Get(CreateVacation);

        public ICommand RefreshCommand => CommandProvider.GetForAsync(Refresh);

        public ICommand<NavigationItems> FilterNavigationCommand => CommandProvider.Get<NavigationItems>(FilterNavigation);

        private async void FilterNavigation(NavigationItems item)
        {
            var vacation = await _vacationsRepository.GetVacationsAsync();

            switch (item)
            {
                case NavigationItems.All:
                    break;
                case NavigationItems.Approved:
                    vacation = vacation.Where(x => x.Status == VacationStatus.Approved);
                    break;
                case NavigationItems.Closed:
                    vacation = vacation.Where(x => x.Status == VacationStatus.Closed);
                    break;
            }


            Vacations.Clear();

            var list = SeparatorVisibility(vacation);

            Vacations.AddRange(list);
            
        }


        private void CreateVacation()
        {
            _navigationService.NavigateToCreateVacation(this);
        }

        private void VacationSelected(VacationCellViewModel vacationCellViewModel)
        {
            var parameters = new VacationDetailsParameters(vacationCellViewModel.Id);
            _navigationService.NavigateToVacationDetails(this, parameters);
        }

        public async Task Refresh()
        {
            this.IsRefreshing = true;

            await Task.Delay(1000);

            await ReloadVacations();

            this.IsRefreshing = false;

            this.RefreshedDateTime = DateTime.Now;
        }

        protected override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            RefreshedDateTime = DateTime.Now;

            await LoadVacations();
        }

        private async Task ReloadVacations()
        {
            Vacations.Clear();

            await LoadVacations();
        }

        private async Task LoadVacations()
        {
            var vacations = await _vacationsRepository.GetVacationsAsync();

            var list = SeparatorVisibility(vacations);

            Vacations.AddRange(list);
        }

        public IEnumerable<VacationCellViewModel> SeparatorVisibility(
            IEnumerable<VacationCellViewModel> vacationCellViewModels)
        {
            var list = vacationCellViewModels.Select(x =>
            {
                x.SeparatorVisible = true;
                return x;
            }).ToList();

            list.Last().SeparatorVisible = false;

            return list;
        }

    }
}
