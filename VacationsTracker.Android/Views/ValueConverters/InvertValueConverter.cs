using System;
using System.Globalization;
using FlexiMvvm.ValueConverters;

namespace VacationsTracker.Droid.Views.Login
{
    internal class InvertValueConverter : ValueConverter<bool,bool>
    {
        protected override ConversionResult<bool> Convert(bool value, Type targetType, object parameter, CultureInfo culture)
        {
            return ConversionResult<bool>.SetValue(!value);
        }

        protected override ConversionResult<bool> ConvertBack(bool value, Type targetType, object parameter, CultureInfo culture)
        {
            return ConversionResult<bool>.SetValue(!value);
        }
    }
    
}