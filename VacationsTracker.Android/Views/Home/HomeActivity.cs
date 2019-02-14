using System;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.Widget;
using Android.Views;
using FlexiMvvm.Bindings;
using FlexiMvvm.Views;
using FlexiMvvm.Views.V7;
using VacationsTracker.Core.Domain;
using VacationsTracker.Core.Presentation.ViewModels.Home;
using VacationsTracker.Droid.Views.ValueConverters;

namespace VacationsTracker.Droid.Views.Home
{
    [Activity(
        Label = "HomeActivity")]
    public class HomeActivity : FlxBindableAppCompatActivity<HomeViewModel>
    {
        private HomeActivityViewHolder ViewHolder { get; set; }

        private VacationsAdapter VacationsAdapter { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_home);

            ViewHolder = new HomeActivityViewHolder(this);

            VacationsAdapter = new VacationsAdapter(ViewModel, ViewHolder.RecyclerView)
            {
                Items = ViewModel.Vacations
            };
            ViewHolder.RecyclerView.SetAdapter(VacationsAdapter);
            ViewHolder.RecyclerView.SetLayoutManager(new LinearLayoutManager(this, 1, false));

            ViewHolder.Refresher.Refresh += OnRefresh;

            ViewHolder.RecyclerView.AddOnScrollListener(new OnScrollListenerFab(ViewHolder.RecyclerView, ViewHolder.Fab));

            SetSupportActionBar(ViewHolder.HomeToolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.Title = Resources.GetString(Resource.String.home_page_title);
            //SupportActionBar.SetHomeAsUpIndicator(Resource.Id.right_icon);

            ViewHolder.NavView.NavigationItemSelected += (s,e) => ViewHolder.DrawerLayout.CloseDrawers();

        }

        //private async void NavigationItemSelected(object sender, NavigationView.NavigationItemSelectedEventArgs e)
        //{
        //    switch (e.MenuItem.ItemId)
        //    {
        //        case Resource.Id.nav_open:
        //            await ViewModel.Refresh(VacationStatus.Approved);
        //            break;
        //        case Resource.Id.nav_close:
        //            await ViewModel.Refresh(VacationStatus.Closed);
        //            break;
        //        case Resource.Id.nav_main:
        //            await ViewModel.Refresh();
        //            break;
        //    }

        //    ViewHolder.DrawerLayout.CloseDrawers();
        //}

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.home:
                    ViewHolder.DrawerLayout.OpenDrawer(Android.Support.V4.View.GravityCompat.Start);
                    return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        protected override async void OnResume()
        {
            base.OnResume();

            await ViewModel.Refresh();
        }

        public override void Bind(BindingSet<HomeViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(VacationsAdapter)
                .For(v => v.ItemClickedBinding())
                .To(vm => vm.VacationSelectedCommand);

            bindingSet.Bind(ViewHolder.Fab)
                .For(v => v.ClickBinding())
                .To(vm => vm.VacationCreatedCommand);

            bindingSet.Bind(ViewHolder.NavView)
                .For(v => v.NavigationItemSelectedBinding())
                .To(vm => vm.FilterNavigationCommand)
                .WithConvertion<NavigationMenuItemValueConverter>();

           

        }

        private async void OnRefresh(object sender, EventArgs args)
        {
            await Task.Delay(1000);
            ViewHolder.Refresher.Refreshing = false;
            ViewModel.RefreshedDateTime = DateTime.Now;
        }
    }
}