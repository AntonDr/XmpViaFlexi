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
    internal class ImageValueConverter : ValueConverter<VacationType,UIImage>
    {
        protected override ConversionResult<UIImage> Convert(VacationType value, Type targetType, object parameter, CultureInfo culture)
        {
            UIImage image = null;

            switch (value)
            {
                case VacationType.Regular:
                    image = UIImage.FromBundle("RegularImage");
                    break;
                case VacationType.SickDays:
                    image = UIImage.FromBundle("SickDaysImage");
                    break;
                case VacationType.Overtime:
                    image = UIImage.FromBundle("OvertimeImage");
                    break;
                case VacationType.LeaveWithoutPay:
                    image = UIImage.FromBundle("LeaveWithoutPayImage");
                    break;
                case VacationType.ExceptionalLeave:
                    image = UIImage.FromBundle("ExcepionalImage");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, null);
            }

            return ConversionResult<UIImage>.SetValue(image);
        }
    }
}