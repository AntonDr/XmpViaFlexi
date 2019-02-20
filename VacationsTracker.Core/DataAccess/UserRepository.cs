using IdentityModel;
using System.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;
using IdentityModel.Client;
using VacationsTracker.Core.DataAccess.Interfaces;
using VacationsTracker.Core.Presentation.ViewModels;

namespace VacationsTracker.Core.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly ISecureStorage _storage;

        private readonly string _tokenId = "id_token";

        public UserRepository(ISecureStorage storage)
        {
            _storage = storage;
        }

        public async Task AuthorizeAsync(UserModel userModel, CancellationToken cancellationToken)
        {
            var identityServer = await DiscoveryClient.GetAsync(Info.IdentityServiceUrl);

           // var discoveryClient = new DiscoveryClient(Info.LocalIdentityServiceUrl) {Policy =};
            //var identityServer = await discoveryClient.GetAsync();

            if (identityServer.IsError)
            {
                throw new AuthenticationException("ddd");
            }

            var authClient = new TokenClient(
                identityServer.TokenEndpoint,
                Info.ClientId,
                Info.ClientSecret);

            var userTokenResponse = await authClient.RequestResourceOwnerPasswordAsync(
                userModel.Login,
                userModel.Password,
                Info.Scope,
                cancellationToken, cancellationToken: cancellationToken);

            if (userTokenResponse.IsError || userTokenResponse.AccessToken == null)
            {
                throw new AuthenticationException("dda");
            }

            await _storage.SetAsync(_tokenId, userTokenResponse.AccessToken);

        }

        public async Task<string> AuthorizationAsync()
        {
            var token = await _storage.GetAsync(_tokenId);

            if (token == null)
            {
                throw new AuthenticationException();
            }

            return token;
        }

        public Task Logout()
        {
            _storage.Remove(_tokenId);

            return Task.CompletedTask;
        }
    }

}