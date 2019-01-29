using System;
using System.Globalization;
using Android.Views;
using FlexiMvvm.Bindings;
using FlexiMvvm.Collections;
using VacationsTracker.Core.Presentation.ViewModels.Home;

namespace VacationsTracker.Droid.Views
{
    public partial class VacationHeaderCellViewHolder
        : RecyclerViewBindableHeaderFooterViewHolder<HomeViewModel>
    {
        public VacationHeaderCellViewHolder(View itemView) : base(itemView)
        {
        }

        public override void Bind(BindingSet<HomeViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(LastUpdatedTime)
                .For(v => v.Text)
                .To(vm => vm.RefreshedDateTime);
        }
    }
}