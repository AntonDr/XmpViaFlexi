using System;
using Android;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using FlexiMvvm.Views.V7;
using VacationsTracker.Core.Presentation.ViewModels.Login;

namespace VacationsTracker.Droid.Views.Login
{
    [Activity(Label = "LoginActivity", Theme = "@style/AppTheme")]
    public class LoginActivity : FlxAppCompatActivity<LoginViewModel>
    {
        private LoginActivityViewHolder ViewHolder { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_login);

            ViewHolder = new LoginActivityViewHolder(this);

            ViewHolder.LoginButton.Click += LoginButton_Click;
        }

        private void LoginButton_Click(object sender, EventArgs args)
        {
            ViewHolder.InvalidCredentialsText.Visibility = ViewStates.Visible;
        }

    }
}