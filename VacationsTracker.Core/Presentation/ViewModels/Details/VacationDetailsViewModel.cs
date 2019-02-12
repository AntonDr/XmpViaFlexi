using System;
using System.Threading.Tasks;
using FlexiMvvm;
using FlexiMvvm.Collections;
using FlexiMvvm.Commands;
using VacationsTracker.Core.DataAccess;
using VacationsTracker.Core.Domain;
using VacationsTracker.Core.Navigation;

namespace VacationsTracker.Core.Presentation.ViewModels.Details
{
    public class VacationDetailsViewModel : ViewModelBase<VacationDetailsParameters>
    {
        private readonly INavigationService _navigationService;
        private readonly IVacationsRepository _vacationsRepository;
        private DateTime _startDate;
        private DateTime _endDate;
        private VacationType _type;
        private VacationStatus _status;

        public VacationDetailsViewModel(
            INavigationService navigationService,
            IVacationsRepository vacationsRepository)
        {
            _navigationService = navigationService;
            _vacationsRepository = vacationsRepository;
        }

        public VacationCellViewModel Vacation { get; set; }

        public ICommand SaveCommand => CommandProvider.Get(Save);

        private async void Save()
        {
            Vacation.Start = StartDate;
            Vacation.End = EndDate;
            Vacation.Status = Status;
            Vacation.Type = Type;

            await _vacationsRepository.UpdateVacationAsync(Vacation);
            _navigationService.NavigateBackToHome(this);
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

        protected override async Task InitializeAsync(VacationDetailsParameters parameters)
        {
            await base.InitializeAsync(parameters);

            Vacation = await _vacationsRepository.GetVacationAsync(parameters.NotNull().VacationId);


            Type = Vacation.Type;
            Status = Vacation.Status;
            StartDate = Vacation.Start;
            EndDate = Vacation.End;
        }
    }
}
