using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlexiMvvm;
using FlexiMvvm.Bindings;
using FlexiMvvm.Collections;
using FlexiMvvm.Views;
using Foundation;
using UIKit;
using VacationsTracker.Core.Presentation.ValueConverters;
using VacationsTracker.Core.Presentation.ViewModels.Details;
using VacationsTracker.Core.Presentation.ViewModels.Home;
using VacationsTracker.iOS.Views.Home;
using VacationsTracker.iOS.Views.Home.VacationsTable;
using VacationsTracker.iOS.Views.ValueConverters;

namespace VacationsTracker.iOS.Views.Details
{
    public class VacationDetailsViewController : FlxBindableViewController<VacationDetailsViewModel, VacationDetailsParameters>
    {
        public VacationDetailsViewController(VacationDetailsParameters parameters) : base(parameters)
        {
        }

        //private VacationDetailsView VacationsDetailsView { get; set; }

        public new VacationDetailsView View
        {
            get => (VacationDetailsView)base.View.NotNull();
            set => base.View = value;
        }

        public override void LoadView()
        {
            View = new VacationDetailsView();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

                
        }

        public override void Bind(BindingSet<VacationDetailsViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(View.VacationStartDay)
                .For(v => v.Text)
                .To(vm => vm.Vacation.Start)
                .WithConvertion<DateTimeToDayValueConverter>();

            bindingSet.Bind(View.VacationStartMonth)
                .For(v => v.Text)
                .To(vm => vm.Vacation.Start)
                .WithConvertion<DateTimeToMonthValueConverter>();

            bindingSet.Bind(View.VacationStartYear)
                .For(v => v.Text)
                .To(vm => vm.Vacation.Start)
                .WithConvertion<DateTimeToYearValueConverter>();

            bindingSet.Bind(View.VacationEndDay)
                .For(v => v.Text)
                .To(vm => vm.Vacation.End)
                .WithConvertion<DateTimeToDayValueConverter>();

            bindingSet.Bind(View.VacationEndMonth)
                .For(v => v.Text)
                .To(vm => vm.Vacation.End)
                .WithConvertion<DateTimeToMonthValueConverter>();

            bindingSet.Bind(View.VacationEndYear)
                .For(v => v.Text)
                .To(vm => vm.Vacation.End)
                .WithConvertion<DateTimeToYearValueConverter>();

            //bindingSet.Bind(View.VacationStatusSwitch)
            //    .For(v => v.On)
            //    .To(vm => vm.Vacation.Status)
            //    .WithConvertion<SwitchButtonValueConverter>();

            bindingSet.Bind(View.VacationStatusControl)
                .For(v => v.SelectedSegment)
                .To(vm => vm.Vacation.Status)
                .WithConvertion<StatusToSegmentValueConverter>();

        }
    }
}