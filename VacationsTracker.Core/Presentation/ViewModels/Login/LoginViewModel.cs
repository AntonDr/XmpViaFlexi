using System;
using System.Diagnostics;
using System.Security.Authentication;
using System.Threading.Tasks;
using FlexiMvvm;
using FlexiMvvm.Commands;
using FlexiMvvm.Operations;
using VacationsTracker.Core.DataAccess;
using VacationsTracker.Core.DataAccess.Interfaces;
using VacationsTracker.Core.Navigation;
using VacationsTracker.Core.Operations;

namespace VacationsTracker.Core.Presentation.ViewModels.Login
{
    public class LoginViewModel : ViewModelBase , IViewModelWithOperation
    {
        private readonly INavigationService _navigationService;
        private readonly IUserRepository _userRepository;
        private bool _loading;
        private bool _invalidCredentials;

        public bool InvalidCredentials
        {
            get => _invalidCredentials;
            set => Set(ref _invalidCredentials, value);
        }

        public LoginViewModel(INavigationService navigationService,IUserRepository userRepository, IOperationFactory operationFactory):base(operationFactory)
        {
            _navigationService = navigationService;
            _userRepository = userRepository;
        }

        public bool Loading
        {
            get => _loading;
            set => Set(ref _loading, value);
        }

        public ICommand LoginCommand => CommandProvider.GetForAsync(Login);

        public string UserLogin { get; set; }

        public string UserPassword { get; set; }

        private Task Login()
        {
            return OperationFactory.CreateOperation(OperationContext)
                .WithLoadingNotification()
                .WithInternetConnectionCondition()
                .WithExpressionAsync(cancellationToken =>
                {
                    Loading = true;

                    var user = new UserModel
                    {
                        Login = UserLogin,
                        Password = UserPassword
                    };

                    return _userRepository.AuthorizeAsync(user,cancellationToken);
                })
                .OnSuccess(() => _navigationService.NavigateToHome(this))
                .OnError<AuthenticationException>( _ => InvalidCredentials = true)
                .ExecuteAsync();
        }

    }
}
