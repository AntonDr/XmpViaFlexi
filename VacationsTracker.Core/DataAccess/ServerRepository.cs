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

        private readonly IVacationAPI _vacationApi;

        private string BaseUrl => "http://localhost:5000/api/vts/workflow";

        public ServerRepository(IVacationAPI vacationApi)
        {
            _vacationApi = vacationApi;
        }

        public async Task<IEnumerable<VacationCellViewModel>> GetVacationsAsync()
        {
            var result = await _vacationApi.GetAsync<BaseResultOfVacationRequests>(BaseUrl);

            return Mapper.Map<IEnumerable<VacationDto>,IEnumerable<VacationCellViewModel>>(result.Result);
            
        }

        public async Task<VacationCellViewModel> GetVacationAsync(string vacationId)
        {
            var result = await _vacationApi.GetAsync<BaseResultOfVacationRequest>(BaseUrl + $@"\{vacationId}");

            return Mapper.Map<VacationDto, VacationCellViewModel>(result.Result);
        }

        public async Task UpsertVacationAsync(VacationCellViewModel vacation)
        {
            var vacationDto = Mapper.Map<VacationCellViewModel, VacationDto>(vacation);

            await _vacationApi.PostAsync(BaseUrl, vacationDto);
        }
    }
}
