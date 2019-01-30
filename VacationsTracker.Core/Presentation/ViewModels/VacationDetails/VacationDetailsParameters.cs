using System;
using System.Collections.Generic;
using System.Text;
using FlexiMvvm;

namespace VacationsTracker.Core.Presentation.ViewModels.VacationDetails
{
    public class VacationDetailsParameters : ViewModelBundleBase
    {
        public string VacationId
        {
            get => Bundle.GetString();
            set => Bundle.SetString(value);
        }
    }
}
