using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FlexiMvvm;
using VacationsTracker.Core.DataAccess;
using VacationsTracker.Core.Domain;
using VacationsTracker.Core.Navigation;

namespace VacationsTracker.Core.Presentation.ViewModels.VacationDetails
{
    public class VacationDetailsViewModel : ViewModelBase<VacationDetailsParameters>
    {
        private readonly INavigationService _navigationService;
        private readonly IVacationsRepository _vacationsRepository;

        public VacationDetailsViewModel(
            INavigationService navigationService,
            IVacationsRepository vacationsRepository)
        {
            _navigationService = navigationService;
            _vacationsRepository = vacationsRepository;
        }

        public VacationType VacationType { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public VacationStatus VacationStatus { get; set; }

        protected override async Task InitializeAsync(VacationDetailsParameters parameters)
        {
            await base.InitializeAsync(parameters);

            var vacation = await _vacationsRepository.GetVacationAsync(parameters.VacationId);

            VacationType = vacation.Type;
            VacationStatus = vacation.Status;
            StartTime = vacation.Start;
            EndTime = vacation.End;
        }
    }
}
