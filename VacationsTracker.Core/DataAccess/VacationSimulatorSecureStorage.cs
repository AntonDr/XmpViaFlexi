using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using VacationsTracker.Core.DataAccess.Interfaces;

namespace VacationsTracker.Core.DataAccess
{
    public class VacationSimulatorSecureStorage : ISecureStorage
    {
        private static readonly ConcurrentDictionary<string, string> DictionarySessionStorage;

        static VacationSimulatorSecureStorage()
        {
            DictionarySessionStorage = new ConcurrentDictionary<string, string>();
        }

        public async Task<string> GetAsync(string key)
        {
            try
            {
                await Task.Delay(0);
                DictionarySessionStorage.TryGetValue(key, out string value);
                return value;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        public bool Remove(string key)
        {
            try
            {
                return DictionarySessionStorage.TryRemove(key, out _);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        public async Task SetAsync(string key, string value)
        {
            try
            {
                await Task.Delay(0);
                DictionarySessionStorage.TryAdd(key, value);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }
    }
}
