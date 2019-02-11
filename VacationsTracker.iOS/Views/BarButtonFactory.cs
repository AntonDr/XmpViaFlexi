using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using VacationsTracker.iOS.Themes;

namespace VacationsTracker.iOS.Views
{
    public static class BarButtonFactory
    {
        public static UIBarButtonItem GetSelectButton()
        {
            return new UIBarButtonItem(AppStrings.Select, UIBarButtonItemStyle.Plain, null);
        }

        public static UIBarButtonItem GetCancelButton()
        {
            return new UIBarButtonItem(AppStrings.Cancel, UIBarButtonItemStyle.Plain, null);
        }

        public static UIBarButtonItem GetDoneButton()
        {
            return new UIBarButtonItem(AppStrings.Apply, UIBarButtonItemStyle.Plain, null);
        }

        public static UIBarButtonItem GetCreateButton()
        {
            return new UIBarButtonItem(AppStrings.Create,UIBarButtonItemStyle.Plain,null);
        }
    }
}