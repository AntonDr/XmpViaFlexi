using FlexiMvvm.ValueConverters;
using System;
using System.Globalization;
using VacationsTracker.Core.Domain;

namespace VacationsTracker.Core.Presentation.ValueConverters
{
    public class VacationTypeValueConverter : ValueConverter<object, string>
    {
        protected override ConversionResult<string> Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is VacationType vacationType)
            {
                return ConversionResult<string>.SetValue(vacationType.ToFriendlyString());
            }

            return ConversionResult<string>.UnsetValue();
        }
    }
}
