using Cirrious.FluentLayouts.Touch;
using FlexiMvvm.Views;
using UIKit;
using VacationsTracker.Core.Resources;
using VacationsTracker.iOS.Themes;

namespace VacationsTracker.iOS.Views.Login
{
    public class LoginView : LayoutView
    {
        public UIImageView BackgroundImage { get; private set; }

        public UILabel InvalidCredentialsLabel { get; private set; }

        public UITextField LoginTextField { get; private set; }

        public UITextField PasswordTextField { get; private set; }

        public UIButton LoginButton { get; private set; }

        protected override void SetupSubviews()
        {
            base.SetupSubviews();

            BackgroundImage = new UIImageView().SetDefaultBackgroundImage();

            InvalidCredentialsLabel = new UILabel()
                .SetErrorLabelStyle(Strings.LoginPage_Error);

            LoginTextField = new UITextField().SetDefaultTextFieldStyle(Strings.LoginPage_LoginPlaceholder);

            PasswordTextField = new UITextField().SetDefaultTextFieldStyle(Strings.LoginPage_PasswordPlaceholder);

            LoginButton = new UIButton().SetPrimaryButtonStyle(Strings.LoginPage_SignIn);
        }

        protected override void SetupLayout()
        {
            base.SetupLayout();

            this.AddLayoutSubview(BackgroundImage)
                .AddLayoutSubview(InvalidCredentialsLabel)
                .AddLayoutSubview(LoginTextField)
                .AddLayoutSubview(PasswordTextField)
                .AddLayoutSubview(LoginButton);
        }

        protected override void SetupLayoutConstraints()
        {
            base.SetupLayoutConstraints();

            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            this.AddConstraints(BackgroundImage.FullSizeOf(this));

            this.AddConstraints(
                InvalidCredentialsLabel.WithSameLeft(LoginTextField),
                InvalidCredentialsLabel.WithSameRight(LoginTextField),
                InvalidCredentialsLabel.Height().EqualTo(100),
                InvalidCredentialsLabel.Above(LoginTextField, AppDimens.Inset3X));

            this.AddConstraints(
                LoginTextField.AtLeftOf(this, AppDimens.Inset5X),
                LoginTextField.AtRightOf(this, AppDimens.Inset5X),
                LoginTextField.Height().EqualTo(AppDimens.DefaultTextFieldHeight),
                LoginTextField.Above(PasswordTextField, AppDimens.Inset2X));


            this.AddConstraints(
                PasswordTextField.WithSameLeft(LoginTextField),
                PasswordTextField.WithSameCenterY(this),
                PasswordTextField.WithSameRight(LoginTextField),
                PasswordTextField.Height().EqualTo(AppDimens.DefaultTextFieldHeight));

            this.AddConstraints(
                LoginButton.AtLeftOf(this, AppDimens.Inset8X),
                LoginButton.AtRightOf(this, AppDimens.Inset8X),
                LoginButton.Below(PasswordTextField, AppDimens.Inset2X),
                LoginButton.Height().EqualTo(AppDimens.DefaultButtonHeight));
        }
    }
}