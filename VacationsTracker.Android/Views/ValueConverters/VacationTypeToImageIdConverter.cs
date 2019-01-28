using System;
using System.Globalization;
using Android.Widget;
using FlexiMvvm.ValueConverters;
using VacationsTracker.Core.Domain;

namespace VacationsTracker.Droid.Views.ValueConverters
{
    public class VacationTypeToImageIdConverter:ValueConverter<VacationType,int>
    {
        protected override ConversionResult<int> Convert(VacationType value, Type targetType, object parameter, CultureInfo culture)
        {
            int result = 0;

            switch (value)
            {
                case VacationType.Regular:
                    result = Resource.Drawable.Icon_Request_Green;
                    break;
                case VacationType.SickDays:
                    result = Resource.Drawable.Icon_Request_Plum;
                    break;
                case VacationType.ExceptionalLeave:
                    result = Resource.Drawable.Icon_Request_Gray;
                    break;
                case VacationType.Overtime:
                    result = Resource.Drawable.Icon_Request_Blue;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, null);

            }

            return ConversionResult<int>.SetValue(result);
        }
    }
}