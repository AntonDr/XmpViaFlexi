using System;
using System.Diagnostics;
using System.Security.Authentication;
using System.Threading.Tasks;
using FlexiMvvm;
using FlexiMvvm.Commands;
using FlexiMvvm.Operations;
using VacationsTracker.Core.DataAccess;
using VacationsTracker.Core.Navigation;
using VacationsTracker.Core.Operations;

namespace VacationsTracker.Core.Presentation.ViewModels.Login
{
    public class LoginViewModel : ViewModelBase , IViewModelWithOperation
    {
        private readonly INavigationService _navigationService;
        private readonly IUserRepository _userRepository;
        private bool _loading;

        public bool ValidCredentials { get; set; } = true;

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
                .WithExpressionAsync(cancellationToken => _userRepository.AuthorizeAsync(UserLogin, UserPassword))
                .OnSuccess(() => _navigationService.NavigateToHome(this))
                .OnError<AuthenticationException>( _ => ValidCredentials = false)
                .ExecuteAsync();
        }

    }
}
