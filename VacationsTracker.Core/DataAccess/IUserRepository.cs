using System.Threading.Tasks;

namespace VacationsTracker.Core.DataAccess
{
    public interface IUserRepository
    {
        Task AuthorizeAsync(string login, string password);
    }
}