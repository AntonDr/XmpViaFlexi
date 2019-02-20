using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using VacationsTracker.Core.DataAccess.Interfaces;
using VacationsTracker.Core.DTO;
using VacationsTracker.Core.Presentation.ViewModels;

namespace VacationsTracker.Core.DataAccess
{
    public class ServerRepository : IVacationsRepository
    {

        private readonly IVacationApi _vacationApi;
        private readonly IMapper _mapper;

        public ServerRepository(IVacationApi vacationApi,IMapper mapper)
        {
            _vacationApi = vacationApi;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VacationCellViewModel>> GetVacationsAsync()
        {
            var result = await _vacationApi.GetVacationsAsync();


            return _mapper.Map<IEnumerable<VacationDto>, IEnumerable<VacationCellViewModel>>(result);

        }

        public async Task<VacationCellViewModel> GetVacationAsync(string vacationId)
        {
            var result = await _vacationApi.GetVacationAsync(vacationId);

            return _mapper.Map<VacationDto, VacationCellViewModel>(result);
        }

        public async Task UpsertVacationAsync(VacationCellViewModel vacation)
        {
            var vacationDto = _mapper.Map<VacationCellViewModel, VacationDto>(vacation);

            await _vacationApi.UpsertVacationAsync(vacationDto);
        }
    }
}
