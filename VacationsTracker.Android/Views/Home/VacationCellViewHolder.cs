
using Android.Views;
using FlexiMvvm.Bindings;
using FlexiMvvm.Collections;
using VacationsTracker.Core.Presentation.ViewModels;

namespace VacationsTracker.Droid.Views
{
    public partial class VacationCellViewHolder
        : RecyclerViewBindableItemViewHolder<object, VacationCellViewModel>
    {
        public VacationCellViewHolder(View itemView) : base(itemView)
        {
        }

        public override void Bind(BindingSet<VacationCellViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(VacationType)
                .For(v => v.Text)
                .To(vm => vm.VacationType);
        }
    }
}