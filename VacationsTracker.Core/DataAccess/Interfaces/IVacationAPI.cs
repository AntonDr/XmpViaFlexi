using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using VacationsTracker.Core.DTO;

namespace VacationsTracker.Core.DataAccess.Interfaces
{
    public interface IVacationApi
    {
        Task<IEnumerable<VacationDto>> GetVacationsAsync();

        Task<VacationDto> GetVacationAsync([NotNull] string id);

        Task<VacationDto> UpsertVacationAsync([NotNull] VacationDto vacation);

        Task DeleteVacationAsync([NotNull] string id);
    }
}
