using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FlexiMvvm.ValueConverters;

namespace VacationsTracker.Droid.Views.ValueConverters
{
    class VisibilityValueConverter : ValueConverter<bool, ViewStates>
    {
        protected override ConversionResult<ViewStates> Convert(bool isVisible, Type targetType, object parameter, CultureInfo culture)
        {
            var visibility = isVisible ? ViewStates.Visible : ViewStates.Invisible;

            return ConversionResult<ViewStates>.SetValue(visibility);
        }
    }
}