using Cirrious.FluentLayouts.Touch;
using FlexiMvvm;
using FlexiMvvm.Collections;
using FlexiMvvm.Views;
using System;
using VacationsTracker.Core.Presentation.ViewModels.Home;

namespace VacationsTracker.iOS.Views.Home.VacationsTable
{
    internal class VacationTableFooterViewCell : UITableViewBindableSectionHeaderFooterCell<HomeViewModel>
    {
        public static string CellId => nameof(VacationTableFooterViewCell);

        private VacationTableFooterView View { get; set; }

        public override void LoadView()
        {
            View = new VacationTableFooterView();

            ContentView.NotNull().AddSubview(View);
            ContentView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
            ContentView.AddConstraints(View.FullSizeOf(ContentView));
        }

        public VacationTableFooterViewCell(IntPtr handle) : base(handle)
        {
        }
    }
}