using Android.Support.V7.Widget;
using Android.Views;
using FlexiMvvm.Collections;

namespace VacationsTracker.Droid.Views.Home
{
    internal class VacationsAdapter : RecyclerViewObservablePlainAdapterBase
    {
        public VacationsAdapter(object itemsContext, RecyclerView recyclerView) : base(recyclerView)
        {
            ItemsContext = itemsContext;
        }

        protected override RecyclerViewObservableViewHolder OnCreateItemViewHolder(ViewGroup parent, int viewType)
        {
            var itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.cell_vacation, parent, false);

            return new VacationCellViewHolder(itemView);
        }
    }
}