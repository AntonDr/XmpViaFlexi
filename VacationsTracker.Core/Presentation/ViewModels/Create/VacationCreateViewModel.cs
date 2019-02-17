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

        private DateTime _startDate;
        private DateTime _endDate;
        private VacationType _type;
        private VacationStatus _status;
        public VacationCreateViewModel(INavigationService navigationService, IVacationsRepository vacationsRepository)
        {
            _navigationService = navigationService;
            _vacationsRepository = vacationsRepository;
        }

        public DateTime StartDate
        {
            get => _startDate;
            set => Set(ref _startDate, value);
        }

        public DateTime EndDate
        {
            get => _endDate;
            set => Set(ref _endDate, value);
        }

        public VacationType Type
        {
            get => _type;
            set => Set(ref _type, value);
        }

        public VacationStatus Status
        {
            get => _status;
            set => Set(ref _status, value);
        }

        public ICommand CreateCommand => CommandProvider.Get(Create);

        private async void Create()
        {
            var vacation = new VacationCellViewModel
            {
                Start = StartDate,
                End = EndDate,
                Status = Status,
                Type = Type
            };

            await _vacationsRepository.UpsertVacationAsync(vacation);

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

            StartDate = DateTime.Now;
            EndDate = DateTime.Now.AddDays(3);
        }
    }
}
