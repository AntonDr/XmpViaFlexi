using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VacationsTracker.Core.DataAccess.Interfaces;
using VacationsTracker.Core.DTO;

namespace VacationsTracker.Core.DataAccess
{
    internal class VacationApi : IVacationApi
    {
        private readonly IContext _context;

        public VacationApi(IContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VacationDto>> GetVacationsAsync()
        {
            var response = await _context.GetAsync<BaseResultOfVacationRequests>(string.Empty);

            return response.Result;
        }

        public async Task<VacationDto> GetVacationAsync(string id)
        {
            var response = await _context.GetAsync<BaseResultOfVacationRequest>($"/{id}");

            return response.Result;
        }

        public async Task<VacationDto> UpsertVacationAsync(VacationDto vacation)
        {
            if (vacation.Id == Guid.Empty.ToString())
            {
                vacation.Created = DateTime.MinValue;
            }

            var response = await _context.PostAsync<VacationDto, BaseResultOfVacationRequest>(string.Empty, vacation);

            return response.Result;
        }

        public async Task DeleteVacationAsync(string id)
        {
            await _context.DeleteAsync<BaseResultOfVacationRequest>($"/{id}");
        }
    }
}
