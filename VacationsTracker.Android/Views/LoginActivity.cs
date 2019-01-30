using Android.App;
using Android.OS;
using FlexiMvvm.Views.V7;
using VacationsTracker.Core.Presentation.ViewModels;
using VacationsTracker.Core.Presentation.ViewModels.Login;

namespace VacationsTracker.Android.Views
{
    [Activity(Label = "LoginActivity")]
    public class LoginActivity : FlxAppCompatActivity<LoginViewModel>
    {
        private LoginActivityViewHolder ViewHolder { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_login);

            ViewHolder = new LoginActivityViewHolder(this);
        }
    }
}