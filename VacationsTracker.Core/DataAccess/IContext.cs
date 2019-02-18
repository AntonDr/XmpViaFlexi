using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace VacationsTracker.Core.DataAccess
{
    interface IContext 
    {
        Task<TResponse> GetAsync<TResponse>(string resource) 
            where TResponse : new();

        Task<TResponse> PostAsync<TRequest, TResponse>(string resource, TRequest requestBody)  
            where TResponse : new();
    }
}
