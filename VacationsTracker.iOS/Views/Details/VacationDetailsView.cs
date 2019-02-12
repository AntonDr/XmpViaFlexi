using Cirrious.FluentLayouts.Touch;
using FlexiMvvm.Views;
using System;
using UIKit;
using VacationsTracker.Core.Resources;
using VacationsTracker.iOS.Themes;

namespace VacationsTracker.iOS.Views.Details
{
    public class VacationDetailsView : LayoutView
    {
        public UIView VacationsPager { get; private set; }
        public UIPageControl VacationPageControl { get; set; }
        public UITextView StartTextView { get; private set; }
        public UIView UpSeparatorView { get; private set; }
        public UIView VacationStartView { get; private set; }
        public UIView VacationEndView { get; private set; }
        public UILabel VacationStartDay { get; private set; }
        public UILabel VacationStartMonth { get; private set; }
        public UILabel VacationStartYear { get; private set; }
        public UILabel VacationEndDay { get; private set; }
        public UILabel VacationEndMonth { get; private set; }
        public UILabel VacationEndYear { get; private set; }
        public UIView DownSeparatorView { get; private set; }
        public UISegmentedControl VacationStatusControl { get; private set; }
        public UIDatePicker VacationStartDatePicker { get; private set; }
        public UIDatePicker VacationEndDatePicker { get; private set; }


        protected override void SetupSubviews()
        {
            base.SetupSubviews();

            BackgroundColor = AppColors.White;

            VacationsPager = new UIView();

            StartTextView = new UITextView();

            VacationPageControl = new UIPageControl { Pages = 5, PageIndicatorTintColor = AppColors.Gray, CurrentPageIndicatorTintColor = AppColors.LightBlueColor };

            UpSeparatorView = new UIView { BackgroundColor = AppColors.LightBlueColor };


            VacationStartView = new UIView();
            VacationStartDay = new UILabel().SetDateStyle(AppColors.LightBlueColor, UIFont.SystemFontOfSize(60));
            VacationStartMonth = new UILabel().SetDateStyle(AppColors.LightBlueColor, UIFont.SystemFontOfSize(30));
            VacationStartYear = new UILabel().SetDateStyle(AppColors.LightBlueColor, UIFont.SystemFontOfSize(25));

            VacationEndView = new UIView();
            VacationEndDay = new UILabel().SetDateStyle(AppColors.LightGreenColor, UIFont.SystemFontOfSize(60));
            VacationEndMonth = new UILabel().SetDateStyle(AppColors.LightGreenColor, UIFont.SystemFontOfSize(30));
            VacationEndYear = new UILabel().SetDateStyle(AppColors.LightGreenColor, UIFont.SystemFontOfSize(25));


            DownSeparatorView = new UIView { BackgroundColor = AppColors.LightBlueColor };


            VacationStatusControl = new UISegmentedControl(Strings.VacationStatus_Approved, Strings.VacationStatus_Closed)
            {
                TintColor = AppColors.LightGreenColor
            };


            VacationStartDatePicker = new UIDatePicker
            {
                Mode = UIDatePickerMode.Date,
                Hidden = true

            }.SetTextColor(AppColors.LightBlueColor);

            VacationEndDatePicker = new UIDatePicker
            {
                Mode = UIDatePickerMode.Date,
                Hidden = true

            }.SetTextColor(AppColors.LightGreenColor);
        }

        protected override void SetupLayout()
        {
            base.SetupLayout();

            this.AddLayoutSubview(VacationsPager)
                .AddLayoutSubview(VacationPageControl)
                .AddLayoutSubview(UpSeparatorView)
                .AddLayoutSubview(VacationStartView)
                .AddLayoutSubview(VacationStartDay)
                .AddLayoutSubview(VacationStartMonth)
                .AddLayoutSubview(VacationStartYear)
                .AddLayoutSubview(VacationEndView)
                .AddLayoutSubview(VacationEndDay)
                .AddLayoutSubview(VacationEndMonth)
                .AddLayoutSubview(VacationEndYear)
                .AddLayoutSubview(DownSeparatorView)
                .AddLayoutSubview(VacationStatusControl)
                .AddLayoutSubview(VacationStartDatePicker)
                .AddLayoutSubview(VacationEndDatePicker);

        }

        protected override void SetupLayoutConstraints()
        {
            base.SetupLayoutConstraints();

            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            this.AddConstraints(
                VacationsPager.AtLeftOf(this),
                VacationsPager.AtTopOf(this, AppDimens.Inset4X),
                VacationsPager.AtRightOf(this),
                VacationsPager.WithRelativeHeight(this, (nfloat?)0.35)
                );

            this.AddConstraints(
                VacationPageControl.AtBottomOf(VacationsPager, AppDimens.Inset1X),
                VacationPageControl.WithSameCenterX(this)
                );

            this.AddConstraints(
                UpSeparatorView.AtLeftOf(this),
                UpSeparatorView.AtRightOf(this),
                UpSeparatorView.Below(VacationsPager, AppDimens.Inset1X),
                UpSeparatorView.Height().EqualTo(AppDimens.DefaultSeparatorHeight));


            this.AddConstraints(
                VacationStartView.Below(UpSeparatorView, AppDimens.Inset1X),
                VacationStartView.AtLeftOf(this),
                VacationStartView.WithRelativeWidth(this, (nfloat?)0.5));

            this.AddConstraints(
                VacationStartDay.AtLeftOf(VacationStartView, AppDimens.Inset2X),
                VacationStartDay.AtTopOf(VacationStartView),
                VacationStartDay.AtBottomOf(VacationStartView));

            this.AddConstraints(
                VacationStartMonth.ToRightOf(VacationStartDay, AppDimens.Inset1X),
                VacationStartMonth.AtTopOf(VacationStartDay, AppDimens.Inset1X));

            this.AddConstraints(
                VacationStartYear.WithSameLeft(VacationStartMonth),
                VacationStartYear.AtBottomOf(VacationStartDay, AppDimens.Inset1X));

            this.AddConstraints(
                VacationEndView.Below(UpSeparatorView, AppDimens.Inset1X),
                VacationEndView.AtRightOf(this),
                VacationEndView.WithSameWidth(VacationStartView));

            this.AddConstraints(
                VacationEndDay.AtLeftOf(VacationEndView, AppDimens.Inset2X),
                VacationEndDay.AtTopOf(VacationEndView),
                VacationEndDay.AtBottomOf(VacationEndView));

            this.AddConstraints(
                VacationEndMonth.ToRightOf(VacationEndDay, AppDimens.Inset1X),
                VacationEndMonth.AtTopOf(VacationEndDay, AppDimens.Inset1X));

            this.AddConstraints(
                VacationEndYear.WithSameLeft(VacationEndMonth),
                VacationEndYear.AtBottomOf(VacationEndDay, AppDimens.Inset1X));

            this.AddConstraints(
                DownSeparatorView.AtLeftOf(this),
                DownSeparatorView.Below(VacationEndView, AppDimens.Inset1X),
                DownSeparatorView.AtRightOf(this),
                DownSeparatorView.Height().EqualTo(AppDimens.DefaultSeparatorHeight));


            this.AddConstraints(
                VacationStatusControl.Below(DownSeparatorView, AppDimens.Inset2X),
                VacationStatusControl.WithSameCenterX(this),
                VacationStatusControl.AtLeftOf(this, AppDimens.Inset8X),
                VacationStatusControl.AtRightOf(this, AppDimens.Inset8X));

            this.AddConstraints(
                VacationStartDatePicker.WithRelativeHeight(this, (nfloat)0.30),
                VacationStartDatePicker.WithSameCenterX(this),
                VacationStartDatePicker.AtBottomOf(this));

            this.AddConstraints(
                VacationEndDatePicker.WithRelativeHeight(this, (nfloat)0.30),
                VacationEndDatePicker.WithSameCenterX(this),
                VacationEndDatePicker.AtBottomOf(this));

        }
    }
}