using System;
using System.Collections.Generic;
using System.Text;

namespace VacationsTracker.Core.Presentation.ViewModels
{
    public interface IViewModelWithOperation
    {
        bool Loading { get; set; }
    }
}
