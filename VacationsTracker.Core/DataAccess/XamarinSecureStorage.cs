using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Xamarin.Essentials;

namespace VacationsTracker.Core.DataAccess
{
    public class XamarinSecureStorage : ISecureStorage
    {
        public async Task<string> GetAsync([NotNull]string key)
        {
            return await SecureStorage.GetAsync(key);
        }

        public async Task SetAsync([NotNull]string key,[NotNull] string value)
        {
            await SecureStorage.SetAsync(key, value);
        }

        public bool Remove([NotNull]string key)
        {
            return SecureStorage.Remove(key);
        }
    }
}
