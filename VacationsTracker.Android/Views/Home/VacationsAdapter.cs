using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using FlexiMvvm.Collections;
using Java.Util;

namespace VacationsTracker.Droid.Views.Home
{
    internal class VacationsAdapter : RecyclerViewObservablePlainAdapterBase
    {
        public VacationsAdapter(RecyclerView recyclerView) : base(recyclerView)
        {
        }

        protected override RecyclerViewObservableViewHolder OnCreateItemViewHolder(ViewGroup parent, int viewType)
        {
            var itemView = LayoutInflater.From(parent.Context)
                .Inflate(Resource.Layout.cell_vacation, parent, false);


            return new VacationCellViewHolder(itemView);
        }
    }
}