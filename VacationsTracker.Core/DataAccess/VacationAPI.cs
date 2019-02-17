using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VacationsTracker.Core.DataAccess
{
    internal class VacationAPI : IVacationApi
    {
        private readonly HttpClient _httpClient;

        public VacationAPI()
        {
            _httpClient = new HttpClient();
        }

        public async Task<T> GetAsync<T>(string url)
        {
            var response = await _httpClient.GetAsync(url);

            var json = await response.Content.ReadAsStringAsync();

            var obj = JsonConvert.DeserializeObject<T>(json);

            return obj;
        }

        public async Task PostAsync<T>(string url, T obj)
        {
            var json = JsonConvert.SerializeObject(obj);

            var content = new StringContent(json,Encoding.UTF8, "application/json");

            await _httpClient.PostAsync(url, content);
        }

        public async Task DeleteAsync(string url)
        {
            await _httpClient.DeleteAsync(url);
        }
    }
}
