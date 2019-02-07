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
    public class StatusToSegmentValueConverter : ValueConverter<VacationStatus,nint>
    {
        protected override ConversionResult<nint> Convert(VacationStatus value, Type targetType, object parameter, CultureInfo culture)
        {
            nint result = 0;

            switch (value)
            {
                case VacationStatus.Approved:
                    result = 0;
                    break;
                case VacationStatus.Closed:
                    result = 1;
                    break;
            }

            return ConversionResult<nint>.SetValue(result);
        }
    }
}