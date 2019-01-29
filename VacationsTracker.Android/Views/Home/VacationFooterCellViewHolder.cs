using Android.Views;
using FlexiMvvm.Collections;
using VacationsTracker.Core.Presentation.ViewModels.Home;

namespace VacationsTracker.Droid.Views
{
    public partial class VacationFooterCellViewHolder
        : RecyclerViewBindableHeaderFooterViewHolder<HomeViewModel>
    {
        public VacationFooterCellViewHolder(View itemView) : base(itemView)
        {
        }
    }
}