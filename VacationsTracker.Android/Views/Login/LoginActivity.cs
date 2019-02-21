using Android.Animation;
using Android.App;
using Android.OS;
using Android.Widget;
using FlexiMvvm.Bindings;
using FlexiMvvm.Views.V7;
using Java.Interop;
using VacationsTracker.Core.Presentation.ViewModels.Login;
using VisibilityValueConverter = VacationsTracker.Droid.Views.ValueConverters.VisibilityValueConverter;

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

            //var projectAnimator = ObjectAnimator.OfInt(ViewHolder.ProgressBar,);
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
                .For(v => v.TextAndTextChangedBinding())
                .To(vm => vm.UserPassword);

            bindingSet.Bind(ViewHolder.LoginButton)
                .For(v => v.ClickBinding())
                .To(vm => vm.LoginCommand);

            bindingSet.Bind(ViewHolder.ProgressBar)
                .For(v => v.Visibility)
                .To(vm => vm.Loading)
                .WithConvertion<VisibilityValueConverter>();

            bindingSet.Bind(ViewHolder.LoginButton)
                .For(v => v.Enabled)
                .To(vm => vm.Loading)
                .WithConvertion<InvertValueConverter>();

            bindingSet.Bind(ViewHolder.LoginEntry)
                .For(v => v.Enabled)
                .To(vm => vm.Loading)
                .WithConvertion<InvertValueConverter>();

            bindingSet.Bind(ViewHolder.PasswordEntry)
                .For(v => v.Enabled)
                .To(vm => vm.Loading)
                .WithConvertion<InvertValueConverter>();

            
        }
    }
}