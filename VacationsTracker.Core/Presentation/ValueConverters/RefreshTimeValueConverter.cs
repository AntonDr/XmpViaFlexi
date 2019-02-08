using FlexiMvvm.ValueConverters;
using System;
using System.Globalization;

namespace VacationsTracker.Core.Presentation.ValueConverters
{
    public class RefreshTimeValueConverter : ValueConverter<DateTime, string>
    {
        protected override ConversionResult<string> Convert(DateTime value, Type targetType, object parameter, CultureInfo culture)
        {
            return ConversionResult<string>.SetValue($"Last updated at: {value.ToString(CultureInfo.CurrentCulture)}");
        }
    }
}