using System;
using System.Globalization;
using FlexiMvvm.ValueConverters;
using VacationsTracker.Core.Domain;

namespace VacationsTracker.Droid.Views.ValueConverters
{
    public class VacationStatusToApprovedRadioValueConverter : ValueConverter<VacationStatus, bool>
    {
        protected override ConversionResult<bool> Convert(VacationStatus value, Type targetType, object parameter, CultureInfo culture)
        {
            var isChecked = value == VacationStatus.Approved;
            return ConversionResult<bool>.SetValue(isChecked);
        }
    }
}