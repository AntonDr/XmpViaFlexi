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

        public static TargetItemBinding<RadioButton, VacationStatus> SetVacationStatusBinding(
            this  IItemReference<RadioButton> radioButtonReference)
        {
            return new TargetItemTwoWayCustomBinding<RadioButton, VacationStatus>(
                radioButtonReference,
                (radioButton, status) =>
                {
                    radioButton.Checked = true;

                },
                );
        }
    }
}