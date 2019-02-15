using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VacationsTracker.Core.DataAccess
{
    public interface IVacationAPI
    {
        Task<T> GetAsync<T>(string url);
        //{
        //    var result = _client.GetAsync(url);
        //    var obj = Deserialize<T>(result.body);

        //    return obj;
        //}
        Task<T> PostAsync<T>(string url,T obj);
        Task<T> DeleteAsync<T>(string url);

    }
}
