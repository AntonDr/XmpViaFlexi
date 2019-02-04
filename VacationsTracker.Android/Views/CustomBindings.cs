using Android.Support.Design.Widget;
using Android.Widget;
using FlexiMvvm.Bindings;
using FlexiMvvm.Bindings.Custom;
using VacationsTracker.Core.Domain;

namespace VacationsTracker.Droid.Views
{
    public static class CustomBindings
    {
        public static TargetItemBinding<ImageView, int> SetImageResourceBinding(
            this IItemReference<ImageView> imageViewReference)
        {
            return new TargetItemOneWayCustomBinding<ImageView, int>(
                imageViewReference,
                (imageView, resId) =>
                {
                    imageView.SetImageResource(resId);
                },
                () => "SetImageResource");
        }
        public static TargetItemBinding<NavigationView, int> NavigationItemSelectedBinding(
            this IItemReference<NavigationView> imageViewReference)
        {
            return new TargetItemOneWayToSourceCustomBinding<NavigationView, int, NavigationView.NavigationItemSelectedEventArgs>(
                imageViewReference,
                (view, handler) => view.NavigationItemSelected += handler,
                (view, handler) => view.NavigationItemSelected -= handler,
                (view, trackCanExecute) => { },
                (view, args) => args.MenuItem.ItemId,
                () => "SetImageResource");
        }


    }
}