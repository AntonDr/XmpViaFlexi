using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VacationsTracker.Core.Presentation.ViewModels;

namespace VacationsTracker.Core.DataAccess
{
    public interface IVacationsRepository
    {
        Task<IEnumerable<VacationCellViewModel>> GetVacationsAsync();
    }
}
