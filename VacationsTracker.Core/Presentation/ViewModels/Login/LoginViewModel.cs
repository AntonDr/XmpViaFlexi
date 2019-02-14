using System;
using System.Diagnostics;
using System.Threading.Tasks;
using FlexiMvvm;
using FlexiMvvm.Commands;
using FlexiMvvm.Operations;
using VacationsTracker.Core.DataAccess;
using VacationsTracker.Core.Navigation;

namespace VacationsTracker.Core.Presentation.ViewModels.Login
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IUserRepository _userRepository;

        public bool ValidCredentials { get; set; } = true;

        public LoginViewModel(INavigationService navigationService,IUserRepository userRepository, IOperationFactory operationFactory):base(operationFactory)
        {
            _navigationService = navigationService;
            _userRepository = userRepository;
        }

        public ICommand LoginCommand => CommandProvider.GetForAsync(Login);

        public string UserLogin { get; set; }

        public string UserPassword { get; set; }

        private async Task Login()
        {
            await Task.Delay(500);

            await OperationFactory.CreateOperation(OperationContext)
                .WithExpressionAsync(cancellationToken => _userRepository.AuthorizeAsync(UserLogin, UserPassword))
                .OnSuccess(isSuccess =>
                {
                    Debug.WriteLine("Trying navigate");
                    if (isSuccess)
                    {
                        _navigationService.NavigateToHome(this);
                    }
                })
                .OnError<Exception>(error => Debug.WriteLine(error.Exception.Message))
                .ExecuteAsync();
        }
    }
}
