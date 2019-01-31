using Android.OS;
using Android.Views;
using FlexiMvvm.Views.V4;
using VacationsTracker.Core.Presentation.ViewModels.Details;

namespace VacationsTracker.Droid.Views.Details
{
    public class VacationTypesFragment : FlxBindableFragment<VacationTypePagerViewModel, VacationTypePagerParameters>
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            return base.OnCreateView(inflater, container, savedInstanceState);
        }
    }
}