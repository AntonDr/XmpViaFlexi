using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VacationsTracker.Core.DTO;
using VacationsTracker.Core.Presentation.ViewModels;

namespace VacationsTracker.Core.DataAccess
{
    public class ServerRepository : IVacationsRepository
    {

        private readonly IVacationAPI _vacationApi;

        private string GetAllUrl => "http://localhost:5000/api/vts/workflow";

        private string PostUrl => "http://localhost:5000/api/vts/workflow";
        public ServerRepository(IVacationAPI vacationApi)
        {
            _vacationApi = vacationApi;
        }

        public async Task<IEnumerable<VacationCellViewModel>> GetVacationsAsync()
        {
            var result = await _vacationApi.GetAsync<BaseResultOfVacationRequests>(GetAllUrl);

            var vacations = result.Result;

        }

        public Task<VacationCellViewModel> GetVacationAsync(string vacationId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateVacationAsync(VacationCellViewModel vacation)
        {
            throw new NotImplementedException();
        }

        public Task CreateVacationAsync(VacationCellViewModel vacation)
        {
            throw new NotImplementedException();
        }
    }
}
