using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using RestSharp;
using RestSharp.Authenticators;

namespace VacationsTracker.Core.DataAccess
{
    internal class ServerContext : IContext
    {
        private readonly RestClient _client;

        private readonly string BaseUrl = "https://vts-v2.azurewebsites.net/api/vts/workflow";

        public ServerContext(ISecureStorage storage)
        {
            var token = storage.GetAsync("id_token").Result;
            _client = new RestClient
            {
                BaseUrl = new Uri("https://vts-v2.azurewebsites.net/api/vts/workflow"),
                Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(token, "Bearer")
            };

            _client = new RestClient(BaseUrl);
            _client.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator("eyJhbGciOiJSUzI1NiIsImtpZCI6ImEyNmQyNGY2NTYyMzVhNjcxZmNlMzBmZmNiN2UwNmMzIiwidHlwIjoiSldUIn0.eyJuYmYiOjE1NTA0OTYzMzcsImV4cCI6MTU1MDQ5OTkzNywiaXNzIjoiaHR0cHM6Ly92dHMtdG9rZW4taXNzdWVyLXYyLmF6dXJld2Vic2l0ZXMubmV0IiwiYXVkIjpbImh0dHBzOi8vdnRzLXRva2VuLWlzc3Vlci12Mi5henVyZXdlYnNpdGVzLm5ldC9yZXNvdXJjZXMiLCJWVFMtU2VydmVyLXYyIl0sImNsaWVudF9pZCI6IlZUUy1Td2FnZ2VyLXYxIiwic3ViIjoiMSIsImF1dGhfdGltZSI6MTU1MDQ5NjIwMywiaWRwIjoibG9jYWwiLCJzY29wZSI6WyJWVFMtU2VydmVyLXYyIl0sImFtciI6WyJwd2QiXX0.bbAO5hLg0IbAt7bPIMbsDGbccTrMMotDbJVw3Jpd2PmosIv86O-Xq1XaO2eMEK8KShKNHcNqBht7Y3IAQWTm_MwoR2-YXR10FAU1cbGQ8wr_8353inuQij08BXGNlmVgmBxontOrRUOjw7FAObMCrsjWjM1-DcrorADi57M_AX_SHQJJoK8T3Y4YyRFL27ML0f92ijKg67oettFEoSUE_2hKabMZaxmCApbeVWpvmSvpxsDRMh4FYLMtLpE7SIKRY3o8FEqwbbEfcx0msN0NsrPKmj-kPBYkEgDLG5z6CAKSgw5J1YD2rx9cHDtCN-DJh-kixH3rJF0pOR7WMrvl8A", "Bearer");
        }


        public async Task<T> GetAsync<T>(string url) where T : new()
        {
            var request = new RestRequest(url,Method.GET);
            
            return await _client.GetAsync<T>(request);
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(string resource, TRequest requestBody) where TResponse : new()
        {
            var request = new RestRequest(resource);

            request.AddHeader("Content-type", "application/json");

            request.AddJsonBody(requestBody);

            return await _client.PostAsync<TResponse>(request);
        }

        
        public async Task<T> DeleteAsync<T>(string url) where T : new()
        {
            var request = new RestRequest(url);

            return await _client.DeleteAsync<T>(request);
        }
    }
}
