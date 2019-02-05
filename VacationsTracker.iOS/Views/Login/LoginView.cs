using Cirrious.FluentLayouts.Touch;
using FlexiMvvm.Views;
using UIKit;
using VacationsTracker.iOS.Themes;

namespace VacationsTracker.iOS.Views.Login
{
    public class LoginView : LayoutView
    { 
        public UITextField LoginTextField { get; set; }

        public UITextField PasswordTextField { get; private set; }
        public UIButton LoginButton { get; private set; }
        public UIImageView BackgroundImage { get; set; }
        protected override void SetupSubviews()
        {
            base.SetupSubviews();

            LoginTextField = new UITextField().SetDefaultTextFieldStyle("Login");

            PasswordTextField = new UITextField().SetDefaultTextFieldStyle("Password");

            BackgroundImage = new UIImageView().SetDefaultBackgroundImage();

            LoginButton = new UIButton().SetPrimaryButtonStyle("SIGN IN");
        }

        protected override void SetupLayout()
        {
            base.SetupLayout();

            this.AddLayoutSubview(BackgroundImage)
                .AddLayoutSubview(LoginTextField)
                .AddLayoutSubview(PasswordTextField)
                .AddLayoutSubview(LoginButton);
        }

        protected override void SetupLayoutConstraints()
        {
            base.SetupLayoutConstraints();

            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            this.AddConstraints(
                LoginTextField.AtLeftOf(this, AppDimens.Inset1X),
                LoginTextField.AtRightOf(this, AppDimens.Inset1X),
                LoginTextField.Height().EqualTo(AppDimens.Inset6X),
                LoginTextField.Above(PasswordTextField, AppDimens.Inset3X));

            this.AddConstraints(
                PasswordTextField.WithSameLeft(LoginTextField),
                PasswordTextField.WithSameCenterY(this),
                PasswordTextField.WithSameRight(LoginTextField),
                PasswordTextField.Height().EqualTo(AppDimens.Inset6X));

            this.AddConstraints(
                LoginButton.AtLeftOf(this,AppDimens.Inset2X),
                LoginButton.AtRightOf(this,AppDimens.Inset2X),
                LoginButton.Height().EqualTo(AppDimens.DefaultButtonSize),
                LoginButton.Below(PasswordTextField,AppDimens.Inset1X));

            this.AddConstraints(
                BackgroundImage.WithSameLeft(this),
                BackgroundImage.WithSameTop(this),
                BackgroundImage.WithSameRight(this),
                BackgroundImage.WithSameBottom(this));
        }
    }
}