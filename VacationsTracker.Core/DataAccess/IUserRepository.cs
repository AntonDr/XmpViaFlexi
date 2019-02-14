using System.Threading.Tasks;

namespace VacationsTracker.Core.DataAccess
{
    public interface IUserRepository
    {
        Task<bool> AuthorizeAsync(string login, string password);
    }
}