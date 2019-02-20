using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Serialization;
using VacationsTracker.Core.DataAccess.Interfaces;

namespace VacationsTracker.Core.DataAccess
{
    internal class ServerContext : IContext
    {
        private readonly RestClient _client;

        private readonly string BaseUrl = Info.ServiceUrl;

        public ServerContext(ISecureStorage storage)
        {
            var token = storage.GetAsync("id_token").Result;
            _client = new RestClient
            {
                BaseUrl = new Uri(BaseUrl),
                Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(token, "Bearer")
            };
        }


        public async Task<T> GetAsync<T>(string url) where T : new()
        {
            var request = new RestRequest(url,Method.GET);
            
            return await _client.GetAsync<T>(request);
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(string resource, TRequest requestBody) where TResponse : new()
        {
            var request = new RestRequest(resource);

            request.AddParameter(ContentType.Json,requestBody,ParameterType.RequestBody);

            return await _client.PostAsync<TResponse>(request);
        }

        
        public async Task<T> DeleteAsync<T>(string url) where T : new()
        {
            var request = new RestRequest(url);

            return await _client.DeleteAsync<T>(request);
        }
    }
}
