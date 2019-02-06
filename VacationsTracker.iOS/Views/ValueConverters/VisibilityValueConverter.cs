using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using FlexiMvvm.ValueConverters;
using Foundation;
using UIKit;

namespace VacationsTracker.iOS.Views.ValueConverters
{
    public class VisibilityValueConverter : ValueConverter<bool, bool>
    {
        protected override ConversionResult<bool> Convert(bool value, Type targetType, object parameter, CultureInfo culture)
        {
            return ConversionResult<bool>.SetValue(!value);
        }
    }
}