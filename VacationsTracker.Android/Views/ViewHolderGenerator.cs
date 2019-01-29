﻿// <auto-generated />
// ReSharper disable All
using System;
using Android.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace VacationsTracker.Droid.Views
{
    public partial class HomeActivityViewHolder
    {
         private readonly Activity activity;

         private Android.Support.V7.Widget.Toolbar homeToolbar;
         private Android.Support.V7.Widget.RecyclerView recyclerView;

        public HomeActivityViewHolder( Activity activity)
        {
            if (activity == null) throw new ArgumentNullException(nameof(activity));

            this.activity = activity;
        }

        
        public Android.Support.V7.Widget.Toolbar HomeToolbar =>
            homeToolbar ?? (homeToolbar = activity.FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.home_toolbar));

        
        public Android.Support.V7.Widget.RecyclerView RecyclerView =>
            recyclerView ?? (recyclerView = activity.FindViewById<Android.Support.V7.Widget.RecyclerView>(Resource.Id.recyclerView));
    }

    public partial class LoginActivityViewHolder
    {
         private readonly Activity activity;

         private TextView invalidCredentialsText;
         private EditText loginEntry;
         private EditText passwordEntry;
         private Button loginButton;

        public LoginActivityViewHolder( Activity activity)
        {
            if (activity == null) throw new ArgumentNullException(nameof(activity));

            this.activity = activity;
        }

        
        public TextView InvalidCredentialsText =>
            invalidCredentialsText ?? (invalidCredentialsText = activity.FindViewById<TextView>(Resource.Id.invalidCredentialsText));

        
        public EditText LoginEntry =>
            loginEntry ?? (loginEntry = activity.FindViewById<EditText>(Resource.Id.loginEntry));

        
        public EditText PasswordEntry =>
            passwordEntry ?? (passwordEntry = activity.FindViewById<EditText>(Resource.Id.passwordEntry));

        
        public Button LoginButton =>
            loginButton ?? (loginButton = activity.FindViewById<Button>(Resource.Id.loginButton));
    }

    public partial class LoginRelativeActivityViewHolder
    {
         private readonly Activity activity;

         private TextView invalidCredentialsText;
         private EditText loginEntry;
         private EditText passwordEntry;
         private Button loginButton;

        public LoginRelativeActivityViewHolder( Activity activity)
        {
            if (activity == null) throw new ArgumentNullException(nameof(activity));

            this.activity = activity;
        }

        
        public TextView InvalidCredentialsText =>
            invalidCredentialsText ?? (invalidCredentialsText = activity.FindViewById<TextView>(Resource.Id.invalidCredentialsText));

        
        public EditText LoginEntry =>
            loginEntry ?? (loginEntry = activity.FindViewById<EditText>(Resource.Id.loginEntry));

        
        public EditText PasswordEntry =>
            passwordEntry ?? (passwordEntry = activity.FindViewById<EditText>(Resource.Id.passwordEntry));

        
        public Button LoginButton =>
            loginButton ?? (loginButton = activity.FindViewById<Button>(Resource.Id.loginButton));
    }

    public partial class VacationDetailsActivityViewHolder
    {
         private readonly Activity activity;

         private Android.Support.V7.Widget.Toolbar detailsToolbar;
         private Button saveRequestButton;
         private Android.Support.V4.View.ViewPager vacationTypePager;
         private TextView vacationStartDay;
         private TextView vacationStartMonth;
         private TextView vacationStartYear;
         private TextView vacationEndDay;
         private TextView vacationEndMonth;
         private TextView vacationEndYear;
         private RadioButton approvedRadio;
         private RadioButton closedRadio;

        public VacationDetailsActivityViewHolder( Activity activity)
        {
            if (activity == null) throw new ArgumentNullException(nameof(activity));

            this.activity = activity;
        }

        
        public Android.Support.V7.Widget.Toolbar DetailsToolbar =>
            detailsToolbar ?? (detailsToolbar = activity.FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.details_toolbar));

        
        public Button SaveRequestButton =>
            saveRequestButton ?? (saveRequestButton = activity.FindViewById<Button>(Resource.Id.save_request_button));

        
        public Android.Support.V4.View.ViewPager VacationTypePager =>
            vacationTypePager ?? null;

        
        public TextView VacationStartDay =>
            vacationStartDay ?? (vacationStartDay = activity.FindViewById<TextView>(Resource.Id.vacation_start_day));

        
        public TextView VacationStartMonth =>
            vacationStartMonth ?? (vacationStartMonth = activity.FindViewById<TextView>(Resource.Id.vacation_start_month));

        
        public TextView VacationStartYear =>
            vacationStartYear ?? (vacationStartYear = activity.FindViewById<TextView>(Resource.Id.vacation_start_year));

        
        public TextView VacationEndDay =>
            vacationEndDay ?? (vacationEndDay = activity.FindViewById<TextView>(Resource.Id.vacation_end_day));

        
        public TextView VacationEndMonth =>
            vacationEndMonth ?? (vacationEndMonth = activity.FindViewById<TextView>(Resource.Id.vacation_end_month));

        
        public TextView VacationEndYear =>
            vacationEndYear ?? (vacationEndYear = activity.FindViewById<TextView>(Resource.Id.vacation_end_year));

        
        public RadioButton ApprovedRadio =>
            approvedRadio ?? (approvedRadio = activity.FindViewById<RadioButton>(Resource.Id.approved_radio));

        
        public RadioButton ClosedRadio =>
            closedRadio ?? (closedRadio = activity.FindViewById<RadioButton>(Resource.Id.closed_radio));
    }

    public partial class VacationCellViewHolder
    {
         private ImageView vacationImage;
         private TextView vacationDuration;
         private TextView vacationType;
         private TextView vacationStatus;
         private View separatorView;



        
        public ImageView VacationImage =>
            vacationImage ?? (vacationImage = ItemView.FindViewById<ImageView>(Resource.Id.vacationImage));

        
        public TextView VacationDuration =>
            vacationDuration ?? (vacationDuration = ItemView.FindViewById<TextView>(Resource.Id.vacationDuration));

        
        public TextView VacationType =>
            vacationType ?? (vacationType = ItemView.FindViewById<TextView>(Resource.Id.vacationType));

        
        public TextView VacationStatus =>
            vacationStatus ?? (vacationStatus = ItemView.FindViewById<TextView>(Resource.Id.vacationStatus));

        
        public View SeparatorView =>
            separatorView ?? (separatorView = ItemView.FindViewById<View>(Resource.Id.separator_view));
    }

    /*
    "cell_vacation_footer" layout file doesn't contain any view with "android:id" attribute specified. There is no sense in view holder generation.
    public partial class VacationFooterCellViewHolder
    {
    }
    */

    public partial class VacationHeaderCellViewHolder
    {
         private TextView lastUpdatedTime;



        
        public TextView LastUpdatedTime =>
            lastUpdatedTime ?? (lastUpdatedTime = ItemView.FindViewById<TextView>(Resource.Id.lastUpdatedTime));
    }

}
// ReSharper restore All
