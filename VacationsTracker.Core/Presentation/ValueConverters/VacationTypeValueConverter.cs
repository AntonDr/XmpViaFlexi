using System;
using System.Globalization;
using FlexiMvvm.ValueConverters;
using VacationsTracker.Core.Domain;

namespace VacationsTracker.Core.Presentation.ValueConverters
{
    public class VacationTypeValueConverter : ValueConverter<VacationType, string>
    {
        protected override ConversionResult<string> Convert(VacationType value, Type targetType, object parameter, CultureInfo culture)
        {
            return ConversionResult<string>.SetValue(value.ToFriendlyString());
        }
    }
}
