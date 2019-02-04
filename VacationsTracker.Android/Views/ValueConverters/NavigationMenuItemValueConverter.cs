using System;
using System.Globalization;
using FlexiMvvm.ValueConverters;
using VacationsTracker.Core.Domain;

namespace VacationsTracker.Droid.Views.ValueConverters
{
    public class NavigationMenuItemValueConverter : ValueConverter<NavigationItems, int>
    {
        protected override ConversionResult<NavigationItems> ConvertBack(int resId, Type targetType, object parameter, CultureInfo culture)
        {
            NavigationItems item;
            switch (resId)
            {
                case Resource.Id.nav_main:
                    item = NavigationItems.All;
                    break;

                case Resource.Id.nav_open:
                    item = NavigationItems.Approved;
                    break;

                case Resource.Id.nav_close:
                    item = NavigationItems.Closed;
                    break;

                default:
                    throw new ArgumentException("Invalid resource id", nameof(resId));
            }

            return ConversionResult<NavigationItems>.SetValue(item);
        }
    }
}