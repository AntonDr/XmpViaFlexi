using Android.Support.Design.Widget;
using Android.Support.V7.Widget;
using FlexiMvvm;

namespace VacationsTracker.Droid.Views.Home
{
    public class OnScrollListenerFab : RecyclerView.OnScrollListener
    {
        private readonly RecyclerView _recyclerView;

        private readonly FloatingActionButton _fab;

        public OnScrollListenerFab(RecyclerView recyclerView, FloatingActionButton fab)
        {
            _recyclerView = recyclerView.NotNull();
            _fab = fab.NotNull();
        }

        public override void OnScrolled(RecyclerView recyclerView, int dx, int dy)
        {
            if (dy != 0 && _fab.IsShown)
            {
                _fab.Hide();
            }
        }

        public override void OnScrollStateChanged(RecyclerView recyclerView, int newState)
        {
            if (newState == RecyclerView.ScrollStateIdle)
            {
                _fab.Show();
            }

            base.OnScrollStateChanged(recyclerView, newState);
        }
    }
}