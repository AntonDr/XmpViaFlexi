using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VacationsTracker.Core.DataAccess
{
    public interface IVacationApi
    {
        Task<T> GetAsync<T>(string url);

        Task PostAsync<T>(string url, T obj);

        Task DeleteAsync(string url);

    }
}
