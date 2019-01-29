using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using FlexiMvvm.ValueConverters;

namespace VacationsTracker.Core.Presentation.ValueConverters
{
    public class ShortDateTimeValueConverter : ValueConverter<ValueTuple<DateTime,DateTime>, string>
    {
        protected override ConversionResult<string> Convert(ValueTuple<DateTime,DateTime> value, Type targetType, object parameter, CultureInfo culture)
        {
            string result = string.Empty;

            result =
                $"{value.Item1.ToString("MMM dd", CultureInfo.CurrentCulture).ToUpper()} - {value.Item1.ToString("MMM dd", CultureInfo.CurrentCulture).ToUpper()}";

            return ConversionResult<string>.SetValue(result);
        }
    }
}
