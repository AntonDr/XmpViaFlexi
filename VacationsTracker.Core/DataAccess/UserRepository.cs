using System.Threading.Tasks;
using FlexiMvvm;

namespace VacationsTracker.Core.DataAccess
{
    public class UserRepository : IUserRepository
    {
        public Task AuthorizeAsync(string login, string password)
        {
            return Task.FromResult(login == "login" && password == "password");
        }
    }
}