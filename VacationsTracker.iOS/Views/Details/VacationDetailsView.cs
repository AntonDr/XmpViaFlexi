using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cirrious.FluentLayouts.Touch;
using FlexiMvvm.Views;
using Foundation;
using UIKit;
using VacationsTracker.iOS.Themes;

namespace VacationsTracker.iOS.Views.Details
{
    public class VacationDetailsView : LayoutView
    {
        public UIView Pager { get; private set; }
        public UIView UpSeparatorView { get; private set; }
        public UIView VacationStartView { get; private set; }
        public UIView VacationEndView { get; private set; }
        public UILabel VacationStartDay { get; private set; }
        public UILabel VacationStartMonth { get; private set; }
        public UILabel VacationStartYear { get; private set; }
        public UILabel VacationEndDay { get; private set; }
        public UILabel VacationEndMonth { get; private set; }
        public UILabel VacationEndYear { get; private set; }
        //public UISwitch VacationStatusSwitch { get; private set; }
        public UIView DownSeparatorView { get; private set; }
        public UISegmentedControl VacationStatusControl { get; private set; }




        protected override void SetupSubviews()
        {
            base.SetupSubviews();

            BackgroundColor = AppColors.White;

            Pager = new UIView();


            UpSeparatorView = new UIView();
            UpSeparatorView.BackgroundColor = AppColors.LightBlueColor;
            

            VacationStartView = new UIView();
            VacationStartDay = new UILabel().SetDateStyle(AppColors.LightBlueColor,UIFont.SystemFontOfSize(60));
            VacationStartMonth = new UILabel().SetDateStyle(AppColors.LightBlueColor, UIFont.SystemFontOfSize(30));
            VacationStartYear = new UILabel().SetDateStyle(AppColors.LightBlueColor, UIFont.SystemFontOfSize(25));

            VacationEndView = new UIView();
            VacationEndDay = new UILabel().SetDateStyle(AppColors.LightGreenColor, UIFont.SystemFontOfSize(60));
            VacationEndMonth = new UILabel().SetDateStyle(AppColors.LightGreenColor, UIFont.SystemFontOfSize(30));
            VacationEndYear = new UILabel().SetDateStyle(AppColors.LightGreenColor, UIFont.SystemFontOfSize(25));

           
            DownSeparatorView = new UIView();
            DownSeparatorView.BackgroundColor = AppColors.LightBlueColor;


            VacationStatusControl = new UISegmentedControl(new NSString("Approved"), new NSString("Closed"));

            VacationStatusControl.TintColor = AppColors.LightGreenColor;
        }

        protected override void SetupLayout()
        {
            base.SetupLayout();

            this.AddLayoutSubview(Pager)
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
                .AddLayoutSubview(VacationStatusControl);

        }

        protected override void SetupLayoutConstraints()
        {
            base.SetupLayoutConstraints();

            var halfWidth = UIScreen.MainScreen.Bounds.Width / 2;

            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            this.AddConstraints(
                Pager.AtLeftOf(this),
                Pager.AtTopOf(this),
                Pager.AtRightOf(this),
                Pager.Height().EqualTo(250)
                );

            this.AddConstraints(
                UpSeparatorView.Below(Pager, AppDimens.Inset1X),
                UpSeparatorView.Height().EqualTo(AppDimens.DefaultSeparatorHeight));


            this.AddConstraints(
                VacationStartView.Below(UpSeparatorView,AppDimens.Inset2X),
                VacationStartView.AtLeftOf(this),
                VacationStartView.Width().EqualTo(halfWidth)                );

            this.AddConstraints(
                VacationStartDay.AtLeftOf(VacationStartView,AppDimens.Inset2X),
                VacationStartDay.AtTopOf(VacationStartView),
                VacationStartDay.AtBottomOf(VacationStartView));

            this.AddConstraints(
                VacationStartMonth.ToRightOf(VacationStartDay, AppDimens.Inset1X),
                VacationStartMonth.AtTopOf(VacationStartDay, AppDimens.Inset1X));

            this.AddConstraints(
                VacationStartYear.WithSameLeft(VacationStartMonth),
                VacationStartYear.AtBottomOf(VacationStartDay, AppDimens.Inset1X));

            this.AddConstraints(
                VacationEndView.Below(UpSeparatorView,AppDimens.Inset2X),
                VacationEndView.AtRightOf(this),
                VacationEndView.WithSameWidth(VacationStartView));

            this.AddConstraints(
                VacationEndDay.AtLeftOf(VacationEndView,AppDimens.Inset2X),
                VacationEndDay.AtTopOf(VacationEndView),
                VacationEndDay.AtBottomOf(VacationEndView));

            this.AddConstraints(
                VacationEndMonth.ToRightOf(VacationEndDay, AppDimens.Inset1X),
                VacationEndMonth.AtTopOf(VacationEndDay, AppDimens.Inset1X));

            this.AddConstraints(
                VacationEndYear.WithSameLeft(VacationEndMonth),
                VacationEndYear.AtBottomOf(VacationEndDay, AppDimens.Inset1X));

            //this.AddConstraints(
            //     VacationStatusSwitch.Below(VacationStartView),
            //                      VacationStatusSwitch.WithSameCenterX(this)
            //        );

            this.AddConstraints(
                DownSeparatorView.AtLeftOf(this),
                DownSeparatorView.Below(VacationEndView,AppDimens.Inset1X),
                DownSeparatorView.AtRightOf(this),
                DownSeparatorView.Height().EqualTo(AppDimens.DefaultSeparatorHeight));


            this.AddConstraints(
                VacationStatusControl.Below(DownSeparatorView,AppDimens.Inset2X),
                VacationStatusControl.WithSameCenterX(this),
                VacationStatusControl.AtLeftOf(this,AppDimens.Inset8X),
                VacationStatusControl.AtRightOf(this,AppDimens.Inset8X));

            //this.AddConstraints(VacationsTableView.TableFooterView.Below(VacationsTableView),
            //    VacationsTableView.TableFooterView.Height().EqualTo(2));

        }
    }
}