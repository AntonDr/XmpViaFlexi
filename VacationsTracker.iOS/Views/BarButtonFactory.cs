using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using VacationsTracker.Core.Resources;
using VacationsTracker.iOS.Themes;

namespace VacationsTracker.iOS.Views
{
    public static class BarButtonFactory
    {
        public static UIBarButtonItem GetDoneButton()
        {
            return new UIBarButtonItem(Strings.SaveNavigationButton_Text, UIBarButtonItemStyle.Plain, null);
        }

        public static UIBarButtonItem GetCreateButton()
        {
            return new UIBarButtonItem(Strings.CreateNewVacationButton_Text,UIBarButtonItemStyle.Plain,null);
        }
    }
}