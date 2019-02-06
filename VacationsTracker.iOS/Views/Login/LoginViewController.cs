using FlexiMvvm;
using FlexiMvvm.Bindings;
using FlexiMvvm.Views;
using VacationsTracker.Core.Presentation.ViewModels.Login;

namespace VacationsTracker.iOS.Views.Login
{
    public class LoginViewController : FlxBindableViewController<LoginViewModel>
    {
        public new LoginView View
        {
            get => (LoginView)base.View.NotNull();
            set => base.View = value;
        }

        public override void LoadView()
        {
            View = new LoginView();
        }

        public override void Bind(BindingSet<LoginViewModel> bindingSet)
        {
            bindingSet.Bind(View.LoginButton)
                .For(v => v.TouchUpInsideBinding())
                .To(vm => vm.LoginCommand);

            bindingSet.Bind(View.InvalidCredentialsLabel)
                .For(v => v.Hidden)
                .To(vm => vm.ValidCredentials);
        }
    }
}