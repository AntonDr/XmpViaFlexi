using System.Threading;
using System.Threading.Tasks;
using VacationsTracker.Core.Presentation.ViewModels;

namespace VacationsTracker.Core.DataAccess.Interfaces
{
    public interface IUserRepository
    {
        Task AuthorizeAsync(UserModel userModel, CancellationToken cancellationToken);

        Task<string> AuthorizationAsync();

        Task Logout();
    }
}