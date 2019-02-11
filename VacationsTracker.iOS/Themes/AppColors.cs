using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Foundation;
using UIKit;

namespace VacationsTracker.iOS.Themes
{
    public static class AppColors
    {
        public static UIColor LightBlueColor => GetColorFromHex(0x41C0DA);

        public static UIColor ErrorTextColor => GetColorFromHex(0x800000);

        public static UIColor White => UIColor.White;
        public static UIColor LightGreenColor => GetColorFromHex(0xA0CC4B);

        public static UIColor Gray => UIColor.Gray;

        public static UIColor TextColor => UIColor.DarkGray;

        private static UIColor GetColorFromHex(int hexValue)
        {
            return UIColor.FromRGB(
                ((hexValue & 0xFF0000) >> 16) / 255.0f,
                ((hexValue & 0xFF00) >> 8) / 255.0f,
                (hexValue & 0xFF) / 255.0f
            );
        }
    }
}