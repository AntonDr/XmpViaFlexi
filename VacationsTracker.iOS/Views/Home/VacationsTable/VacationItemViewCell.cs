using System;
using Cirrious.FluentLayouts.Touch;
using FlexiMvvm;
using FlexiMvvm.Bindings;
using FlexiMvvm.Collections;
using VacationsTracker.Core.Presentation.ViewModels;
using VacationsTracker.Core.Presentation.ViewModels.Home;

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

            //TODO define bindings
        }
    }
}