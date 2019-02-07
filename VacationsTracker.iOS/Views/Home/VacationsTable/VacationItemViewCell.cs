using System;
using System.Globalization;
using Cirrious.FluentLayouts.Touch;
using FlexiMvvm;
using FlexiMvvm.Bindings;
using FlexiMvvm.Collections;
using FlexiMvvm.ValueConverters;
using VacationsTracker.Core.Presentation.ValueConverters;
using VacationsTracker.Core.Presentation.ViewModels;
using VacationsTracker.Core.Presentation.ViewModels.Home;
using VacationsTracker.iOS.Views.ValueConverters;

namespace VacationsTracker.iOS.Views.Home.VacationsTable
{
    internal class VacationItemViewCell
        : UITableViewBindableItemCell<HomeViewModel, VacationCellViewModel>
    {
        protected internal VacationItemViewCell(IntPtr handle)
            : base(handle)
        {
        }

        public static string CellId { get; } = nameof(VacationItemViewCell);

        private VacationItemView View { get; set; }

        public override void LoadView()
        {
            View = new VacationItemView();

            ContentView.NotNull().AddSubview(View);
            ContentView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
            ContentView.AddConstraints(View.FullSizeOf(ContentView));
        }
       

        public override void Bind(BindingSet<VacationCellViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(View.StatusView)
                .For(v => v.Text)
                .To(vm => vm.Status)
                .WithConvertion<VacationStatusValueConverter>();

            bindingSet.Bind(View.DurationVacationTextView)
                .For(v => v.Text)
                .To(vm => vm.Duration)
                .WithConvertion<DurationValueConverter>();

            bindingSet.Bind(View.TypeView)
                .For(v => v.Text)
                .To(vm => vm.Type)
                .WithConvertion<VacationTypeValueConverter>();

            bindingSet.Bind(View.ImageView)
                .For(v => v.Image)
                .To(vm => vm.Type)
                .WithConvertion<ImageValueConverter>();

            bindingSet.Bind(View.Separator)
                .For(v => v.Hidden)
                .To(vm => vm.SeparatorVisible)
                .WithConvertion<InvertValueConverter>();

        }
    }

}