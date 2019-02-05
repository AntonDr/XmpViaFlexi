using UIKit;

namespace VacationsTracker.iOS.Themes
{
    public static class AppStyles
    {
        public static UITextField SetDefaultTextFieldStyle(this UITextField textField,string placeholderText = null)
        {
            if (placeholderText != null)
            {
                textField.Placeholder = placeholderText;
            }

            textField.BackgroundColor = UIColor.White;

            return textField;
        }

        public static UIButton SetPrimaryButtonStyle(this UIButton button, string text = null)
        {

            if (text != null)
            {
                button.SetTitle(text, UIControlState.Normal);
            }

            button.BackgroundColor = UIColor.Clear.FromHex(0xA0CC4B);

            return button;
        }

        public static UIImageView SetDefaultBackgroundImage(this UIImageView imageView)
        {
            imageView.Image = UIImage.FromBundle("BgImage");

            return imageView;
        }
    }
}