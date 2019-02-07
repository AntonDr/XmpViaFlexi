using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using FlexiMvvm.ValueConverters;
using Foundation;
using UIKit;
using VacationsTracker.Core.Domain;

namespace VacationsTracker.iOS.Views.ValueConverters
{
    internal class SwitchButtonValueConverter : ValueConverter<VacationStatus,bool>
    {
        protected override ConversionResult<bool> Convert(VacationStatus value, Type targetType, object parameter, CultureInfo culture)
        {
            bool result = false;

            switch (value)
            {
                case VacationStatus.Approved:
                    result = false;
                    break;
                case VacationStatus.Closed:
                    result = true;
                    break;
            }

            return ConversionResult<bool>.SetValue(result);
        }
    }
}