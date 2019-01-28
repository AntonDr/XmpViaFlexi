using FlexiMvvm;
using System;
using VacationsTracker.Core.Domain;

namespace VacationsTracker.Core.Presentation.ViewModels
{
    public class VacationCellViewModel : ObservableObjectBase
    {
        private VacationType _vacationType;

        private DateTime _startDate;

        private DateTime _endDate;

        private VacationStatus _status;

        public VacationType VacationType
        {
            get => _vacationType;
            set => Set(ref _vacationType, value);
        }

        public string Duration
        {
            get => _startDate.ToString("MMM dd").ToUpper() + "-" + _endDate.ToString("MMM dd").ToUpper();
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

        public VacationStatus Status
        {
            get => _status;
            set => Set(ref _status,value);
        }
    }
}
