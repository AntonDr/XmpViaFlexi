using FlexiMvvm;
using FlexiMvvm.Bindings;
using FlexiMvvm.Collections;
using FlexiMvvm.Views;
using UIKit;
using VacationsTracker.Core.Presentation.ViewModels.Home;
using VacationsTracker.Core.Resources;
using VacationsTracker.iOS.Views.Home.VacationsTable;

namespace VacationsTracker.iOS.Views.Home
{
    internal class HomeViewController : FlxBindableViewController<HomeViewModel>
    {
        private UITableViewObservablePlainSource VacationsSource { get; set; }

        private UIBarButtonItem NewButton { get; } = BarButtonFactory.GetCreateButton();



        public new HomeView View
        {
            get => (HomeView)base.View.NotNull();
            set => base.View = value;
        }

        public override void LoadView()
        {
            View = new HomeView();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            VacationsSource = new UITableViewObservablePlainSource(
                View.VacationsTableView,
                _ => VacationItemViewCell.CellId,
                () => VacationTableHeaderViewCell.CellId,
                () => VacationTableFooterViewCell.CellId)
            {
                Items = ViewModel.Vacations,
                ItemsContext = ViewModel
            };

            View.VacationsTableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
            View.VacationsTableView.Source = VacationsSource;

            var deleteDelegate = new DeleteElementDelegate();

            View.VacationsTableView.Delegate = deleteDelegate;

            NavigationItem.Title = Strings.HomePage_Title;

        }

        public override async void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            NavigationItem.RightBarButtonItem = NewButton;

            await ViewModel.Refresh();
        }

        public override void Bind(BindingSet<HomeViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(VacationsSource)
                .For(v => v.Items)
                .To(vm => vm.Vacations);

            bindingSet.Bind(VacationsSource)
                .For(v => v.RowSelectedBinding())
                .To(vm => vm.VacationSelectedCommand);

            bindingSet.Bind(View.VacationsTableView.RefreshControl)
                .For(v => v.BeginRefreshingBinding())
                .To(vm => vm.Loading);

            bindingSet.Bind(View.VacationsTableView.RefreshControl)
                .For(v => v.EndRefreshingBinding())
                .To(vm => vm.Loading);

            bindingSet.Bind(View.VacationsTableView.RefreshControl)
                .For(v => v.ValueChangedBinding())
                .To(vm => vm.RefreshCommand);

            bindingSet.Bind(NewButton)
                .For(v => v.NotNull().ClickedBinding())
                .To(vm => vm.VacationCreatedCommand);

            bindingSet.Bind(View.VacationsTableView.Delegate)
                .For(v => v.SwipeButtonBinding())
                .To(vm => vm.DeleteVacationCommand);
        }
    }
}