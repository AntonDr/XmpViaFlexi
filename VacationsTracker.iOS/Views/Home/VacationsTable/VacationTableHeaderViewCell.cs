using Cirrious.FluentLayouts.Touch;
using FlexiMvvm;
using FlexiMvvm.Bindings;
using FlexiMvvm.Collections;
using System;
using VacationsTracker.Core.Presentation.ValueConverters;
using VacationsTracker.Core.Presentation.ViewModels.Home;

namespace VacationsTracker.iOS.Views.Home.VacationsTable
{
    internal class VacationTableHeaderViewCell : UITableViewBindableSectionHeaderFooterCell<HomeViewModel>
    {
        public static string CellId => nameof(VacationTableHeaderViewCell);

        private VacationTableHeaderView View { get; set; }
        public VacationTableHeaderViewCell(IntPtr handle) : base(handle)
        {
        }

        public override void LoadView()
        {
            View = new VacationTableHeaderView();

            ContentView.NotNull().AddSubview(View);
            ContentView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
            ContentView.AddConstraints(View.FullSizeOf(ContentView));
        }

        public override void Bind(BindingSet<HomeViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(View.RefreshTimeLabel)
                .For(v => v.Text)
                .To(vm => vm.RefreshedDateTime)
                .WithConvertion<RefreshTimeValueConverter>();
        }
    }
}