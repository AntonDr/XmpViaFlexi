using System;
using System.Globalization;
using FlexiMvvm.ValueConverters;

namespace VacationsTracker.Core.Presentation.ValueConverters
{
    public class DurationValueConverter : ValueConverter<(DateTime, DateTime), string>
    {
        protected override ConversionResult<string> Convert((DateTime, DateTime) value, Type targetType, object parameter, CultureInfo culture)
        {
            const string DurationFormat = "{0} - {1}";

            var start = value.Item1.ToString("dd MMM").ToUpper(CultureInfo.CurrentCulture);
            var end = value.Item2.ToString("dd MMM").ToUpper(CultureInfo.CurrentCulture);

            var result = string.Format(DurationFormat, start, end);

            return ConversionResult<string>.SetValue(result);
        }
    }
}