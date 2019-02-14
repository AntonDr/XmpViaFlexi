using System.Threading.Tasks;
using FlexiMvvm;

namespace VacationsTracker.Core.DataAccess
{
    public class UserRepository : IUserRepository
    {
        public Task<bool> AuthorizeAsync(string login, string password)
        {
            return Task.FromResult(login == "login" && password == "password");
        }
    }
}