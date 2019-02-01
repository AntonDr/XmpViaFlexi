using FlexiMvvm;
using FlexiMvvm.Collections;
using FlexiMvvm.Commands;
using System;
using System.Threading.Tasks;
using VacationsTracker.Core.DataAccess;
using VacationsTracker.Core.Domain;
using VacationsTracker.Core.Navigation;
using VacationsTracker.Core.Presentation.ViewModels.Details;

namespace VacationsTracker.Core.Presentation.ViewModels.Create
{
    public class VacationCreateViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IVacationsRepository _vacationsRepository;

        public VacationCreateViewModel(INavigationService navigationService, IVacationsRepository vacationsRepository)
        {
            _navigationService = navigationService;
            _vacationsRepository = vacationsRepository;
        }

        public VacationCellViewModel Vacation { get; set; }

        public ICommand CreateCommand => CommandProvider.Get(Create);

        private async void Create()
        {
            await _vacationsRepository.CreateVacationAsync(Vacation);
            _navigationService.NavigateCreateBackToHome(this);
        }

        public RangeObservableCollection<VacationTypePagerParameters> VacationTypes { get; }
            = new RangeObservableCollection<VacationTypePagerParameters>
            {
                new VacationTypePagerParameters { VacationType = VacationType.Regular },
                new VacationTypePagerParameters { VacationType = VacationType.SickDays },
                new VacationTypePagerParameters { VacationType = VacationType.ExceptionalLeave },
                new VacationTypePagerParameters { VacationType = VacationType.Overtime },
                new VacationTypePagerParameters { VacationType = VacationType.LeaveWithoutPay },
            };

        protected override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            Vacation = new VacationCellViewModel
            {
                End = DateTime.Now.AddDays(2),
                Start = DateTime.Now
            };
        }
    }
}
