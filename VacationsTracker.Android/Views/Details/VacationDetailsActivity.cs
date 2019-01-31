using Android.App;
using Android.OS;
using Android.Widget;
using FlexiMvvm.Bindings;
using FlexiMvvm.Collections;
using FlexiMvvm.Views;
using FlexiMvvm.Views.V7;
using System;
using Android.Views;
using FlexiMvvm.Weak.Subscriptions;
using VacationsTracker.Core.Presentation.ValueConverters;
using VacationsTracker.Core.Presentation.ViewModels.Details;
using VacationsTracker.Droid.Views.ValueConverters;

namespace VacationsTracker.Droid.Views.Details
{
    [Activity(Label = "VacationDetailsActivity")]
    public class VacationDetailsActivity
        : FlxBindableAppCompatActivity<VacationDetailsViewModel, VacationDetailsParameters>
    {
        private VacationDetailsActivityViewHolder ViewHolder { get; set; }

        private FragmentPagerObservableAdapter VacationTypesAdapter { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_vacation_details);

            ViewHolder = new VacationDetailsActivityViewHolder(this);

            VacationTypesAdapter = new FragmentPagerObservableAdapter(SupportFragmentManager, FragmentsFactory)
            {
                Items = ViewModel.VacationTypes
            };

            ViewHolder.VacationTypePager.Adapter = VacationTypesAdapter;

            var pager = ViewHolder.VacationTypePager;



            var tabLayout = ViewHolder.TabDots;
            tabLayout.SetupWithViewPager(pager);


            ViewHolder.DateStart.ClickWeakSubscribe(OnVacationStartDayClick);
            ViewHolder.DateEnd.ClickWeakSubscribe(OnVacationEndDayClick);

        }


        public override void Bind(BindingSet<VacationDetailsViewModel> bindingSet)
        {
            bindingSet.Bind(VacationTypesAdapter)
                .For(v => v.Items)
                .To(vm => vm.VacationTypes);

            bindingSet.Bind(ViewHolder.VacationStartDay)
                .For(v => v.Text)
                .To(vm => vm.Vacation.Start)
                .WithConvertion<DateTimeToDayValueConverter>();

            bindingSet.Bind(ViewHolder.VacationStartMonth)
                .For(v => v.Text)
                .To(vm => vm.Vacation.Start)
                .WithConvertion<DateTimeToMonthValueConverter>();

            bindingSet.Bind(ViewHolder.VacationStartYear)
                .For(v => v.Text)
                .To(vm => vm.Vacation.Start)
                .WithConvertion<DateTimeToYearValueConverter>();

            bindingSet.Bind(ViewHolder.VacationEndDay)
                .For(v => v.Text)
                .To(vm => vm.Vacation.End)
                .WithConvertion<DateTimeToDayValueConverter>();

            bindingSet.Bind(ViewHolder.VacationEndMonth)
                .For(v => v.Text)
                .To(vm => vm.Vacation.End)
                .WithConvertion<DateTimeToMonthValueConverter>();

            bindingSet.Bind(ViewHolder.VacationEndYear)
                .For(v => v.Text)
                .To(vm => vm.Vacation.End)
                .WithConvertion<DateTimeToYearValueConverter>();

            bindingSet.Bind(ViewHolder.StatusRadioGroup)
                .For(v => v.CheckAndCheckedChangeBinding())
                .To(vm => vm.Vacation.Status)
                .WithConvertion<RadioGroupValueConverter>();

            bindingSet.Bind(ViewHolder.SaveRequestButton)
                .For(v => v.ClickBinding())
                .To(vm => vm.SaveCommand);

            bindingSet.Bind(ViewHolder.VacationTypePager)
                .For(v => v.SetCurrentItemAndPageSelectedBinding())
                .To(vm => vm.Vacation.Type)
                .WithConvertion<VacationTypeToImageNumberValueConverter>();
        }

       
        private Android.Support.V4.App.Fragment FragmentsFactory(object parameters)
        {
            if (parameters is VacationTypePagerParameters vacationTypePagerParameters)
            {
                var bundle = new Bundle();
                bundle.PutViewModelParameters(vacationTypePagerParameters);

                var fragment = new VacationTypeFragment()
                {
                    Arguments = bundle
                };

                return fragment;
            }

            throw new NotSupportedException(nameof(parameters));

        }

        private void OnVacationStartDayClick(object sender, EventArgs args)
        {
            var datePickerFragment = DatePickerFragment.NewInstance(this.ViewModel.Vacation.Start, selectedTime => ViewModel.Vacation.Start = selectedTime);
            datePickerFragment.Show(FragmentManager, string.Empty);
        }

        private void OnVacationEndDayClick(object sender, EventArgs args)
        {
            var datePickerFragment = DatePickerFragment.NewInstance(this.ViewModel.Vacation.End, selectedTime => ViewModel.Vacation.End = selectedTime);
            datePickerFragment.Show(FragmentManager, string.Empty);
        }
    }
}