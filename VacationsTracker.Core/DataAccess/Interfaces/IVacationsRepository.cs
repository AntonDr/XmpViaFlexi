using System.Collections.Generic;
using System.Threading.Tasks;
using VacationsTracker.Core.Presentation.ViewModels;

namespace VacationsTracker.Core.DataAccess.Interfaces
{
    public interface IVacationsRepository
    {
        Task<IEnumerable<VacationCellViewModel>> GetVacationsAsync();

        Task<VacationCellViewModel> GetVacationAsync(string vacationId);

        Task UpsertVacationAsync(VacationCellViewModel vacation);

        Task DeleteVacationAsync(string id);
    }
}
