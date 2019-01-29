using Android.App;
using Android.OS;
using FlexiMvvm.Bindings;
using FlexiMvvm.Views.V7;
using VacationsTracker.Core.Presentation.ViewModels.Login;

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

            SetContentView(Resource.Layout.activity_vacation_details);

            ViewHolder = new LoginActivityViewHolder(this);
        }

        public override void Bind(BindingSet<LoginViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(ViewHolder.LoginButton)
                .For(v => v.ClickBinding())
                .To(vm => vm.LoginCommand);
        }
    }
}