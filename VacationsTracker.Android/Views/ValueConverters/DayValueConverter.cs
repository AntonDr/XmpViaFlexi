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
    public class DayValueConverter : ValueConverter<DateTime,string>
    {
        protected override ConversionResult<string> Convert(DateTime value, Type targetType, object parameter, CultureInfo culture)
        {
            return ConversionResult<string>.SetValue(value.ToString("dd").ToUpper(culture));
        }
    }
}