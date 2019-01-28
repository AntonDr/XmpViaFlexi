using Android.Widget;
using FlexiMvvm.Bindings;
using FlexiMvvm.Bindings.Custom;

namespace VacationsTracker.Droid.Views
{
    public static class CustomBindings
    {
        public static TargetItemBinding<ImageView, int> SetImageResourceBinding(
            this IItemReference<ImageView> imageViewReference)
        {
            return new TargetItemOneWayCustomBinding<ImageView, int>(
                imageViewReference,
                (imageView, resId) => { imageView.SetImageResource(resId); },
                () => "SetImageResource");
        }
    }
}