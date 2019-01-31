using System;
using System.Globalization;
using FlexiMvvm.ValueConverters;

namespace VacationsTracker.Core.Presentation.ValueConverters
{
    public class DateTimeToMonthValueConverter : ValueConverter<DateTime, string>
    {
        protected override ConversionResult<string> Convert(DateTime value, Type targetType, object parameter, CultureInfo culture)
        {
            var month = value.ToString("MMM", CultureInfo.CurrentCulture);
            return ConversionResult<string>.SetValue(month);
        }
    }
}