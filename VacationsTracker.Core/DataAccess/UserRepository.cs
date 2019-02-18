using System.Security.Authentication;
using System.Threading.Tasks;
using FlexiMvvm;

namespace VacationsTracker.Core.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly ISecureStorage _storage;

        public UserRepository(ISecureStorage storage)
        {
            _storage = storage;
        }

        public async Task AuthorizeAsync(string login, string password)
        {
            if (login != "login" || password != "password")
            {
                throw new AuthenticationException();
            }

            var token = "eyJhbGciOiJSUzI1NiIsImtpZCI6ImEyNmQyNGY2NTYyMzVhNjcxZmNlMzBmZmNiN2UwNmMzIiwidHlwIjoiSldUIn0.eyJuYmYiOjE1NTA0OTQxNDMsImV4cCI6MTU1MDQ5Nzc0MywiaXNzIjoiaHR0cHM6Ly92dHMtdG9rZW4taXNzdWVyLXYyLmF6dXJld2Vic2l0ZXMubmV0IiwiYXVkIjpbImh0dHBzOi8vdnRzLXRva2VuLWlzc3Vlci12Mi5henVyZXdlYnNpdGVzLm5ldC9yZXNvdXJjZXMiLCJWVFMtU2VydmVyLXYyIl0sImNsaWVudF9pZCI6IlZUUy1Td2FnZ2VyLXYxIiwic3ViIjoiMSIsImF1dGhfdGltZSI6MTU1MDQ5MjU3OCwiaWRwIjoibG9jYWwiLCJzY29wZSI6WyJWVFMtU2VydmVyLXYyIl0sImFtciI6WyJwd2QiXX0.ERg9mXlmAEilC45VsiUy-rxN2-bc9eNAe6RKScYtMEMrZBQLGfuww9xcX91OEr1LRcumSWaPw6N1bmJI90ZBbitg7sOeNvziiBambJyiI-olbfVZung8A0mMKjKLam-U97b5GHJJ1E2sxy7f4g1Lu3khKDrGrPk63Vk-osIuS9g1xm1fkQh1lgiwksjSjp8Q3flaiMS1NrsN7uDRpMJxiW5ddQTBVMnYkeb_vs9uYLFQtmZtOI54ow5kZmTrvsvnSxUV1vpAyZBGFgkSASEhOt-YGeV45-s0va4VQL31PqRfuHmZBfWzc7ud6903prDBikDgZ4e3QOmJ4WAT6jOH3g";
            await _storage.SetAsync("id_token", token);
        }
    }
}