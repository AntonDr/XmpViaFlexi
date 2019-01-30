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
using VacationsTracker.Core.Domain;

namespace VacationsTracker.Droid.Views.ValueConverters
{
    public class ApprovedRadioValueConverter: ValueConverter<VacationStatus,bool>
    {
        protected override ConversionResult<bool> Convert(VacationStatus value, Type targetType, object parameter, CultureInfo culture)
        {
            return ConversionResult<bool>.SetValue(value == VacationStatus.Approved);
        }
    }
}