﻿using System;
using Cirrious.FluentLayouts.Touch;
using CoreGraphics;
using Foundation;
using UIKit;

namespace VacationsTracker.iOS.Themes
{
    public static class AppStyles
    {
        public static UIButton SetPrimaryButtonStyle(this UIButton button, string text = null)
        {
            if (text != null)
            {
                button.SetTitle(text, UIControlState.Normal);
            }

            button.BackgroundColor = AppColors.LightBlueColor;

            return button;
        }

        public static UILabel SetErrorLabelStyle(this UILabel label, string text)
        {
            label.BackgroundColor = AppColors.White;
            label.Text = text;
            label.TextColor = AppColors.ErrorTextColor;
            label.TextAlignment = UITextAlignment.Center;

            label.WrapText();

            label.SetCornerRadiusTo(5);

            return label;
        }

        public static UIDatePicker SetTextColor(this UIDatePicker picker, UIColor textColor)
        {
            picker.SetValueForKey(textColor, new NSString("textColor"));

            return picker;
        }

        public static UILabel SetLabelStyle(this UILabel label)
        {
            label.TextColor = AppColors.TextColor;

            return label;
        }

        public static UITextField SetDefaultTextFieldStyle(this UITextField textField, string placeholder = null)
        {
            if (placeholder != null)
            {
                textField.Placeholder = placeholder;
            }

            textField.BackgroundColor = UIColor.White;
            SetLeftPadding(textField, 5);

            return textField;
        }

        public static UIView SetSeparatorStyle(this UIView separator)
        {
            separator.BackgroundColor = UIColor.LightGray;

            return separator;
        }

        public static UIImageView SetDefaultBackgroundImage(this UIImageView imageView)
        {
            imageView.Image = UIImage.FromBundle("LoginBackground");

            return imageView;
        }

        public static UILabel SetDateStyle(this UILabel label,UIColor color = null,UIFont font = null)
        {
            if (color == null)
            {
                color = AppColors.LightBlueColor;
            }

            if (font == null)
            {
                font = UIFont.PreferredTitle1;
            }

            label.TextColor =color;
            label.Font = font;

            return label;
        }




        private static void SetLeftPadding(UITextField textField, int paddingWidth)
        {
            var paddingView = new UIView(new CGRect(0, 0, paddingWidth, AppDimens.DefaultTextFieldHeight));
            textField.LeftView = paddingView;
            textField.LeftViewMode = UITextFieldViewMode.Always;
        }

        private static void WrapText(this UILabel label)
        {
            label.Lines = 0;
        }

        private static void SetCornerRadiusTo(this UIView label, int cornerRadius)
        {
            label.Layer.MasksToBounds = true;
            label.Layer.CornerRadius = cornerRadius;
        }

        
    }
}