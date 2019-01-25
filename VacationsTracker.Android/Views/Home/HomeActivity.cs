using Android.App;
using Android.OS;
using FlexiMvvm.Bootstrappers;
using FlexiMvvm.Collections;
using FlexiMvvm.Ioc;
using FlexiMvvm.Views.V7;
using Plugin.CurrentActivity;
using VacationsTracker.Core.Bootstrappers;
using VacationsTracker.Core.Presentation.ViewModels.Home;
using VacationsTracker.Droid.Bootstrappers;

namespace VacationsTracker.Droid.Views.Home
{
    [Activity(
        MainLauncher = true,
        Label = "HomeActivity")]
    public class HomeActivity : FlxAppCompatActivity<HomeViewModel>
    {
        private HomeActivityViewHolder ViewHolder { get; set; }

        private RecyclerViewObservablePlainAdapterBase VacationsAdapter { get; set; }


        protected override void OnCreate(Bundle savedInstanceState)
        {
            CrossCurrentActivity.Current.Init(this, savedInstanceState);

            var config = new BootstrapperConfig();
            config.SetSimpleIoc(new SimpleIoc());

            var compositeBootstrapper = new CompositeBootstrapper(
                new CoreBootstrapper(),
                new AndroidBootstrapper());

            compositeBootstrapper.Execute(config);

            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_home);

            ViewHolder = new HomeActivityViewHolder(this);

            VacationsAdapter = new VacationsAdapter(ViewHolder.RecyclerView) {Items = ViewModel.Vacations};
        }
    }
}