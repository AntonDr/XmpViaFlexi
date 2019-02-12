using System;
using FlexiMvvm;
using FlexiMvvm.Bindings;
using FlexiMvvm.Collections;
using FlexiMvvm.Views;
using UIKit;
using VacationsTracker.Core.Presentation.ValueConverters;
using VacationsTracker.Core.Presentation.ViewModels.Create;
using VacationsTracker.Core.Presentation.ViewModels.Details;
using VacationsTracker.Core.Resources;
using VacationsTracker.iOS.Views.Details.VacationsPager;
using VacationsTracker.iOS.Views.ValueConverters;

namespace VacationsTracker.iOS.Views.New
{
    public class NewVacationViewController : FlxBindableViewController<VacationCreateViewModel>
    {
        private UIPageViewController VacationsPageViewController { get; set; }

        private UIPageViewControllerObservableDataSource VacationsDataSource { get; set; }

        private UIBarButtonItem DoneBarButton { get; } = BarButtonFactory.GetDoneButton();

        public new NewVacationView View
        {
            get => (NewVacationView)base.View.NotNull();
            set => base.View = value;
        }

        public override void LoadView()
        {
            View = new NewVacationView();

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            NavigationItem.Title = Strings.NewVacationPage_Title;

            VacationsPageViewController = new UIPageViewController(
                UIPageViewControllerTransitionStyle.Scroll,
                UIPageViewControllerNavigationOrientation.Horizontal);

            VacationsDataSource = new UIPageViewControllerObservableDataSource(
                VacationsPageViewController,
                PagerFactory)
            {
                Items = ViewModel.VacationTypes
            };

            this.AddChildViewControllerAndView(VacationsPageViewController, View.VacationsPager);

            VacationsPageViewController.DataSource = VacationsDataSource;

            VacationsDataSource.CurrentItemIndexChanged +=
                (sender, args) => View.VacationPageControl.CurrentPage = args.Index;

            var tapGesture = new UITapGestureRecognizer(OnStartDayViewTap);
            View.VacationStartView.AddGestureRecognizer(tapGesture);

            tapGesture = new UITapGestureRecognizer(OnEndDayViewTap);
            View.VacationEndView.AddGestureRecognizer(tapGesture);

        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            NavigationItem.RightBarButtonItem = DoneBarButton;
        }

        public override void Bind(BindingSet<VacationCreateViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(VacationsDataSource)
                .For(v => v.Items)
                .To(vm => vm.VacationTypes);

            bindingSet.Bind(View.VacationStartDay)
                .For(v => v.Text)
                .To(vm => vm.StartDate)
                .WithConvertion<DateTimeToDayValueConverter>();

            bindingSet.Bind(View.VacationStartMonth)
                .For(v => v.Text)
                .To(vm => vm.StartDate)
                .WithConvertion<DateTimeToMonthValueConverter>();

            bindingSet.Bind(View.VacationStartYear)
                .For(v => v.Text)
                .To(vm => vm.StartDate)
                .WithConvertion<DateTimeToYearValueConverter>();

            bindingSet.Bind(View.VacationEndDay)
                .For(v => v.Text)
                .To(vm => vm.EndDate)
                .WithConvertion<DateTimeToDayValueConverter>();

            bindingSet.Bind(View.VacationEndMonth)
                .For(v => v.Text)
                .To(vm => vm.EndDate)
                .WithConvertion<DateTimeToMonthValueConverter>();

            bindingSet.Bind(View.VacationEndYear)
                .For(v => v.Text)
                .To(vm => vm.EndDate)
                .WithConvertion<DateTimeToYearValueConverter>();

            bindingSet.Bind(View.VacationStatusControl)
                .For(v => v.SelectedSegmentAndValueChangedBinding())
                .To(vm => vm.Status)
                .WithConvertion<StatusToSegmentValueConverter>();

            bindingSet.Bind(DoneBarButton)
                .For(v => v.NotNull().ClickedBinding())
                .To(vm => vm.CreateCommand);

            bindingSet.Bind(VacationsDataSource)
                .For(v => v.CurrentItemIndexAndCurrentItemIndexChangedBinding())
                .To(vm => vm.Type)
                .WithConvertion<VacationTypeToImageNumberValueConverter>();
        }

        private void OnStartDayViewTap()
        {
            View.VacationEndDatePicker.Hidden = true;

            View.VacationStartDatePicker.Hidden = false;
        }

        private void OnEndDayViewTap()
        {
            View.VacationStartDatePicker.Hidden = true;

            View.VacationEndDatePicker.Hidden = false;
        }

        private UIViewController PagerFactory(object parameters)
        {
            if (parameters is VacationTypePagerParameters pagerParameters)
            {
                return new VacationTypePagerViewController(pagerParameters);
            }

            throw new ArgumentException(nameof(parameters));
        }

    }
}