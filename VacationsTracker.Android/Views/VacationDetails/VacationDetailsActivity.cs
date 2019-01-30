using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FlexiMvvm.Bindings;
using FlexiMvvm.Views.V7;
using VacationsTracker.Core.Presentation.ViewModels.VacationDetails;
using VacationsTracker.Droid.Views.ValueConverters;

namespace VacationsTracker.Droid.Views.VacationDetails
{
    [Activity]
    public class VacationDetailsActivity
        : FlxBindableAppCompatActivity<VacationDetailsViewModel, VacationDetailsParameters>
    {
        private VacationDetailsActivityViewHolder ViewHolder { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_vacation_details);

            ViewHolder = new VacationDetailsActivityViewHolder(this);
        }

        public override void Bind(BindingSet<VacationDetailsViewModel> bindingSet)
        {
            bindingSet.Bind(ViewHolder.VacationStartDay)
                .For(v => v.Text)
                .To(vm => vm.StartTime)
                .WithConvertion<DayValueConverter>();

            bindingSet.Bind(ViewHolder.VacationEndDay)
                .For(v => v.Text)
                .To(vm => vm.EndTime)
                .WithConvertion<DayValueConverter>();

            bindingSet.Bind(ViewHolder.VacationStartMonth)
                .For(v => v.Text)
                .To(vm => vm.StartTime)
                .WithConvertion<MonthValueConverter>();

            bindingSet.Bind(ViewHolder.VacationEndMonth)
                .For(v => v.Text)
                .To(vm => vm.EndTime)
                .WithConvertion<MonthValueConverter>();

            bindingSet.Bind(ViewHolder.VacationEndYear)
                .For(v => v.Text)
                .To(vm => vm.EndTime)
                .WithConvertion<YearValueConverter>();

            bindingSet.Bind(ViewHolder.VacationStartYear)
                .For(v => v.Text)
                .To(vm => vm.StartTime)
                .WithConvertion<YearValueConverter>();

            bindingSet.Bind(ViewHolder.ApprovedRadio)
                .For(v => v.Checked)
                .To(vm => vm.VacationStatus)
                .WithConvertion<ApprovedRadioValueConverter>();

            bindingSet.Bind(ViewHolder.ClosedRadio)
                .For(v => v.Checked)
                .To(vm => vm.VacationStatus)
                .WithConvertion<ClosedRadioValueConverter>();

        }
    }
}