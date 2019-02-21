using FlexiMvvm;
using FlexiMvvm.Collections;
using FlexiMvvm.Commands;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using FlexiMvvm.Operations;
using VacationsTracker.Core.DataAccess.Interfaces;
using VacationsTracker.Core.Domain;
using VacationsTracker.Core.Domain.Exceptions;
using VacationsTracker.Core.Navigation;
using VacationsTracker.Core.Operations;

namespace VacationsTracker.Core.Presentation.ViewModels.Details
{
    public class VacationDetailsViewModel : ViewModelBase<VacationDetailsParameters>
    {
        private readonly INavigationService _navigationService;
        private readonly IVacationsRepository _vacationsRepository;
        private string _vacationId;
        private DateTime _startDate;
        private DateTime _endDate;
        private VacationType _type;
        private VacationStatus _status;
        private bool _loaded;

        public VacationDetailsViewModel(
            INavigationService navigationService,
            IVacationsRepository vacationsRepository,
            IOperationFactory operationFactory) : base(operationFactory)
        {
            _navigationService = navigationService;
            _vacationsRepository = vacationsRepository;
        }

        public VacationCellViewModel Vacation { get; set; }

        public ICommand SaveCommand => CommandProvider.GetForAsync(Save);

        public ICommand DeleteCommand => CommandProvider.GetForAsync(Delete);

        private Task Save()
        {
            Vacation.Start = StartDate;
            Vacation.End = EndDate;
            Vacation.Status = Status;
            Vacation.Type = Type;

            return OperationFactory
                .CreateOperation(OperationContext)
                .WithInternetConnectionCondition()
                .WithLoadingNotification()
                .WithExpressionAsync(token => _vacationsRepository.UpsertVacationAsync(Vacation))
                .OnSuccess(() => _navigationService.NavigateBackToHome(this))
                .OnError<InternetConnectionException>(_ => { })
                .OnError<Exception>(er => Debug.WriteLine(er.Exception))
                .ExecuteAsync();
        }

        private Task Delete()
        {
            return OperationFactory
                .CreateOperation(OperationContext)
                .WithInternetConnectionCondition()
                .WithLoadingNotification()
                .WithExpressionAsync(token => _vacationsRepository.DeleteVacationAsync(_vacationId))
                .OnSuccess(() => _navigationService.NavigateBackToHome(this))
                .OnError<InternetConnectionException>(_ => { })
                .OnError<Exception>(error => Debug.WriteLine(error.Exception))
                .ExecuteAsync();
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

        public bool Loaded
        {
            get => _loaded;
            set => Set(ref _loaded, value);
        }

        protected override async Task InitializeAsync(VacationDetailsParameters parameters)
        {
            await base.InitializeAsync(parameters);

            await OperationFactory
                .CreateOperation(OperationContext)
                .WithInternetConnectionCondition()
                .WithLoadingNotification()
                .WithExpressionAsync(token =>
                {
                    var id = parameters.NotNull().VacationId;
                    return _vacationsRepository.GetVacationAsync(id);
                })
                .OnSuccess(vacation => (_vacationId, StartDate, EndDate, Status, Type) = vacation)
                .OnSuccess(vacation =>
                {
                    (_vacationId, StartDate, EndDate, Status, Type) = vacation;
                    Loaded = true;
                })
                .OnError<InternetConnectionException>(_ => { })
                .OnError<Exception>(error => Debug.WriteLine(error.Exception))
                .ExecuteAsync();
        }
    }
}
