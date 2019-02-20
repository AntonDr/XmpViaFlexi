using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace VacationsTracker.Droid.Views.Details
{
    public class DatePickerFragment : DialogFragment, DatePickerDialog.IOnDateSetListener
    {
        private Action<DateTime> _dateSelectedHandler;

        private DateTime _initialDate;

        private Predicate<DateTime> _validator;

        private Action<DateTime> _onErrorHandler;

        public static DatePickerFragment NewInstance(
            DateTime initialDate,
            Action<DateTime> onDateSelected,
            Predicate<DateTime> validator,
            Action<DateTime> onErrorHandler)
        {
            var fragment = new DatePickerFragment
            {
                _dateSelectedHandler = onDateSelected,
                _initialDate = initialDate,
                _validator = validator,
                _onErrorHandler = onErrorHandler
            };

            return fragment;
        }

        public override Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            var dialog = new DatePickerDialog(
                Activity,
                this,
                _initialDate.Year,
                _initialDate.Month - 1,
                _initialDate.Day);

            return dialog;
        }

        public void OnDateSet(DatePicker view, int year, int monthOfYear, int dayOfMonth)
        {
            var selectedDate = new DateTime(year, monthOfYear + 1, dayOfMonth);
            if (_validator == null || _validator(selectedDate))
            {
                _dateSelectedHandler?.Invoke(selectedDate);
                return;
            }

            _onErrorHandler?.Invoke(selectedDate);
        }
    }
}
