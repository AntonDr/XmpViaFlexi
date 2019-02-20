using Android.App;
using Android.OS;
using FlexiMvvm.Bindings;
using FlexiMvvm.Views.V7;
using VacationsTracker.Core.Presentation.ViewModels.Login;
using VacationsTracker.Droid.Views.ValueConverters;

namespace VacationsTracker.Droid.Views.Login
{
    [Activity(
        Label = "LoginActivity",
        Theme = "@style/AppTheme")]
    public class LoginActivity : FlxBindableAppCompatActivity<LoginViewModel>
    {
        private LoginActivityViewHolder ViewHolder { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_login);

            ViewHolder = new LoginActivityViewHolder(this);
        }

        public override void Bind(BindingSet<LoginViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(ViewHolder.InvalidCredentialsText)
                .For(v => v.Visibility)
                .To(vm => vm.InvalidCredentials)
                .WithConvertion<VisibilityValueConverter>();

            bindingSet.Bind(ViewHolder.LoginEntry)
                .For(v => v.TextAndTextChangedBinding())
                .To(vm => vm.UserLogin);

            bindingSet.Bind(ViewHolder.PasswordEntry)
                .For(vm => vm.TextAndTextChangedBinding())
                .To(v => v.UserPassword);

            bindingSet.Bind(ViewHolder.LoginButton)
                .For(v => v.ClickBinding())
                .To(vm => vm.LoginCommand);

            bindingSet.Bind(ViewHolder.ProgressBar)
                .For(v => v.Visibility)
                .To(vm => vm.Loading)
                .WithConvertion<VisibilityValueConverter>();
        }
    }
}