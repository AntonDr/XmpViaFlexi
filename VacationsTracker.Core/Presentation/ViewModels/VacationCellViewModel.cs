using FlexiMvvm;

namespace VacationsTracker.Core.Presentation.ViewModels
{
    public class VacationCellViewModel : ObservableObjectBase
    {
        private string _vacationType;

        public string VacationType
        {
            get => _vacationType;
            set => Set(ref _vacationType, value);
        }
    }
}
