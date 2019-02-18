using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using VacationsTracker.Core.DTO;
using VacationsTracker.Core.Presentation.ViewModels;

namespace VacationsTracker.Core.DataAccess
{
    public class ServerRepository : IVacationsRepository
    {

        private readonly IVacationApi _vacationApi;

        public ServerRepository(IVacationApi vacationApi)
        {
            _vacationApi = vacationApi;
        }

        public async Task<IEnumerable<VacationCellViewModel>> GetVacationsAsync()
        {
            var result = await _vacationApi.GetVacationsAsync();

            return Mapper.Map<IEnumerable<VacationDto>,IEnumerable<VacationCellViewModel>>(result);
            
        }

        public async Task<VacationCellViewModel> GetVacationAsync(string vacationId)
        {
            var result = await _vacationApi.GetVacationAsync(vacationId);

            return Mapper.Map<VacationDto, VacationCellViewModel>(result);
        }

        public async Task UpsertVacationAsync(VacationCellViewModel vacation)
        {
            var vacationDto = Mapper.Map<VacationCellViewModel, VacationDto>(vacation);

            await _vacationApi.UpsertVacationAsync(vacationDto);
        }
    }
}
