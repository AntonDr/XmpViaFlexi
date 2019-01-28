using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using FlexiMvvm.ValueConverters;

namespace VacationsTracker.Core.Presentation.ValueConverters
{
    public class ShortDateTimeValueConverter : ValueConverter<object, string>
    {
        protected override ConversionResult<string> Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime dateTime)
            {
                return ConversionResult<string>.SetValue(dateTime.ToString("MMM dd", CultureInfo.CurrentCulture).ToUpper());
            }

            return ConversionResult<string>.UnsetValue();
        }
    }
}
